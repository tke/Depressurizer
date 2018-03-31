/*
This file is part of Depressurizer.
Copyright 2011, 2012, 2013 Steve Labbe.

Depressurizer is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

Depressurizer is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with Depressurizer.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Depressurizer
{
    public partial class AutoCatConfigPanel_CompletionistMe : AutoCatConfigPanel
    {
        BindingList<CMe_Rule> ruleList = new BindingList<CMe_Rule>();
        BindingSource binding = new BindingSource();

        public AutoCatConfigPanel_CompletionistMe()
        {
            InitializeComponent();

            //initialize combobox
            cmbStatus.Items.AddRange(new object[]
            {
                CMe_Status.All,
                CMe_Status.UnderPar,
                CMe_Status.OverPar,
                CMe_Status.Completed
            });
            cmbStatus.SelectedItem = CMe_Status.All;

            numRuleMinProgress.DecimalPlaces = 1;
            numRuleMaxProgress.DecimalPlaces = 1;

            // Set up help tooltips
            ttHelp.Ext_SetToolTip(helpRules, GlobalStrings.AutoCatUserScore_Help_Rules);
            ttHelp.Ext_SetToolTip(helpPrefix, GlobalStrings.DlgAutoCat_Help_Prefix);
            ttHelp.Ext_SetToolTip(helpUnknown, GlobalStrings.AutocatHltb_Help_Unknown);

            // Set up bindings.
            // None of these strings should be localized.
            binding.DataSource = ruleList;

            lstRules.DisplayMember = "Name";
            lstRules.DataSource = binding;

            txtRuleName.DataBindings.Add("Text", binding, "Name");
            numRuleMinProgress.DataBindings.Add("Value", binding, "Min");
            numRuleMaxProgress.DataBindings.Add("Value", binding, "Max");
            cmbStatus.DataBindings.Add("SelectedItem", binding, "Status");
            chkStopProcessing.DataBindings.Add("Checked", binding, "StopProcessing");

            UpdateEnabledSettings();
        }

        public override void SaveToAutoCat(AutoCat ac)
        {
            AutoCatCompletionistMe acCme = ac as AutoCatCompletionistMe;
            if (acCme == null) return;

            acCme.Prefix = txtPrefix.Text;
            acCme.IncludeUnstarted = chkIncludeUnstarted.Checked;
            acCme.UnstartedText = txtUnstartedText.Text;
            acCme.CleanExisting = chkCleanExisting.Checked;
            acCme.Rules = new List<CMe_Rule>(ruleList);
        }

        public override void LoadFromAutoCat(AutoCat ac)
        {
            AutoCatCompletionistMe acCme = ac as AutoCatCompletionistMe;
            if (acCme == null) return;

            txtPrefix.Text = acCme.Prefix;
            chkIncludeUnstarted.Checked = acCme.IncludeUnstarted;
            chkCleanExisting.Checked = acCme.CleanExisting;
            txtUnstartedText.Text = (acCme.UnstartedText == null) ? string.Empty : acCme.UnstartedText;
            acCme.IncludeUnstarted = chkIncludeUnstarted.Checked;
            acCme.CleanExisting = chkCleanExisting.Checked;
            acCme.UnstartedText = txtUnstartedText.Text;

            ruleList.Clear();
            foreach (CMe_Rule rule in acCme.Rules)
            {
                ruleList.Add(new CMe_Rule(rule));
            }
            UpdateEnabledSettings();
        }

        /// <summary>
        /// Updates enabled states of all form elements that depend on the rule selection.
        /// </summary>
        private void UpdateEnabledSettings()
        {
            bool ruleSelected = (lstRules.SelectedIndex >= 0);

            txtRuleName.Enabled =
                numRuleMaxProgress.Enabled = numRuleMinProgress.Enabled =
                cmbStatus.Enabled = chkStopProcessing.Enabled =
                        cmdRuleRemove.Enabled = ruleSelected;
            cmdRuleUp.Enabled = ruleSelected && lstRules.SelectedIndex != 0;
            cmdRuleDown.Enabled = ruleSelected = ruleSelected && lstRules.SelectedIndex != lstRules.Items.Count - 1;
        }

        /// <summary>
        /// Moves the specified rule a certain number of spots up or down in the list. Does nothing if the spot would be off the list.
        /// </summary>
        /// <param name="mainIndex">Index of the rule to move.</param>
        /// <param name="offset">Number of spots to move the rule. Negative moves up, positive moves down.</param>
        /// <param name="selectMoved">If true, select the moved element afterwards</param>
        private void MoveItem(int mainIndex, int offset, bool selectMoved)
        {
            int alterIndex = mainIndex + offset;
            if (mainIndex < 0 || mainIndex >= lstRules.Items.Count || alterIndex < 0 ||
                alterIndex >= lstRules.Items.Count) return;

            CMe_Rule mainItem = ruleList[mainIndex];
            ruleList[mainIndex] = ruleList[alterIndex];
            ruleList[alterIndex] = mainItem;
            if (selectMoved) lstRules.SelectedIndex = alterIndex;
        }

        /// <summary>
        /// Adds a new rule to the end of the list and selects it.
        /// </summary>
        private void AddRule()
        {
            CMe_Rule newRule = new CMe_Rule(GlobalStrings.AutoCatUserScore_NewRuleName, 0, 0);
            ruleList.Add(newRule);
            lstRules.SelectedIndex = lstRules.Items.Count - 1;
        }

        /// <summary>
        /// Removes the rule at the given index
        /// </summary>
        /// <param name="index">Index of the rule to remove</param>
        private void RemoveRule(int index)
        {
            if (index >= 0)
            {
                ruleList.RemoveAt(index);
            }
        }

        #region Event Handlers

        private void lstRules_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateEnabledSettings();
        }

        private void cmdRuleAdd_Click(object sender, EventArgs e)
        {
            AddRule();
        }

        private void cmdRuleRemove_Click(object sender, EventArgs e)
        {
            RemoveRule(lstRules.SelectedIndex);
        }

        private void cmdRuleUp_Click(object sender, EventArgs e)
        {
            MoveItem(lstRules.SelectedIndex, -1, true);
        }

        private void cmdRuleDown_Click(object sender, EventArgs e)
        {
            MoveItem(lstRules.SelectedIndex, 1, true);
        }

        #endregion
    }
}