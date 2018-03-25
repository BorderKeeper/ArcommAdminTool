namespace ArcommAdminTool
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainFormControl = new System.Windows.Forms.TabControl();
            this.TroopDistributionTab = new System.Windows.Forms.TabPage();
            this.troopDistributionUserControl1 = new ArcommAdminTool.TroopDistribution.TroopDistributionUserControl();
            this.AbsenceTab = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.MainFormControl.SuspendLayout();
            this.TroopDistributionTab.SuspendLayout();
            this.AbsenceTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainFormControl
            // 
            this.MainFormControl.Controls.Add(this.TroopDistributionTab);
            this.MainFormControl.Controls.Add(this.AbsenceTab);
            this.MainFormControl.Location = new System.Drawing.Point(12, 12);
            this.MainFormControl.Name = "MainFormControl";
            this.MainFormControl.SelectedIndex = 0;
            this.MainFormControl.Size = new System.Drawing.Size(411, 667);
            this.MainFormControl.TabIndex = 0;
            // 
            // TroopDistributionTab
            // 
            this.TroopDistributionTab.Controls.Add(this.troopDistributionUserControl1);
            this.TroopDistributionTab.Location = new System.Drawing.Point(4, 22);
            this.TroopDistributionTab.Name = "TroopDistributionTab";
            this.TroopDistributionTab.Padding = new System.Windows.Forms.Padding(3);
            this.TroopDistributionTab.Size = new System.Drawing.Size(403, 641);
            this.TroopDistributionTab.TabIndex = 1;
            this.TroopDistributionTab.Text = "Troop Distribution";
            this.TroopDistributionTab.UseVisualStyleBackColor = true;
            // 
            // troopDistributionUserControl1
            // 
            this.troopDistributionUserControl1.Location = new System.Drawing.Point(0, 0);
            this.troopDistributionUserControl1.Name = "troopDistributionUserControl1";
            this.troopDistributionUserControl1.Size = new System.Drawing.Size(403, 644);
            this.troopDistributionUserControl1.TabIndex = 0;
            // 
            // AbsenceTab
            // 
            this.AbsenceTab.Controls.Add(this.label1);
            this.AbsenceTab.Location = new System.Drawing.Point(4, 22);
            this.AbsenceTab.Name = "AbsenceTab";
            this.AbsenceTab.Padding = new System.Windows.Forms.Padding(3);
            this.AbsenceTab.Size = new System.Drawing.Size(403, 641);
            this.AbsenceTab.TabIndex = 2;
            this.AbsenceTab.Text = "Absence Announcements";
            this.AbsenceTab.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kingsley Gib API";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 681);
            this.Controls.Add(this.MainFormControl);
            this.Name = "MainForm";
            this.Text = "Arcomm Admin Tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MainFormControl.ResumeLayout(false);
            this.TroopDistributionTab.ResumeLayout(false);
            this.AbsenceTab.ResumeLayout(false);
            this.AbsenceTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MainFormControl;
        private System.Windows.Forms.TabPage TroopDistributionTab;
        private System.Windows.Forms.TabPage AbsenceTab;
        private TroopDistribution.TroopDistributionUserControl troopDistributionUserControl1;
        private System.Windows.Forms.Label label1;
    }
}

