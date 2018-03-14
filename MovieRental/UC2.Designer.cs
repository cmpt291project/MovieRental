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
            this.Form2Tab1 = new System.Windows.Forms.TabControl();
            this.Features = new System.Windows.Forms.TabPage();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button6 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Suggestion = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.rank = new System.Windows.Forms.Panel();
            this.YourMovie = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Form2Tab1.SuspendLayout();
            this.Features.SuspendLayout();
            this.Suggestion.SuspendLayout();
            this.YourMovie.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Form2Tab1
            // 
            this.Form2Tab1.Controls.Add(this.Features);
            this.Form2Tab1.Controls.Add(this.Suggestion);
            this.Form2Tab1.Controls.Add(this.YourMovie);
            this.Form2Tab1.Location = new System.Drawing.Point(0, 63);
            this.Form2Tab1.Margin = new System.Windows.Forms.Padding(6);
            this.Form2Tab1.Name = "Form2Tab1";
            this.Form2Tab1.SelectedIndex = 0;
            this.Form2Tab1.Size = new System.Drawing.Size(1478, 931);
            this.Form2Tab1.TabIndex = 0;
            // 
            // Features
            // 
            this.Features.AutoScroll = true;
            this.Features.Controls.Add(this.comboBox1);
            this.Features.Controls.Add(this.button6);
            this.Features.Controls.Add(this.panel2);
            this.Features.Location = new System.Drawing.Point(8, 39);
            this.Features.Margin = new System.Windows.Forms.Padding(6);
            this.Features.Name = "Features";
            this.Features.Padding = new System.Windows.Forms.Padding(6);
            this.Features.Size = new System.Drawing.Size(1462, 884);
            this.Features.TabIndex = 0;
            this.Features.Text = "Feature";
            this.Features.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Action",
            "Adventure",
            "Comedy",
            "Drama",
            "Horror",
            "Thriller"});
            this.comboBox1.Location = new System.Drawing.Point(6, 98);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(184, 33);
            this.comboBox1.TabIndex = 2;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(12, 38);
            this.button6.Margin = new System.Windows.Forms.Padding(6);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(150, 48);
            this.button6.TabIndex = 1;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Location = new System.Drawing.Point(206, 13);
            this.panel2.Margin = new System.Windows.Forms.Padding(6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(920, 675);
            this.panel2.TabIndex = 0;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // Suggestion
            // 
            this.Suggestion.Controls.Add(this.label1);
            this.Suggestion.Controls.Add(this.rank);
            this.Suggestion.Location = new System.Drawing.Point(8, 39);
            this.Suggestion.Margin = new System.Windows.Forms.Padding(6);
            this.Suggestion.Name = "Suggestion";
            this.Suggestion.Padding = new System.Windows.Forms.Padding(6);
            this.Suggestion.Size = new System.Drawing.Size(1462, 884);
            this.Suggestion.TabIndex = 1;
            this.Suggestion.Text = "Suggestion";
            this.Suggestion.UseVisualStyleBackColor = true;
            this.Suggestion.Click += new System.EventHandler(this.Suggestion_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(33, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ranking";
            // 
            // rank
            // 
            this.rank.Location = new System.Drawing.Point(22, 83);
            this.rank.Name = "rank";
            this.rank.Size = new System.Drawing.Size(1396, 404);
            this.rank.TabIndex = 0;
            // 
            // YourMovie
            // 
            this.YourMovie.AutoScroll = true;
            this.YourMovie.Controls.Add(this.button5);
            this.YourMovie.Controls.Add(this.button4);
            this.YourMovie.Controls.Add(this.button3);
            this.YourMovie.Location = new System.Drawing.Point(8, 39);
            this.YourMovie.Margin = new System.Windows.Forms.Padding(6);
            this.YourMovie.Name = "YourMovie";
            this.YourMovie.Padding = new System.Windows.Forms.Padding(6);
            this.YourMovie.Size = new System.Drawing.Size(1462, 884);
            this.YourMovie.TabIndex = 2;
            this.YourMovie.Text = "Your Movie";
            this.YourMovie.UseVisualStyleBackColor = true;
            this.YourMovie.Click += new System.EventHandler(this.tabPage3_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(12, 202);
            this.button5.Margin = new System.Windows.Forms.Padding(6);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(182, 77);
            this.button5.TabIndex = 8;
            this.button5.Text = "Wish List";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 113);
            this.button4.Margin = new System.Windows.Forms.Padding(6);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(182, 77);
            this.button4.TabIndex = 7;
            this.button4.Text = "Rental History";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 21);
            this.button3.Margin = new System.Windows.Forms.Padding(6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(182, 77);
            this.button3.TabIndex = 6;
            this.button3.Text = "Current Rental";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(782, 63);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 44);
            this.panel1.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(302, 2);
            this.button2.Margin = new System.Windows.Forms.Padding(6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(66, 40);
            this.button2.TabIndex = 3;
            this.button2.Text = "Wishlist";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(220, 2);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 40);
            this.button1.TabIndex = 2;
            this.button1.Text = "Account";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(0, 6);
            this.textBox1.Margin = new System.Windows.Forms.Padding(6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(136, 31);
            this.textBox1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MovieRental.Properties.Resources.Icons8_Ios7_Very_Basic_Search;
            this.pictureBox1.Location = new System.Drawing.Point(144, 8);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(42, 37);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // UC2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Form2Tab1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "UC2";
            this.Size = new System.Drawing.Size(1503, 1020);
            this.Load += new System.EventHandler(this.UC2_Load);
            this.Form2Tab1.ResumeLayout(false);
            this.Features.ResumeLayout(false);
            this.Suggestion.ResumeLayout(false);
            this.Suggestion.PerformLayout();
            this.YourMovie.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Form2Tab1;
        private System.Windows.Forms.TabPage Features;
        private System.Windows.Forms.TabPage Suggestion;
        private System.Windows.Forms.TabPage YourMovie;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel rank;
        private System.Windows.Forms.Label label1;
    }
}
