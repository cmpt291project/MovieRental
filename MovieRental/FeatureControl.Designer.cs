namespace MovieRental
{
    partial class FeatureControl
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
            this.MoviePanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // MoviePanel
            // 
            this.MoviePanel.AutoScroll = true;
            this.MoviePanel.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.MoviePanel.Location = new System.Drawing.Point(95, 0);
            this.MoviePanel.Name = "MoviePanel";
            this.MoviePanel.Size = new System.Drawing.Size(611, 391);
            this.MoviePanel.TabIndex = 0;
            this.MoviePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.MoviePanel_Paint);
            // 
            // FeatureControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.Controls.Add(this.MoviePanel);
            this.Name = "FeatureControl";
            this.Size = new System.Drawing.Size(722, 448);
            this.Load += new System.EventHandler(this.FeatureControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MoviePanel;
    }
}
