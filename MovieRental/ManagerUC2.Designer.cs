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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 210);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(656, 220);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            // 
            // Insert
            // 
            this.Insert.Location = new System.Drawing.Point(57, 181);
            this.Insert.Name = "Insert";
            this.Insert.Size = new System.Drawing.Size(75, 23);
            this.Insert.TabIndex = 1;
            this.Insert.Text = "Insert";
            this.Insert.UseVisualStyleBackColor = true;
            this.Insert.Click += new System.EventHandler(this.Insert_Click);
            // 
            // Update
            // 
            this.Update.Location = new System.Drawing.Point(149, 181);
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
            this.label1.Location = new System.Drawing.Point(27, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Movie Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Movie Type:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Distrubution Fee";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Number of copies:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(272, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Release Date:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(292, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Add Date:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(300, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Director:";
            // 
            // MovieNameTxt
            // 
            this.MovieNameTxt.Location = new System.Drawing.Point(112, 13);
            this.MovieNameTxt.Name = "MovieNameTxt";
            this.MovieNameTxt.Size = new System.Drawing.Size(138, 20);
            this.MovieNameTxt.TabIndex = 10;
            // 
            // MovieTypeTxt
            // 
            this.MovieTypeTxt.Location = new System.Drawing.Point(112, 47);
            this.MovieTypeTxt.Name = "MovieTypeTxt";
            this.MovieTypeTxt.Size = new System.Drawing.Size(100, 20);
            this.MovieTypeTxt.TabIndex = 11;
            // 
            // DistFeeTxt
            // 
            this.DistFeeTxt.Location = new System.Drawing.Point(112, 80);
            this.DistFeeTxt.Name = "DistFeeTxt";
            this.DistFeeTxt.Size = new System.Drawing.Size(100, 20);
            this.DistFeeTxt.TabIndex = 12;
            // 
            // NumCopiesTxt
            // 
            this.NumCopiesTxt.Location = new System.Drawing.Point(112, 114);
            this.NumCopiesTxt.Name = "NumCopiesTxt";
            this.NumCopiesTxt.Size = new System.Drawing.Size(100, 20);
            this.NumCopiesTxt.TabIndex = 13;
            // 
            // ReleaseDateTxt
            // 
            this.ReleaseDateTxt.Location = new System.Drawing.Point(367, 13);
            this.ReleaseDateTxt.Name = "ReleaseDateTxt";
            this.ReleaseDateTxt.Size = new System.Drawing.Size(100, 20);
            this.ReleaseDateTxt.TabIndex = 14;
            // 
            // AddDateTxt
            // 
            this.AddDateTxt.Location = new System.Drawing.Point(367, 47);
            this.AddDateTxt.Name = "AddDateTxt";
            this.AddDateTxt.Size = new System.Drawing.Size(100, 20);
            this.AddDateTxt.TabIndex = 15;
            // 
            // DirectorTxt
            // 
            this.DirectorTxt.Location = new System.Drawing.Point(367, 80);
            this.DirectorTxt.Name = "DirectorTxt";
            this.DirectorTxt.Size = new System.Drawing.Size(100, 20);
            this.DirectorTxt.TabIndex = 16;
            // 
            // CurrentNumTxt
            // 
            this.CurrentNumTxt.Location = new System.Drawing.Point(367, 117);
            this.CurrentNumTxt.Name = "CurrentNumTxt";
            this.CurrentNumTxt.Size = new System.Drawing.Size(100, 20);
            this.CurrentNumTxt.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(263, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Current Number:";
            // 
            // ManagerUC2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CurrentNumTxt);
            this.Controls.Add(this.DirectorTxt);
            this.Controls.Add(this.AddDateTxt);
            this.Controls.Add(this.ReleaseDateTxt);
            this.Controls.Add(this.NumCopiesTxt);
            this.Controls.Add(this.DistFeeTxt);
            this.Controls.Add(this.MovieTypeTxt);
            this.Controls.Add(this.MovieNameTxt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Update);
            this.Controls.Add(this.Insert);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ManagerUC2";
            this.Size = new System.Drawing.Size(734, 456);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}
