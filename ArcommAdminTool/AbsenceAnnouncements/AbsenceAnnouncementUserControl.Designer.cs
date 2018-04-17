namespace ArcommAdminTool.AbsenceAnnouncements
{
    partial class AbsenceAnnouncementUserControl
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
            this.components = new System.ComponentModel.Container();
            this.AbsenceListView = new System.Windows.Forms.ListView();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.PlayerContextStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.FilterByName = new System.Windows.Forms.ToolStripMenuItem();
            this.FilterClear = new System.Windows.Forms.Button();
            this.PlayerContextStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // AbsenceListView
            // 
            this.AbsenceListView.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.AbsenceListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AbsenceListView.AutoArrange = false;
            this.AbsenceListView.Location = new System.Drawing.Point(0, 32);
            this.AbsenceListView.Name = "AbsenceListView";
            this.AbsenceListView.Size = new System.Drawing.Size(608, 673);
            this.AbsenceListView.TabIndex = 0;
            this.AbsenceListView.UseCompatibleStateImageBehavior = false;
            this.AbsenceListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.AbsenceListView_ColumnClick);
            this.AbsenceListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AbsenceListView_MouseClick);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(3, 4);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(75, 23);
            this.RefreshButton.TabIndex = 1;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // PlayerContextStrip
            // 
            this.PlayerContextStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FilterByName});
            this.PlayerContextStrip.Name = "PlayerContextStrip";
            this.PlayerContextStrip.Size = new System.Drawing.Size(181, 48);
            // 
            // FilterByName
            // 
            this.FilterByName.Name = "FilterByName";
            this.FilterByName.Size = new System.Drawing.Size(180, 22);
            this.FilterByName.Text = "Filter by Player";
            this.FilterByName.Click += new System.EventHandler(this.FilterByName_Click);
            // 
            // FilterClear
            // 
            this.FilterClear.Location = new System.Drawing.Point(85, 4);
            this.FilterClear.Name = "FilterClear";
            this.FilterClear.Size = new System.Drawing.Size(75, 23);
            this.FilterClear.TabIndex = 3;
            this.FilterClear.Text = "Clear Filter";
            this.FilterClear.UseVisualStyleBackColor = true;
            this.FilterClear.Click += new System.EventHandler(this.FilterClear_Click);
            // 
            // AbsenceAnnouncementUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.FilterClear);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.AbsenceListView);
            this.Name = "AbsenceAnnouncementUserControl";
            this.Size = new System.Drawing.Size(608, 705);
            this.Load += new System.EventHandler(this.AbsenceAnnouncementUserControl_Load);
            this.PlayerContextStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView AbsenceListView;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.ContextMenuStrip PlayerContextStrip;
        private System.Windows.Forms.ToolStripMenuItem FilterByName;
        private System.Windows.Forms.Button FilterClear;
    }
}
