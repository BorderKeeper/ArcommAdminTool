namespace ArcommAdminTool.TroopDistribution
{
    partial class TroopDistributionUserControl
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
            this.IdealFireteamSizeUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SpecialRolePlayersText = new System.Windows.Forms.TextBox();
            this.PvpDelimiter = new System.Windows.Forms.Label();
            this.OpforRatioText = new System.Windows.Forms.TextBox();
            this.BluforRatioText = new System.Windows.Forms.TextBox();
            this.PvpCheckbox = new System.Windows.Forms.CheckBox();
            this.NumberOfPlayersLabel = new System.Windows.Forms.Label();
            this.TroopDistributionTree = new System.Windows.Forms.TreeView();
            this.CalculateButton = new System.Windows.Forms.Button();
            this.NumberOfPlayersTextbox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.IdealFireteamSizeUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // IdealFireteamSizeUpDown
            // 
            this.IdealFireteamSizeUpDown.Location = new System.Drawing.Point(230, 32);
            this.IdealFireteamSizeUpDown.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.IdealFireteamSizeUpDown.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.IdealFireteamSizeUpDown.Name = "IdealFireteamSizeUpDown";
            this.IdealFireteamSizeUpDown.Size = new System.Drawing.Size(38, 20);
            this.IdealFireteamSizeUpDown.TabIndex = 23;
            this.IdealFireteamSizeUpDown.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(125, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Ideal Fireteam Size:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(189, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Special Role Players:";
            // 
            // SpecialRolePlayersText
            // 
            this.SpecialRolePlayersText.Location = new System.Drawing.Point(302, 7);
            this.SpecialRolePlayersText.Name = "SpecialRolePlayersText";
            this.SpecialRolePlayersText.Size = new System.Drawing.Size(67, 20);
            this.SpecialRolePlayersText.TabIndex = 20;
            // 
            // PvpDelimiter
            // 
            this.PvpDelimiter.AutoSize = true;
            this.PvpDelimiter.Location = new System.Drawing.Point(85, 35);
            this.PvpDelimiter.Name = "PvpDelimiter";
            this.PvpDelimiter.Size = new System.Drawing.Size(10, 13);
            this.PvpDelimiter.TabIndex = 19;
            this.PvpDelimiter.Text = ":";
            // 
            // OpforRatioText
            // 
            this.OpforRatioText.Location = new System.Drawing.Point(95, 32);
            this.OpforRatioText.Name = "OpforRatioText";
            this.OpforRatioText.Size = new System.Drawing.Size(24, 20);
            this.OpforRatioText.TabIndex = 18;
            // 
            // BluforRatioText
            // 
            this.BluforRatioText.Location = new System.Drawing.Point(60, 32);
            this.BluforRatioText.Name = "BluforRatioText";
            this.BluforRatioText.Size = new System.Drawing.Size(24, 20);
            this.BluforRatioText.TabIndex = 17;
            // 
            // PvpCheckbox
            // 
            this.PvpCheckbox.AutoSize = true;
            this.PvpCheckbox.Location = new System.Drawing.Point(9, 34);
            this.PvpCheckbox.Name = "PvpCheckbox";
            this.PvpCheckbox.Size = new System.Drawing.Size(46, 17);
            this.PvpCheckbox.TabIndex = 16;
            this.PvpCheckbox.Text = "PvP";
            this.PvpCheckbox.UseVisualStyleBackColor = true;
            this.PvpCheckbox.CheckedChanged += new System.EventHandler(this.PvpCheckbox_CheckedChanged);
            // 
            // NumberOfPlayersLabel
            // 
            this.NumberOfPlayersLabel.AutoSize = true;
            this.NumberOfPlayersLabel.Location = new System.Drawing.Point(3, 10);
            this.NumberOfPlayersLabel.Name = "NumberOfPlayersLabel";
            this.NumberOfPlayersLabel.Size = new System.Drawing.Size(96, 13);
            this.NumberOfPlayersLabel.TabIndex = 15;
            this.NumberOfPlayersLabel.Text = "Number of Players:";
            // 
            // TroopDistributionTree
            // 
            this.TroopDistributionTree.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TroopDistributionTree.Location = new System.Drawing.Point(3, 62);
            this.TroopDistributionTree.Name = "TroopDistributionTree";
            this.TroopDistributionTree.Size = new System.Drawing.Size(391, 574);
            this.TroopDistributionTree.TabIndex = 14;
            // 
            // CalculateButton
            // 
            this.CalculateButton.Location = new System.Drawing.Point(319, 33);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(75, 23);
            this.CalculateButton.TabIndex = 13;
            this.CalculateButton.Text = "Calculate";
            this.CalculateButton.UseVisualStyleBackColor = true;
            this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // NumberOfPlayersTextbox
            // 
            this.NumberOfPlayersTextbox.Location = new System.Drawing.Point(105, 6);
            this.NumberOfPlayersTextbox.Name = "NumberOfPlayersTextbox";
            this.NumberOfPlayersTextbox.Size = new System.Drawing.Size(75, 20);
            this.NumberOfPlayersTextbox.TabIndex = 12;
            // 
            // TroopDistributionUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.IdealFireteamSizeUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SpecialRolePlayersText);
            this.Controls.Add(this.PvpDelimiter);
            this.Controls.Add(this.OpforRatioText);
            this.Controls.Add(this.BluforRatioText);
            this.Controls.Add(this.PvpCheckbox);
            this.Controls.Add(this.NumberOfPlayersLabel);
            this.Controls.Add(this.TroopDistributionTree);
            this.Controls.Add(this.CalculateButton);
            this.Controls.Add(this.NumberOfPlayersTextbox);
            this.Name = "TroopDistributionUserControl";
            this.Size = new System.Drawing.Size(403, 644);
            ((System.ComponentModel.ISupportInitialize)(this.IdealFireteamSizeUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown IdealFireteamSizeUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SpecialRolePlayersText;
        private System.Windows.Forms.Label PvpDelimiter;
        private System.Windows.Forms.TextBox OpforRatioText;
        private System.Windows.Forms.TextBox BluforRatioText;
        private System.Windows.Forms.CheckBox PvpCheckbox;
        private System.Windows.Forms.Label NumberOfPlayersLabel;
        private System.Windows.Forms.TreeView TroopDistributionTree;
        private System.Windows.Forms.Button CalculateButton;
        private System.Windows.Forms.TextBox NumberOfPlayersTextbox;
    }
}
