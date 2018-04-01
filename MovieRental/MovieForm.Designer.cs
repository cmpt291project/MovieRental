namespace MovieRental
{
    partial class MovieForm
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
            this.mName = new System.Windows.Forms.Label();
            this.panelInMovieForm = new System.Windows.Forms.Panel();
            this.actorPanel = new System.Windows.Forms.Panel();
            this.panelInMovieForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // mName
            // 
            this.mName.AutoSize = true;
            this.mName.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mName.Location = new System.Drawing.Point(62, 46);
            this.mName.Name = "mName";
            this.mName.Size = new System.Drawing.Size(224, 40);
            this.mName.TabIndex = 0;
            this.mName.Text = "movie name";
            // 
            // panelInMovieForm
            // 
            this.panelInMovieForm.Controls.Add(this.actorPanel);
            this.panelInMovieForm.Controls.Add(this.mName);
            this.panelInMovieForm.Location = new System.Drawing.Point(1, 12);
            this.panelInMovieForm.Name = "panelInMovieForm";
            this.panelInMovieForm.Size = new System.Drawing.Size(1209, 928);
            this.panelInMovieForm.TabIndex = 1;
            // 
            // actorPanel
            // 
            this.actorPanel.AutoScroll = true;
            this.actorPanel.Location = new System.Drawing.Point(34, 424);
            this.actorPanel.Name = "actorPanel";
            this.actorPanel.Size = new System.Drawing.Size(1135, 483);
            this.actorPanel.TabIndex = 1;
            // 
            // MovieForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1213, 945);
            this.Controls.Add(this.panelInMovieForm);
            this.Name = "MovieForm";
            this.Text = "MovieForm";
            this.Load += new System.EventHandler(this.MovieForm_Load);
            this.panelInMovieForm.ResumeLayout(false);
            this.panelInMovieForm.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label mName;
        private System.Windows.Forms.Panel panelInMovieForm;
        private System.Windows.Forms.Panel actorPanel;
    }
}