namespace MovieRental
{
    partial class RateForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.submit = new System.Windows.Forms.Button();
            this.rateMovie = new System.Windows.Forms.GroupBox();
            this.movieName = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.rateMovie.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(28, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(402, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please rate the movie and stars.";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Location = new System.Drawing.Point(22, 246);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(766, 355);
            this.panel1.TabIndex = 1;
            // 
            // submit
            // 
            this.submit.Location = new System.Drawing.Point(317, 653);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(159, 75);
            this.submit.TabIndex = 0;
            this.submit.Text = "Submit";
            this.submit.UseVisualStyleBackColor = true;
            // 
            // rateMovie
            // 
            this.rateMovie.Controls.Add(this.radioButton1);
            this.rateMovie.Controls.Add(this.movieName);
            this.rateMovie.Location = new System.Drawing.Point(22, 72);
            this.rateMovie.Name = "rateMovie";
            this.rateMovie.Size = new System.Drawing.Size(766, 127);
            this.rateMovie.TabIndex = 2;
            this.rateMovie.TabStop = false;
            this.rateMovie.Text = "Rate The Movie";
            // 
            // movieName
            // 
            this.movieName.AutoSize = true;
            this.movieName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.movieName.Location = new System.Drawing.Point(6, 39);
            this.movieName.Name = "movieName";
            this.movieName.Size = new System.Drawing.Size(81, 31);
            this.movieName.TabIndex = 0;
            this.movieName.Text = "name";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton1.Location = new System.Drawing.Point(12, 82);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(57, 33);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "5";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // RateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 754);
            this.Controls.Add(this.rateMovie);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "RateForm";
            this.Text = "RateForm";
            this.Load += new System.EventHandler(this.RateForm_Load);
            this.rateMovie.ResumeLayout(false);
            this.rateMovie.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.GroupBox rateMovie;
        private System.Windows.Forms.Label movieName;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}