namespace Depressurizer
{
    partial class AutoCatConfigPanel_CompletionistMe
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpMain = new System.Windows.Forms.GroupBox();
            this.helpUnknown = new System.Windows.Forms.Label();
            this.txtUnstartedText = new System.Windows.Forms.TextBox();
            this.lblUnstartedText = new System.Windows.Forms.Label();
            this.chkIncludeUnstarted = new System.Windows.Forms.CheckBox();
            this.grpRules = new System.Windows.Forms.GroupBox();
            this.helpRules = new System.Windows.Forms.Label();
            this.cmdRuleDown = new System.Windows.Forms.Button();
            this.cmdRuleUp = new System.Windows.Forms.Button();
            this.cmdRuleRemove = new System.Windows.Forms.Button();
            this.cmdRuleAdd = new System.Windows.Forms.Button();
            this.numRuleMinProgress = new System.Windows.Forms.NumericUpDown();
            this.numRuleMaxProgress = new System.Windows.Forms.NumericUpDown();
            this.txtRuleName = new System.Windows.Forms.TextBox();
            this.lblRuleMin = new System.Windows.Forms.Label();
            this.lblRuleName = new System.Windows.Forms.Label();
            this.lblRuleMax = new System.Windows.Forms.Label();
            this.lstRules = new System.Windows.Forms.ListBox();
            this.helpPrefix = new System.Windows.Forms.Label();
            this.lblPrefix = new System.Windows.Forms.Label();
            this.txtPrefix = new System.Windows.Forms.TextBox();
            this.ttHelp = new Depressurizer.Lib.ExtToolTip();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbStopProcessing = new System.Windows.Forms.CheckBox();
            this.grpMain.SuspendLayout();
            this.grpRules.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRuleMinProgress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRuleMaxProgress)).BeginInit();
            this.SuspendLayout();
            // 
            // grpMain
            // 
            this.grpMain.Controls.Add(this.helpUnknown);
            this.grpMain.Controls.Add(this.txtUnstartedText);
            this.grpMain.Controls.Add(this.lblUnstartedText);
            this.grpMain.Controls.Add(this.chkIncludeUnstarted);
            this.grpMain.Controls.Add(this.grpRules);
            this.grpMain.Controls.Add(this.helpPrefix);
            this.grpMain.Controls.Add(this.lblPrefix);
            this.grpMain.Controls.Add(this.txtPrefix);
            this.grpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMain.Location = new System.Drawing.Point(0, 0);
            this.grpMain.Name = "grpMain";
            this.grpMain.Size = new System.Drawing.Size(517, 425);
            this.grpMain.TabIndex = 0;
            this.grpMain.TabStop = false;
            this.grpMain.Text = "Edit Completionist.me AutoCat";
            // 
            // helpUnknown
            // 
            this.helpUnknown.AutoSize = true;
            this.helpUnknown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.helpUnknown.Location = new System.Drawing.Point(144, 46);
            this.helpUnknown.Name = "helpUnknown";
            this.helpUnknown.Size = new System.Drawing.Size(15, 15);
            this.helpUnknown.TabIndex = 13;
            this.helpUnknown.Text = "?";
            // 
            // txtUnstartedText
            // 
            this.txtUnstartedText.Location = new System.Drawing.Point(130, 68);
            this.txtUnstartedText.Name = "txtUnstartedText";
            this.txtUnstartedText.Size = new System.Drawing.Size(159, 20);
            this.txtUnstartedText.TabIndex = 12;
            // 
            // lblUnstartedText
            // 
            this.lblUnstartedText.AutoSize = true;
            this.lblUnstartedText.Location = new System.Drawing.Point(48, 71);
            this.lblUnstartedText.Name = "lblUnstartedText";
            this.lblUnstartedText.Size = new System.Drawing.Size(76, 13);
            this.lblUnstartedText.TabIndex = 11;
            this.lblUnstartedText.Text = "Unstarted text:";
            // 
            // chkIncludeUnstarted
            // 
            this.chkIncludeUnstarted.AutoSize = true;
            this.chkIncludeUnstarted.Location = new System.Drawing.Point(28, 45);
            this.chkIncludeUnstarted.Name = "chkIncludeUnstarted";
            this.chkIncludeUnstarted.Size = new System.Drawing.Size(110, 17);
            this.chkIncludeUnstarted.TabIndex = 10;
            this.chkIncludeUnstarted.Text = "Include Unstarted";
            this.chkIncludeUnstarted.UseVisualStyleBackColor = true;
            // 
            // grpRules
            // 
            this.grpRules.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRules.Controls.Add(this.cbStopProcessing);
            this.grpRules.Controls.Add(this.label1);
            this.grpRules.Controls.Add(this.cmbStatus);
            this.grpRules.Controls.Add(this.helpRules);
            this.grpRules.Controls.Add(this.cmdRuleDown);
            this.grpRules.Controls.Add(this.cmdRuleUp);
            this.grpRules.Controls.Add(this.cmdRuleRemove);
            this.grpRules.Controls.Add(this.cmdRuleAdd);
            this.grpRules.Controls.Add(this.numRuleMinProgress);
            this.grpRules.Controls.Add(this.numRuleMaxProgress);
            this.grpRules.Controls.Add(this.txtRuleName);
            this.grpRules.Controls.Add(this.lblRuleMin);
            this.grpRules.Controls.Add(this.lblRuleName);
            this.grpRules.Controls.Add(this.lblRuleMax);
            this.grpRules.Controls.Add(this.lstRules);
            this.grpRules.Location = new System.Drawing.Point(6, 95);
            this.grpRules.Name = "grpRules";
            this.grpRules.Size = new System.Drawing.Size(505, 324);
            this.grpRules.TabIndex = 4;
            this.grpRules.TabStop = false;
            this.grpRules.Text = "Rules";
            // 
            // helpRules
            // 
            this.helpRules.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.helpRules.AutoSize = true;
            this.helpRules.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.helpRules.Location = new System.Drawing.Point(484, 0);
            this.helpRules.Name = "helpRules";
            this.helpRules.Size = new System.Drawing.Size(15, 15);
            this.helpRules.TabIndex = 0;
            this.helpRules.Text = "?";
            // 
            // cmdRuleDown
            // 
            this.cmdRuleDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdRuleDown.Location = new System.Drawing.Point(94, 295);
            this.cmdRuleDown.Name = "cmdRuleDown";
            this.cmdRuleDown.Size = new System.Drawing.Size(86, 23);
            this.cmdRuleDown.TabIndex = 5;
            this.cmdRuleDown.Text = "Down";
            this.cmdRuleDown.UseVisualStyleBackColor = true;
            this.cmdRuleDown.Click += new System.EventHandler(this.cmdRuleDown_Click);
            // 
            // cmdRuleUp
            // 
            this.cmdRuleUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdRuleUp.Location = new System.Drawing.Point(6, 295);
            this.cmdRuleUp.Name = "cmdRuleUp";
            this.cmdRuleUp.Size = new System.Drawing.Size(86, 23);
            this.cmdRuleUp.TabIndex = 4;
            this.cmdRuleUp.Text = "Up";
            this.cmdRuleUp.UseVisualStyleBackColor = true;
            this.cmdRuleUp.Click += new System.EventHandler(this.cmdRuleUp_Click);
            // 
            // cmdRuleRemove
            // 
            this.cmdRuleRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdRuleRemove.Location = new System.Drawing.Point(6, 270);
            this.cmdRuleRemove.Name = "cmdRuleRemove";
            this.cmdRuleRemove.Size = new System.Drawing.Size(174, 23);
            this.cmdRuleRemove.TabIndex = 3;
            this.cmdRuleRemove.Text = "Remove Rule";
            this.cmdRuleRemove.UseVisualStyleBackColor = true;
            this.cmdRuleRemove.Click += new System.EventHandler(this.cmdRuleRemove_Click);
            // 
            // cmdRuleAdd
            // 
            this.cmdRuleAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdRuleAdd.Location = new System.Drawing.Point(6, 245);
            this.cmdRuleAdd.Name = "cmdRuleAdd";
            this.cmdRuleAdd.Size = new System.Drawing.Size(174, 23);
            this.cmdRuleAdd.TabIndex = 2;
            this.cmdRuleAdd.Text = "Add Rule";
            this.cmdRuleAdd.UseVisualStyleBackColor = true;
            this.cmdRuleAdd.Click += new System.EventHandler(this.cmdRuleAdd_Click);
            // 
            // numRuleMinProgress
            // 
            this.numRuleMinProgress.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numRuleMinProgress.Location = new System.Drawing.Point(319, 74);
            this.numRuleMinProgress.Name = "numRuleMinProgress";
            this.numRuleMinProgress.Size = new System.Drawing.Size(59, 20);
            this.numRuleMinProgress.TabIndex = 9;
            // 
            // numRuleMaxProgress
            // 
            this.numRuleMaxProgress.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numRuleMaxProgress.Location = new System.Drawing.Point(319, 100);
            this.numRuleMaxProgress.Name = "numRuleMaxProgress";
            this.numRuleMaxProgress.Size = new System.Drawing.Size(59, 20);
            this.numRuleMaxProgress.TabIndex = 11;
            // 
            // txtRuleName
            // 
            this.txtRuleName.Location = new System.Drawing.Point(248, 19);
            this.txtRuleName.Name = "txtRuleName";
            this.txtRuleName.Size = new System.Drawing.Size(130, 20);
            this.txtRuleName.TabIndex = 7;
            // 
            // lblRuleMin
            // 
            this.lblRuleMin.AutoSize = true;
            this.lblRuleMin.Location = new System.Drawing.Point(186, 76);
            this.lblRuleMin.Name = "lblRuleMin";
            this.lblRuleMin.Size = new System.Drawing.Size(71, 13);
            this.lblRuleMin.TabIndex = 8;
            this.lblRuleMin.Text = "Min Progress:";
            // 
            // lblRuleName
            // 
            this.lblRuleName.AutoSize = true;
            this.lblRuleName.Location = new System.Drawing.Point(186, 22);
            this.lblRuleName.Name = "lblRuleName";
            this.lblRuleName.Size = new System.Drawing.Size(38, 13);
            this.lblRuleName.TabIndex = 6;
            this.lblRuleName.Text = "Name:";
            // 
            // lblRuleMax
            // 
            this.lblRuleMax.AutoSize = true;
            this.lblRuleMax.Location = new System.Drawing.Point(186, 102);
            this.lblRuleMax.Name = "lblRuleMax";
            this.lblRuleMax.Size = new System.Drawing.Size(78, 26);
            this.lblRuleMax.TabIndex = 10;
            this.lblRuleMax.Text = "Max Progress:\n(0 for unlimited)";
            // 
            // lstRules
            // 
            this.lstRules.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstRules.FormattingEnabled = true;
            this.lstRules.IntegralHeight = false;
            this.lstRules.Location = new System.Drawing.Point(6, 19);
            this.lstRules.Name = "lstRules";
            this.lstRules.Size = new System.Drawing.Size(174, 224);
            this.lstRules.TabIndex = 1;
            this.lstRules.SelectedIndexChanged += new System.EventHandler(this.lstRules_SelectedIndexChanged);
            // 
            // helpPrefix
            // 
            this.helpPrefix.AutoSize = true;
            this.helpPrefix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.helpPrefix.Location = new System.Drawing.Point(238, 22);
            this.helpPrefix.Name = "helpPrefix";
            this.helpPrefix.Size = new System.Drawing.Size(15, 15);
            this.helpPrefix.TabIndex = 2;
            this.helpPrefix.Text = "?";
            // 
            // lblPrefix
            // 
            this.lblPrefix.AutoSize = true;
            this.lblPrefix.Location = new System.Drawing.Point(25, 22);
            this.lblPrefix.Name = "lblPrefix";
            this.lblPrefix.Size = new System.Drawing.Size(36, 13);
            this.lblPrefix.TabIndex = 0;
            this.lblPrefix.Text = "Prefix:";
            // 
            // txtPrefix
            // 
            this.txtPrefix.Location = new System.Drawing.Point(67, 19);
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.Size = new System.Drawing.Size(165, 20);
            this.txtPrefix.TabIndex = 1;
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(248, 46);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(130, 21);
            this.cmbStatus.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(188, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Status:";
            // 
            // cbStopProcessing
            // 
            this.cbStopProcessing.AutoSize = true;
            this.cbStopProcessing.Location = new System.Drawing.Point(248, 144);
            this.cbStopProcessing.Name = "cbStopProcessing";
            this.cbStopProcessing.Size = new System.Drawing.Size(103, 17);
            this.cbStopProcessing.TabIndex = 14;
            this.cbStopProcessing.Text = "Stop Processing";
            this.cbStopProcessing.UseVisualStyleBackColor = true;
            // 
            // AutoCatConfigPanel_CompletionistMe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpMain);
            this.Name = "AutoCatConfigPanel_CompletionistMe";
            this.Size = new System.Drawing.Size(517, 425);
            this.grpMain.ResumeLayout(false);
            this.grpMain.PerformLayout();
            this.grpRules.ResumeLayout(false);
            this.grpRules.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRuleMinProgress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRuleMaxProgress)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMain;
        private Lib.ExtToolTip ttHelp;
        private System.Windows.Forms.Label helpPrefix;
        private System.Windows.Forms.Label lblPrefix;
        private System.Windows.Forms.TextBox txtPrefix;
        private System.Windows.Forms.GroupBox grpRules;
        private System.Windows.Forms.Button cmdRuleDown;
        private System.Windows.Forms.Button cmdRuleUp;
        private System.Windows.Forms.Button cmdRuleRemove;
        private System.Windows.Forms.Button cmdRuleAdd;
        private System.Windows.Forms.NumericUpDown numRuleMinProgress;
        private System.Windows.Forms.NumericUpDown numRuleMaxProgress;
        private System.Windows.Forms.TextBox txtRuleName;
        private System.Windows.Forms.Label lblRuleMin;
        private System.Windows.Forms.Label lblRuleName;
        private System.Windows.Forms.Label lblRuleMax;
        private System.Windows.Forms.ListBox lstRules;
        private System.Windows.Forms.Label helpUnknown;
        private System.Windows.Forms.TextBox txtUnstartedText;
        private System.Windows.Forms.Label lblUnstartedText;
        private System.Windows.Forms.CheckBox chkIncludeUnstarted;
        private System.Windows.Forms.Label helpRules;
        private System.Windows.Forms.CheckBox cbStopProcessing;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbStatus;
    }
}
