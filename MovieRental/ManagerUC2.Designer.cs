namespace MovieRental
{
    partial class ManagerUC2
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Insert = new System.Windows.Forms.Button();
            this.Update = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.MovieNameTxt = new System.Windows.Forms.TextBox();
            this.MovieTypeTxt = new System.Windows.Forms.TextBox();
            this.DistFeeTxt = new System.Windows.Forms.TextBox();
            this.NumCopiesTxt = new System.Windows.Forms.TextBox();
            this.ReleaseDateTxt = new System.Windows.Forms.TextBox();
            this.AddDateTxt = new System.Windows.Forms.TextBox();
            this.DirectorTxt = new System.Windows.Forms.TextBox();
            this.CurrentNumTxt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMovies = new System.Windows.Forms.Button();
            this.btnActors = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.LastNameTxt = new System.Windows.Forms.TextBox();
            this.GenderTxt = new System.Windows.Forms.TextBox();
            this.BirthdateTxt = new System.Windows.Forms.TextBox();
            this.FirstNameTxt = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.MIDtxt = new System.Windows.Forms.TextBox();
            this.AIDtxt = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 183);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(508, 159);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            this.dataGridView1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView1_UserDeletingRow);
            // 
            // Insert
            // 
            this.Insert.Location = new System.Drawing.Point(62, 148);
            this.Insert.Name = "Insert";
            this.Insert.Size = new System.Drawing.Size(75, 23);
            this.Insert.TabIndex = 1;
            this.Insert.Text = "Insert";
            this.Insert.UseVisualStyleBackColor = true;
            this.Insert.Click += new System.EventHandler(this.Insert_Click);
            // 
            // Update
            // 
            this.Update.Location = new System.Drawing.Point(143, 148);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(75, 23);
            this.Update.TabIndex = 2;
            this.Update.Text = "Update";
            this.Update.UseVisualStyleBackColor = true;
            this.Update.Click += new System.EventHandler(this.Update_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Movie Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Movie Type:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Distrubution Fee";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Number of copies:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(277, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Release Date:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(285, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Add Date:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(285, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Director:";
            // 
            // MovieNameTxt
            // 
            this.MovieNameTxt.Location = new System.Drawing.Point(108, 8);
            this.MovieNameTxt.Name = "MovieNameTxt";
            this.MovieNameTxt.Size = new System.Drawing.Size(138, 20);
            this.MovieNameTxt.TabIndex = 10;
            // 
            // MovieTypeTxt
            // 
            this.MovieTypeTxt.Location = new System.Drawing.Point(108, 40);
            this.MovieTypeTxt.Name = "MovieTypeTxt";
            this.MovieTypeTxt.Size = new System.Drawing.Size(100, 20);
            this.MovieTypeTxt.TabIndex = 11;
            // 
            // DistFeeTxt
            // 
            this.DistFeeTxt.Location = new System.Drawing.Point(108, 72);
            this.DistFeeTxt.Name = "DistFeeTxt";
            this.DistFeeTxt.Size = new System.Drawing.Size(100, 20);
            this.DistFeeTxt.TabIndex = 12;
            // 
            // NumCopiesTxt
            // 
            this.NumCopiesTxt.Location = new System.Drawing.Point(108, 107);
            this.NumCopiesTxt.Name = "NumCopiesTxt";
            this.NumCopiesTxt.Size = new System.Drawing.Size(100, 20);
            this.NumCopiesTxt.TabIndex = 13;
            // 
            // ReleaseDateTxt
            // 
            this.ReleaseDateTxt.Location = new System.Drawing.Point(358, 8);
            this.ReleaseDateTxt.Name = "ReleaseDateTxt";
            this.ReleaseDateTxt.Size = new System.Drawing.Size(100, 20);
            this.ReleaseDateTxt.TabIndex = 14;
            // 
            // AddDateTxt
            // 
            this.AddDateTxt.Location = new System.Drawing.Point(358, 44);
            this.AddDateTxt.Name = "AddDateTxt";
            this.AddDateTxt.Size = new System.Drawing.Size(100, 20);
            this.AddDateTxt.TabIndex = 15;
            // 
            // DirectorTxt
            // 
            this.DirectorTxt.Location = new System.Drawing.Point(358, 76);
            this.DirectorTxt.Name = "DirectorTxt";
            this.DirectorTxt.Size = new System.Drawing.Size(100, 20);
            this.DirectorTxt.TabIndex = 16;
            // 
            // CurrentNumTxt
            // 
            this.CurrentNumTxt.Location = new System.Drawing.Point(358, 107);
            this.CurrentNumTxt.Name = "CurrentNumTxt";
            this.CurrentNumTxt.Size = new System.Drawing.Size(100, 20);
            this.CurrentNumTxt.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(256, 114);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Current Number:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ReleaseDateTxt);
            this.panel1.Controls.Add(this.AddDateTxt);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.DirectorTxt);
            this.panel1.Controls.Add(this.Update);
            this.panel1.Controls.Add(this.CurrentNumTxt);
            this.panel1.Controls.Add(this.Insert);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.MovieNameTxt);
            this.panel1.Controls.Add(this.MovieTypeTxt);
            this.panel1.Controls.Add(this.NumCopiesTxt);
            this.panel1.Controls.Add(this.DistFeeTxt);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(471, 174);
            this.panel1.TabIndex = 19;
            // 
            // btnMovies
            // 
            this.btnMovies.Location = new System.Drawing.Point(490, 9);
            this.btnMovies.Name = "btnMovies";
            this.btnMovies.Size = new System.Drawing.Size(75, 23);
            this.btnMovies.TabIndex = 20;
            this.btnMovies.Text = "Movies";
            this.btnMovies.UseVisualStyleBackColor = true;
            this.btnMovies.Click += new System.EventHandler(this.btnMovies_Click);
            // 
            // btnActors
            // 
            this.btnActors.Location = new System.Drawing.Point(490, 41);
            this.btnActors.Name = "btnActors";
            this.btnActors.Size = new System.Drawing.Size(75, 23);
            this.btnActors.TabIndex = 21;
            this.btnActors.Text = "Actors";
            this.btnActors.UseVisualStyleBackColor = true;
            this.btnActors.Click += new System.EventHandler(this.btnActors_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(490, 75);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 22;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.AIDtxt);
            this.panel2.Controls.Add(this.MIDtxt);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.FirstNameTxt);
            this.panel2.Controls.Add(this.BirthdateTxt);
            this.panel2.Controls.Add(this.GenderTxt);
            this.panel2.Controls.Add(this.LastNameTxt);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(471, 174);
            this.panel2.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Last Name:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "First Name:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(38, 88);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Gender:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(28, 125);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "Birth date:";
            // 
            // LastNameTxt
            // 
            this.LastNameTxt.Location = new System.Drawing.Point(94, 8);
            this.LastNameTxt.Name = "LastNameTxt";
            this.LastNameTxt.Size = new System.Drawing.Size(100, 20);
            this.LastNameTxt.TabIndex = 4;
            // 
            // GenderTxt
            // 
            this.GenderTxt.Location = new System.Drawing.Point(95, 81);
            this.GenderTxt.Name = "GenderTxt";
            this.GenderTxt.Size = new System.Drawing.Size(100, 20);
            this.GenderTxt.TabIndex = 5;
            // 
            // BirthdateTxt
            // 
            this.BirthdateTxt.Location = new System.Drawing.Point(94, 118);
            this.BirthdateTxt.Name = "BirthdateTxt";
            this.BirthdateTxt.Size = new System.Drawing.Size(100, 20);
            this.BirthdateTxt.TabIndex = 6;
            // 
            // FirstNameTxt
            // 
            this.FirstNameTxt.Location = new System.Drawing.Point(94, 44);
            this.FirstNameTxt.Name = "FirstNameTxt";
            this.FirstNameTxt.Size = new System.Drawing.Size(100, 20);
            this.FirstNameTxt.TabIndex = 7;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(289, 41);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(30, 13);
            this.label13.TabIndex = 8;
            this.label13.Text = "MID:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(289, 77);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(28, 13);
            this.label14.TabIndex = 9;
            this.label14.Text = "AID:";
            // 
            // MIDtxt
            // 
            this.MIDtxt.Location = new System.Drawing.Point(338, 34);
            this.MIDtxt.Name = "MIDtxt";
            this.MIDtxt.Size = new System.Drawing.Size(100, 20);
            this.MIDtxt.TabIndex = 10;
            // 
            // AIDtxt
            // 
            this.AIDtxt.Location = new System.Drawing.Point(338, 70);
            this.AIDtxt.Name = "AIDtxt";
            this.AIDtxt.Size = new System.Drawing.Size(100, 20);
            this.AIDtxt.TabIndex = 11;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(335, 8);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(42, 13);
            this.label15.TabIndex = 12;
            this.label15.Text = "Casting";
            // 
            // ManagerUC2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnActors);
            this.Controls.Add(this.btnMovies);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ManagerUC2";
            this.Size = new System.Drawing.Size(579, 370);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Insert;
        private System.Windows.Forms.Button Update;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox MovieNameTxt;
        private System.Windows.Forms.TextBox MovieTypeTxt;
        private System.Windows.Forms.TextBox DistFeeTxt;
        private System.Windows.Forms.TextBox NumCopiesTxt;
        private System.Windows.Forms.TextBox ReleaseDateTxt;
        private System.Windows.Forms.TextBox AddDateTxt;
        private System.Windows.Forms.TextBox DirectorTxt;
        private System.Windows.Forms.TextBox CurrentNumTxt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMovies;
        private System.Windows.Forms.Button btnActors;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox FirstNameTxt;
        private System.Windows.Forms.TextBox BirthdateTxt;
        private System.Windows.Forms.TextBox GenderTxt;
        private System.Windows.Forms.TextBox LastNameTxt;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox AIDtxt;
        private System.Windows.Forms.TextBox MIDtxt;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
    }
}
