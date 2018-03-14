namespace MovieRental
{
    partial class UC2
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
            this.YourMovieTab = new System.Windows.Forms.TabControl();
            this.Features = new System.Windows.Forms.TabPage();
            this.FeaturePanel = new System.Windows.Forms.Panel();
            this.Suggestion = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.rank = new System.Windows.Forms.Panel();
            this.YourMovie = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.YourMoviePanel = new System.Windows.Forms.Panel();
            this.YourMovieTab.SuspendLayout();
            this.Features.SuspendLayout();
            this.Suggestion.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // YourMovieTab
            // 
            this.YourMovieTab.Controls.Add(this.Features);
            this.YourMovieTab.Controls.Add(this.Suggestion);
            this.YourMovieTab.Controls.Add(this.YourMovie);
            this.YourMovieTab.Location = new System.Drawing.Point(0, 33);
            this.YourMovieTab.Name = "YourMovieTab";
            this.YourMovieTab.SelectedIndex = 0;
            this.YourMovieTab.Size = new System.Drawing.Size(739, 484);
            this.YourMovieTab.TabIndex = 0;
            // 
            // Features
            // 
            this.Features.AutoScroll = true;
            this.Features.Controls.Add(this.FeaturePanel);
            this.Features.Location = new System.Drawing.Point(4, 22);
            this.Features.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Features.Name = "Features";
            this.Features.Padding = new System.Windows.Forms.Padding(3);
            this.Features.Size = new System.Drawing.Size(731, 458);
            this.Features.TabIndex = 0;
            this.Features.Text = "Feature";
            this.Features.UseVisualStyleBackColor = true;
            // 
            // FeaturePanel
            // 
            this.FeaturePanel.Location = new System.Drawing.Point(6, 4);
            this.FeaturePanel.Name = "FeaturePanel";
            this.FeaturePanel.Size = new System.Drawing.Size(722, 449);
            this.FeaturePanel.TabIndex = 0;
            // 
            // Suggestion
            // 
            this.Suggestion.AutoScroll = true;
            this.Suggestion.Controls.Add(this.label1);
            this.Suggestion.Controls.Add(this.rank);
            this.Suggestion.Location = new System.Drawing.Point(4, 22);
            this.Suggestion.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Suggestion.Name = "Suggestion";
            this.Suggestion.Padding = new System.Windows.Forms.Padding(3);
            this.Suggestion.Size = new System.Drawing.Size(731, 458);
            this.Suggestion.TabIndex = 1;
            this.Suggestion.Text = "Suggestion";
            this.Suggestion.UseVisualStyleBackColor = true;
            this.Suggestion.Click += new System.EventHandler(this.Suggestion_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(66, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ranking";
            // 
            // rank
            // 
            this.rank.Location = new System.Drawing.Point(11, 47);
            this.rank.Margin = new System.Windows.Forms.Padding(2);
            this.rank.Name = "rank";
            this.rank.Size = new System.Drawing.Size(1410, 640);
            this.rank.TabIndex = 0;
            // 
            // YourMovie
            // 
            this.YourMovie.AutoScroll = true;
            this.YourMovie.Location = new System.Drawing.Point(4, 22);
            this.YourMovie.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.YourMovie.Name = "YourMovie";
            this.YourMovie.Padding = new System.Windows.Forms.Padding(3);
            this.YourMovie.Size = new System.Drawing.Size(731, 458);
            this.YourMovie.TabIndex = 0;
            this.YourMovie.Text = "Your Movie";
            this.YourMovie.UseVisualStyleBackColor = true;
            this.YourMovie.Click += new System.EventHandler(this.YourMovie_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(339, 7);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 48);
            this.panel1.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(213, 5);
            this.button2.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(66, 43);
            this.button2.TabIndex = 3;
            this.button2.Text = "Wishlist";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(291, 5);
            this.button1.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 43);
            this.button1.TabIndex = 2;
            this.button1.Text = "Account";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(0, 29);
            this.textBox1.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(136, 20);
            this.textBox1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MovieRental.Properties.Resources.Icons8_Ios7_Very_Basic_Search;
            this.pictureBox1.Location = new System.Drawing.Point(136, 26);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // YourMoviePanel
            // 
            this.YourMoviePanel.Location = new System.Drawing.Point(9, 10);
            this.YourMoviePanel.Name = "YourMoviePanel";
            this.YourMoviePanel.Size = new System.Drawing.Size(862, 483);
            this.YourMoviePanel.TabIndex = 2;
            // 
            // UC2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.YourMovieTab);
            this.Name = "UC2";
            this.Size = new System.Drawing.Size(752, 530);
            this.Load += new System.EventHandler(this.UC2_Load);
            this.YourMovieTab.ResumeLayout(false);
            this.Features.ResumeLayout(false);
            this.Suggestion.ResumeLayout(false);
            this.Suggestion.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl YourMovieTab;
        private System.Windows.Forms.TabPage Features;
        private System.Windows.Forms.TabPage Suggestion;
        private System.Windows.Forms.TabPage YourMovie;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel FeaturePanel;
        private System.Windows.Forms.Panel rank;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel YourMoviePanel;
    }
}
