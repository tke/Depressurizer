using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DepressurizerCore.Models;
using DepressurizerCore.Helpers;
using HtmlAgilityPack;
using System.Xml;
using System.Xml.Serialization;

namespace Depressurizer
{
    public class CMe_Rule
    {
        [XmlElement("Text")]
        public string Name { get; set; }
        public float Min { get; set; }
        public float Max { get; set; }

        public CMe_Rule(string name, float minProgress, float maxProgress)
        {
            Name = name;
            Min = minProgress;
            Max = maxProgress;
        }

        //XmlSerializer requires a parameterless constructor
        private CMe_Rule() { }

        public CMe_Rule(CMe_Rule other)
        {
            Name = other.Name;
            Min = other.Min;
            Max = other.Max;
        }
    }

    public class AutoCatCompletionistMe : AutoCat
    {
        #region Properties

        public string Prefix { get; set; }
        public bool IncludeUnstarted { get; set; }
        public string UnstartedText { get; set; }
        [XmlElement("Rule")]
        public List<CMe_Rule> Rules;

        [XmlIgnore]
        private IDictionary<int, float> CMeProgress { get; set; } = new Dictionary<int, float>();

        public override AutoCatType AutoCatType
        {
            get { return AutoCatType.CompletionistMe; }
        }

        public const string TypeIdString = "AutoCatCompletionistMe";

        public const string XmlName_Name = "Name",
            XmlName_Filter = "Filter",
            XmlName_Prefix = "Prefix",
            XmlName_IncludeUnknown = "IncludeUnknown",
            XmlName_UnknownText = "UnknownText",
            XmlName_Rule = "Rule",
            XmlName_Rule_Text = "Text",
            XmlName_Rule_Min = "Min",
            XmlName_Rule_Max = "Max";

        #endregion

        #region Construction

        public AutoCatCompletionistMe(string name, string filter = null, string prefix = null,
            bool includeUnstarted = true, string unstartedText = "", List<CMe_Rule> rules = null, bool selected = false)
            : base(name)
        {
            Filter = filter;
            Prefix = prefix;
            IncludeUnstarted = includeUnstarted;
            UnstartedText = unstartedText;
            Rules = (rules == null) ? new List<CMe_Rule>() : rules;
            Selected = selected;
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
            var results = ScrapeUserProgress(FormMain.CurrentProfile.SteamID64).ToList<KeyValuePair<int, float>>();
            CMeProgress = results.ToDictionary(kv => kv.Key, kv => kv.Value);
        }

        private IEnumerable<KeyValuePair<int, float>> ScrapeUserProgress(long steamId)
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
                        if (res != null) yield return res.Value;
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

        private static KeyValuePair<int, float>? ExtractGameProgress(HtmlNode gameDiv)
        {
            int appId = int.Parse(gameDiv.SelectSingleNode(@".//a").GetAttributeValue("href", null)?.Split('/')?.Last());
            if (float.TryParse(gameDiv.SelectSingleNode(@".//div[@aria-valuenow]")?.GetAttributeValue("aria-valuenow", "-1"), out float progress))
                return new KeyValuePair<int, float>(appId, progress);
            else
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

            string result = null;
            if (CMeProgress.ContainsKey(game.Id))
            {
                float score = CMeProgress[game.Id];
                foreach(var rule in Rules)
                {
                    if(CheckRule(rule, score))
                    {
                        result = rule.Name;
                        break;
                    }
                }
            }
            else if (IncludeUnstarted)
            {
                result = UnstartedText;
            }

            if (result != null)
            {
                result = GetProcessedString(result);
                game.AddCategory(games.GetCategory(result));
            }
            return AutoCatResult.Success;
        }


        private bool CheckRule(CMe_Rule rule, float progress)
        {
            return (progress >= rule.Min && (progress < rule.Max || rule.Max == 0.0f));
        }

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
            writer.WriteElementString(XmlName_IncludeUnknown, IncludeUnstarted.ToString().ToLowerInvariant());
            writer.WriteElementString(XmlName_UnknownText, UnstartedText);


            foreach (CMe_Rule rule in Rules)
            {
                writer.WriteStartElement(XmlName_Rule);
                writer.WriteElementString(XmlName_Rule_Text, rule.Name);
                writer.WriteElementString(XmlName_Rule_Min, rule.Min.ToString());
                writer.WriteElementString(XmlName_Rule_Max, rule.Max.ToString());

                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        public static AutoCatCompletionistMe LoadFromXmlElement(XmlElement xElement)
        {
            string name = XmlUtil.GetStringFromNode(xElement[XmlName_Name], TypeIdString);
            string filter = XmlUtil.GetStringFromNode(xElement[XmlName_Filter], null);
            string prefix = XmlUtil.GetStringFromNode(xElement[XmlName_Prefix], string.Empty);
            bool includeUnknown = XmlUtil.GetBoolFromNode(xElement[XmlName_IncludeUnknown], false);
            string unknownText = XmlUtil.GetStringFromNode(xElement[XmlName_UnknownText], string.Empty);

            List<CMe_Rule> rules = new List<CMe_Rule>();
            foreach (XmlNode node in xElement.SelectNodes(XmlName_Rule))
            {
                string ruleName = XmlUtil.GetStringFromNode(node[XmlName_Rule_Text], string.Empty);
                float ruleMin = XmlUtil.GetFloatFromNode(node[XmlName_Rule_Min], 0);
                float ruleMax = XmlUtil.GetFloatFromNode(node[XmlName_Rule_Max], 0);
                rules.Add(new CMe_Rule(ruleName, ruleMin, ruleMax));
            }
            AutoCatCompletionistMe result = new AutoCatCompletionistMe(name, filter, prefix, includeUnknown, unknownText) { Rules = rules };
            return result;
        }

        #endregion
    }
   
}
