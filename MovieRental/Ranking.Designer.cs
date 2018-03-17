namespace MovieRental
{
    partial class Ranking
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
            this.panelInRanking = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelInRanking
            // 
            this.panelInRanking.AutoScroll = true;
            this.panelInRanking.Location = new System.Drawing.Point(2, 2);
            this.panelInRanking.Name = "panelInRanking";
            this.panelInRanking.Size = new System.Drawing.Size(705, 307);
            this.panelInRanking.TabIndex = 0;
            this.panelInRanking.Paint += new System.Windows.Forms.PaintEventHandler(this.panelInRanking_Paint);
            // 
            // Ranking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelInRanking);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Ranking";
            this.Size = new System.Drawing.Size(705, 307);
            this.Load += new System.EventHandler(this.Ranking_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelInRanking;
    }
}
