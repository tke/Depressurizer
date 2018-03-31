using System.Collections.Generic;
using System.Linq;
using DepressurizerCore.Models;
using DepressurizerCore.Helpers;
using HtmlAgilityPack;
using System.Xml;
using System.Xml.Serialization;
using System.ComponentModel;

namespace Depressurizer
{
    public enum CMe_Status
    {
        [Description("Any Status")] All,
        [Description("Under-par")] UnderPar,
        [Description("Over-par")] OverPar,
        [Description("Completed")] Completed
    }

    public class CMe_State
    {
        public int AppId { get; set; }
        public CMe_Status Status { get; set; } 
        public float Progress { get; set; }
    }

    public class CMe_Rule
    {
        [XmlElement("Text")]
        public string Name { get; set; }
        public float Min { get; set; }
        public float Max { get; set; }
        public CMe_Status Status { get; set; } = CMe_Status.All;
        public bool StopProcessing { get; set; } = false;

        public CMe_Rule(string name, float minProgress, float maxProgress, CMe_Status status = CMe_Status.All, bool stopProcessing = true)
        {
            Name = name;
            Min = minProgress;
            Max = maxProgress;
            Status = status;
            StopProcessing = stopProcessing;
        }

        //XmlSerializer requires a parameterless constructor
        private CMe_Rule() { }

        public CMe_Rule(CMe_Rule other)
        {
            Name = other.Name;
            Min = other.Min;
            Max = other.Max;
            Status = other.Status;
            StopProcessing = other.StopProcessing;
        }
    }

    public class AutoCatCompletionistMe : AutoCat
    {
        #region Properties

        public string Prefix { get; set; }
        public bool IncludeUnstarted { get; set; }
        public bool CleanExisting { get; set; }
        public string UnstartedText { get; set; }
        [XmlElement("Rule")]
        public List<CMe_Rule> Rules;

        [XmlIgnore]
        private IDictionary<int, CMe_State> CMeProgress { get; set; } = new Dictionary<int, CMe_State>();

        public override AutoCatType AutoCatType
        {
            get { return AutoCatType.CompletionistMe; }
        }

        public const string TypeIdString = "AutoCatCompletionistMe";

        public const string XmlName_Name = "Name",
            XmlName_Filter = "Filter",
            XmlName_Prefix = "Prefix",
            XmlName_IncludeUnstarted = "IncludeUnstarted",
            XmlName_UnstartedText = "UnstartedText",
            XmlName_CleanExisting = "CleanExisting",
            XmlName_Rule = "Rule",
            XmlName_Rule_Text = "Text",
            XmlName_Rule_Min = "Min",
            XmlName_Rule_Max = "Max",
            XmlName_Rule_Status = "Status",
            XmlName_Rule_StopProcessing = "StopProcessing";

        #endregion

        #region Construction

        public AutoCatCompletionistMe(string name, string filter = null, string prefix = null,
            bool includeUnstarted = true, string unstartedText = "", List<CMe_Rule> rules = null, bool selected = false, bool cleanExisting = true)
            : base(name)
        {
            Filter = filter;
            Prefix = prefix;
            IncludeUnstarted = includeUnstarted;
            UnstartedText = unstartedText;
            Rules = rules ?? new List<CMe_Rule>();
            Selected = selected;
            CleanExisting = cleanExisting;
        }

        //XmlSerializer requires a parameterless constructor
        private AutoCatCompletionistMe() { }

        public AutoCatCompletionistMe(AutoCatCompletionistMe other)
            : base(other)
        {
            Filter = other.Filter;
            Prefix = other.Prefix;
            IncludeUnstarted = other.IncludeUnstarted;
            UnstartedText = other.UnstartedText;
            Rules = other.Rules.ConvertAll(rule => new CMe_Rule(rule));
            Selected = other.Selected;
            CleanExisting = other.CleanExisting;
        }

        public override AutoCat Clone()
        {
            return new AutoCatCompletionistMe(this);
        }

        #endregion

        #region Autocategorization

        public override void PreProcess(GameList games, Database db)
        {
            base.PreProcess(games, db);
            CMeProgress = ScrapeUserProgress(FormMain.CurrentProfile.SteamID64).ToDictionary(kv => kv.AppId);
        }

        private IEnumerable<CMe_State> ScrapeUserProgress(long steamId)
        {
            HtmlWeb htmlWeb = new HtmlWeb();
            for(var page = 1; ; page++)
            {
                HtmlNodeCollection gameDivs = GetGameDivs(steamId, page, htmlWeb);
                if (gameDivs != null && gameDivs.Count != 0)
                {
                    foreach (HtmlNode gameDiv in gameDivs)
                    {
                        var res = ExtractGameProgress(gameDiv);
                        if (res != null) yield return res;
                        else yield break;
                    }
                }
                else
                {
                    yield break;
                }
            }
        }

        private static HtmlNodeCollection GetGameDivs(long steamId, int page, HtmlWeb htmlWeb)
        {
            HtmlDocument res = htmlWeb.Load(@"https://completionist.me/steam/profile/" + steamId + @"/apps?display=grid&order=desc&sort=completion&page=" + page);
            HtmlNodeCollection gameDivs = res.DocumentNode.SelectNodes(@"//div[contains(concat(' ',@class,' '), ' game ')]");
            return gameDivs;
        }

        private static CMe_State ExtractGameProgress(HtmlNode gameDiv)
        {
            if (int.TryParse(gameDiv.SelectSingleNode(@".//a").GetAttributeValue("href", null)?.Split('/')?.Last(), out int appId))
            {
                var progressBar = gameDiv.SelectSingleNode(@".//div[@role='progressbar']");
                if (progressBar != null)
                {
                    var pbClass = progressBar.GetAttributeValue("class", "");
                    CMe_Status? status = null;
                    if (pbClass.Contains("progress-bar-perfect"))
                        status = CMe_Status.Completed;
                    else if (pbClass.Contains("progress-bar-warning"))
                        status = CMe_Status.UnderPar;
                    else if (pbClass.Contains("progress-bar-success"))
                        status = CMe_Status.OverPar;
                    if (status != null && float.TryParse(progressBar?.GetAttributeValue("aria-valuenow", "-1"), out float progress))
                        return new CMe_State { AppId = appId, Progress = progress, Status = status.Value };
                }
            }
            return null;
        }

        public override AutoCatResult CategorizeGame(GameInfo game, Filter filter)
        {
            if (game == null)
            {
                Logger.Instance.Error(GlobalStrings.Log_AutoCat_GameNull);
                return AutoCatResult.Failure;
            }

            if (!game.IncludeGame(filter)) return AutoCatResult.Filtered;

            if (CleanExisting)
            {
                if (IncludeUnstarted) {
                    var existingUnstarted = game.Categories.FirstOrDefault(it => it.Name.Equals(GetProcessedString(UnstartedText)));
                    if(existingUnstarted != null)
                    {
                        game.RemoveCategory(existingUnstarted);
                    }
                }
                foreach (var rule in Rules)
                {
                    var existingCategory = game.Categories.FirstOrDefault(it => it.Name.Equals(GetProcessedString(rule.Name)));
                    if (existingCategory != null)
                    {
                        game.RemoveCategory(existingCategory);
                    }
                }
            }

            string result = null;
            if (CMeProgress.ContainsKey(game.Id))
            {
                CMe_State state = CMeProgress[game.Id];
                foreach(var rule in Rules)
                {
                    if(CheckRule(rule, state))
                    {
                        game.AddCategory(games.GetCategory(GetProcessedString(rule.Name)));
                        if (rule.StopProcessing) break;
                    }
                }
            }
            else if (IncludeUnstarted)
            {
                result = UnstartedText;
            }
            return AutoCatResult.Success;
        }


        private bool CheckRule(CMe_Rule rule, CMe_State state) => 
            state.Progress >= rule.Min 
            && (state.Progress < rule.Max || rule.Max == 0.0f)
            && (state.Status == rule.Status || rule.Status == CMe_Status.All);

        private string GetProcessedString(string s)
        {
            if (!string.IsNullOrEmpty(Prefix)) return Prefix + s;
            return s;
        }

        #endregion

        #region Serialization

        public override void WriteToXml(XmlWriter writer)
        {
            writer.WriteStartElement(TypeIdString);

            writer.WriteElementString(XmlName_Name, Name);
            if (Filter != null) writer.WriteElementString(XmlName_Filter, Filter);
            if (Prefix != null) writer.WriteElementString(XmlName_Prefix, Prefix);
            writer.WriteElementString(XmlName_IncludeUnstarted, IncludeUnstarted.ToString().ToLowerInvariant());
            writer.WriteElementString(XmlName_UnstartedText, UnstartedText);


            foreach (CMe_Rule rule in Rules)
            {
                writer.WriteStartElement(XmlName_Rule);
                writer.WriteElementString(XmlName_Rule_Text, rule.Name);
                writer.WriteElementString(XmlName_Rule_Min, rule.Min.ToString());
                writer.WriteElementString(XmlName_Rule_Max, rule.Max.ToString());
                writer.WriteElementString(XmlName_Rule_Status, rule.Status.ToString());
                writer.WriteElementString(XmlName_Rule_StopProcessing, rule.StopProcessing.ToString());

                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        public static AutoCatCompletionistMe LoadFromXmlElement(XmlElement xElement)
        {
            string name = XmlUtil.GetStringFromNode(xElement[XmlName_Name], TypeIdString);
            string filter = XmlUtil.GetStringFromNode(xElement[XmlName_Filter], null);
            string prefix = XmlUtil.GetStringFromNode(xElement[XmlName_Prefix], string.Empty);
            bool includeUnstarted = XmlUtil.GetBoolFromNode(xElement[XmlName_IncludeUnstarted], false);
            string unstartedText = XmlUtil.GetStringFromNode(xElement[XmlName_UnstartedText], string.Empty);

            List<CMe_Rule> rules = new List<CMe_Rule>();
            foreach (XmlNode node in xElement.SelectNodes(XmlName_Rule))
            {
                string ruleName = XmlUtil.GetStringFromNode(node[XmlName_Rule_Text], string.Empty);
                float ruleMin = XmlUtil.GetFloatFromNode(node[XmlName_Rule_Min], 0);
                float ruleMax = XmlUtil.GetFloatFromNode(node[XmlName_Rule_Max], 0);
                CMe_Status ruleStatus = XmlUtil.GetEnumFromNode(node[XmlName_Rule_Status], CMe_Status.All);
                bool ruleStopProcessing = XmlUtil.GetBoolFromAttribute(node, XmlName_Rule_StopProcessing, false);
                rules.Add(new CMe_Rule(ruleName, ruleMin, ruleMax, ruleStatus, ruleStopProcessing));
            }
            AutoCatCompletionistMe result = new AutoCatCompletionistMe(name, filter, prefix, includeUnstarted, unstartedText) { Rules = rules };
            return result;
        }

        #endregion
    }
   
}
