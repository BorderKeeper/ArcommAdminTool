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
            this.AbsenceListView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // AbsenceListView
            // 
            this.AbsenceListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AbsenceListView.Location = new System.Drawing.Point(0, 0);
            this.AbsenceListView.Name = "AbsenceListView";
            this.AbsenceListView.Size = new System.Drawing.Size(608, 705);
            this.AbsenceListView.TabIndex = 0;
            this.AbsenceListView.UseCompatibleStateImageBehavior = false;
            // 
            // AbsenceAnnouncementUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.AbsenceListView);
            this.Name = "AbsenceAnnouncementUserControl";
            this.Size = new System.Drawing.Size(608, 705);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView AbsenceListView;
    }
}
