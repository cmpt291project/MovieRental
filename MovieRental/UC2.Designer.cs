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
            this.components = new System.ComponentModel.Container();
            this.YourMovieTab = new System.Windows.Forms.TabControl();
            this.Features = new System.Windows.Forms.TabPage();
            this.panelGenre = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.newRelease = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.Suggestion = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.top = new System.Windows.Forms.Panel();
            this.like = new System.Windows.Forms.Panel();
            this.youmayalsolike = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rank = new System.Windows.Forms.Panel();
            this.YourMovie = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.YourMoviePanel = new System.Windows.Forms.Panel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.SearchPanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.YourMovieTab.SuspendLayout();
            this.Features.SuspendLayout();
            this.Suggestion.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // YourMovieTab
            // 
            this.YourMovieTab.Controls.Add(this.Features);
            this.YourMovieTab.Controls.Add(this.Suggestion);
            this.YourMovieTab.Controls.Add(this.YourMovie);
            this.YourMovieTab.Controls.Add(this.tabPage1);
            this.YourMovieTab.Location = new System.Drawing.Point(0, 33);
            this.YourMovieTab.Name = "YourMovieTab";
            this.YourMovieTab.SelectedIndex = 0;
            this.YourMovieTab.Size = new System.Drawing.Size(733, 772);
            this.YourMovieTab.TabIndex = 0;
            this.YourMovieTab.SelectedIndexChanged += new System.EventHandler(this.YourMovieTab_SelectedIndexChanged);
            this.YourMovieTab.TabIndexChanged += new System.EventHandler(this.YourMovieTab_TabIndexChanged);
            // 
            // Features
            // 
            this.Features.AutoScroll = true;
            this.Features.Controls.Add(this.panelGenre);
            this.Features.Controls.Add(this.label3);
            this.Features.Controls.Add(this.newRelease);
            this.Features.Controls.Add(this.label2);
            this.Features.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Features.Location = new System.Drawing.Point(4, 22);
            this.Features.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Features.Name = "Features";
            this.Features.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.Features.Size = new System.Drawing.Size(725, 746);
            this.Features.TabIndex = 0;
            this.Features.Text = "Feature";
            this.Features.UseVisualStyleBackColor = true;
            // 
            // panelGenre
            // 
            this.panelGenre.Location = new System.Drawing.Point(16, 439);
            this.panelGenre.Name = "panelGenre";
            this.panelGenre.Size = new System.Drawing.Size(700, 295);
            this.panelGenre.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(11, 405);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Choose Your Favorite Genre";
            // 
            // newRelease
            // 
            this.newRelease.AutoSize = true;
            this.newRelease.Location = new System.Drawing.Point(14, 50);
            this.newRelease.Name = "newRelease";
            this.newRelease.Size = new System.Drawing.Size(696, 332);
            this.newRelease.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(11, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "New Released";
            // 
            // Suggestion
            // 
            this.Suggestion.AutoScroll = true;
            this.Suggestion.Controls.Add(this.label4);
            this.Suggestion.Controls.Add(this.top);
            this.Suggestion.Controls.Add(this.like);
            this.Suggestion.Controls.Add(this.youmayalsolike);
            this.Suggestion.Controls.Add(this.label1);
            this.Suggestion.Controls.Add(this.rank);
            this.Suggestion.Location = new System.Drawing.Point(4, 22);
            this.Suggestion.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Suggestion.Name = "Suggestion";
            this.Suggestion.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.Suggestion.Size = new System.Drawing.Size(725, 746);
            this.Suggestion.TabIndex = 1;
            this.Suggestion.Text = "Suggestion";
            this.Suggestion.UseVisualStyleBackColor = true;
            
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(8, 769);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Top Rented";
            // 
            // top
            // 
            this.top.Location = new System.Drawing.Point(11, 794);
            this.top.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.top.Name = "top";
            this.top.Size = new System.Drawing.Size(705, 307);
            this.top.TabIndex = 4;
            // 
            // like
            // 
            this.like.Location = new System.Drawing.Point(11, 422);
            this.like.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.like.Name = "like";
            this.like.Size = new System.Drawing.Size(705, 332);
            this.like.TabIndex = 3;
            // 
            // youmayalsolike
            // 
            this.youmayalsolike.AutoSize = true;
            this.youmayalsolike.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.youmayalsolike.Location = new System.Drawing.Point(8, 398);
            this.youmayalsolike.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.youmayalsolike.Name = "youmayalsolike";
            this.youmayalsolike.Size = new System.Drawing.Size(124, 17);
            this.youmayalsolike.TabIndex = 2;
            this.youmayalsolike.Text = "You May Also Like";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(8, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ranking";
            // 
            // rank
            // 
            this.rank.Location = new System.Drawing.Point(11, 47);
            this.rank.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rank.Name = "rank";
            this.rank.Size = new System.Drawing.Size(700, 332);
            this.rank.TabIndex = 0;
            // 
            // YourMovie
            // 
            this.YourMovie.AutoScroll = true;
            this.YourMovie.Location = new System.Drawing.Point(4, 22);
            this.YourMovie.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.YourMovie.Name = "YourMovie";
            this.YourMovie.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.YourMovie.Size = new System.Drawing.Size(725, 746);
            this.YourMovie.TabIndex = 0;
            this.YourMovie.Text = "Your Movie";
            this.YourMovie.UseVisualStyleBackColor = true;
            
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(319, 7);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(370, 48);
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
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(0, 25);
            this.textBox1.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(136, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // YourMoviePanel
            // 
            this.YourMoviePanel.Location = new System.Drawing.Point(9, 10);
            this.YourMoviePanel.Name = "YourMoviePanel";
            this.YourMoviePanel.Size = new System.Drawing.Size(862, 483);
            this.YourMoviePanel.TabIndex = 2;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.SearchPanel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(725, 746);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Search";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // SearchPanel
            // 
            this.SearchPanel.Location = new System.Drawing.Point(0, 0);
            this.SearchPanel.Name = "SearchPanel";
            this.SearchPanel.Size = new System.Drawing.Size(725, 746);
            this.SearchPanel.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MovieRental.Properties.Resources.Icons8_Ios7_Very_Basic_Search;
            this.pictureBox1.Location = new System.Drawing.Point(136, 22);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // UC2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.YourMovieTab);
            this.Name = "UC2";
            this.Size = new System.Drawing.Size(739, 814);
            this.Load += new System.EventHandler(this.UC2_Load);
            this.YourMovieTab.ResumeLayout(false);
            this.Features.ResumeLayout(false);
            this.Features.PerformLayout();
            this.Suggestion.ResumeLayout(false);
            this.Suggestion.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
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
        private System.Windows.Forms.Panel rank;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel YourMoviePanel;
        private System.Windows.Forms.Panel like;
        private System.Windows.Forms.Label youmayalsolike;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel newRelease;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelGenre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel top;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel SearchPanel;
    }
}
