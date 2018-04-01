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
            this.copies = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.release = new System.Windows.Forms.Label();
            this.director = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.actorPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
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
            this.panelInMovieForm.Controls.Add(this.label4);
            this.panelInMovieForm.Controls.Add(this.copies);
            this.panelInMovieForm.Controls.Add(this.label3);
            this.panelInMovieForm.Controls.Add(this.release);
            this.panelInMovieForm.Controls.Add(this.director);
            this.panelInMovieForm.Controls.Add(this.label2);
            this.panelInMovieForm.Controls.Add(this.label1);
            this.panelInMovieForm.Controls.Add(this.actorPanel);
            this.panelInMovieForm.Controls.Add(this.mName);
            this.panelInMovieForm.Location = new System.Drawing.Point(1, 12);
            this.panelInMovieForm.Name = "panelInMovieForm";
            this.panelInMovieForm.Size = new System.Drawing.Size(1209, 928);
            this.panelInMovieForm.TabIndex = 1;
            // 
            // copies
            // 
            this.copies.AutoSize = true;
            this.copies.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.copies.Location = new System.Drawing.Point(286, 240);
            this.copies.Name = "copies";
            this.copies.Size = new System.Drawing.Size(79, 29);
            this.copies.TabIndex = 7;
            this.copies.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(64, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 29);
            this.label3.TabIndex = 6;
            this.label3.Text = "Copies Available:";
            // 
            // release
            // 
            this.release.AutoSize = true;
            this.release.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.release.Location = new System.Drawing.Point(261, 174);
            this.release.Name = "release";
            this.release.Size = new System.Drawing.Size(79, 29);
            this.release.TabIndex = 5;
            this.release.Text = "label4";
            // 
            // director
            // 
            this.director.AutoSize = true;
            this.director.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.director.Location = new System.Drawing.Point(187, 112);
            this.director.Name = "director";
            this.director.Size = new System.Drawing.Size(79, 29);
            this.director.TabIndex = 4;
            this.director.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(64, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Release Date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(64, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Director:";
            // 
            // actorPanel
            // 
            this.actorPanel.AutoScroll = true;
            this.actorPanel.Location = new System.Drawing.Point(34, 424);
            this.actorPanel.Name = "actorPanel";
            this.actorPanel.Size = new System.Drawing.Size(1135, 483);
            this.actorPanel.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(64, 368);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 29);
            this.label4.TabIndex = 8;
            this.label4.Text = "Casting:";
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
        private System.Windows.Forms.Label release;
        private System.Windows.Forms.Label director;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label copies;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}