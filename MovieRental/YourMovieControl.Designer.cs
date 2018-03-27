namespace MovieRental
{
    partial class YourMovieControl
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
            this.WishListButton = new System.Windows.Forms.Button();
            this.RentalHistory = new System.Windows.Forms.Button();
            this.CurrentRental = new System.Windows.Forms.Button();
            this.YourMoviePanel2 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // WishListButton
            // 
            this.WishListButton.Location = new System.Drawing.Point(6, 102);
            this.WishListButton.Margin = new System.Windows.Forms.Padding(6);
            this.WishListButton.Name = "WishListButton";
            this.WishListButton.Size = new System.Drawing.Size(96, 33);
            this.WishListButton.TabIndex = 11;
            this.WishListButton.Text = "Wish List";
            this.WishListButton.UseVisualStyleBackColor = true;
            this.WishListButton.Click += new System.EventHandler(this.button5_Click);
            // 
            // RentalHistory
            // 
            this.RentalHistory.Location = new System.Drawing.Point(6, 57);
            this.RentalHistory.Margin = new System.Windows.Forms.Padding(6);
            this.RentalHistory.Name = "RentalHistory";
            this.RentalHistory.Size = new System.Drawing.Size(96, 33);
            this.RentalHistory.TabIndex = 10;
            this.RentalHistory.Text = "Rental History";
            this.RentalHistory.UseVisualStyleBackColor = true;
            this.RentalHistory.Click += new System.EventHandler(this.button4_Click);
            // 
            // CurrentRental
            // 
            this.CurrentRental.Location = new System.Drawing.Point(6, 12);
            this.CurrentRental.Margin = new System.Windows.Forms.Padding(6);
            this.CurrentRental.Name = "CurrentRental";
            this.CurrentRental.Size = new System.Drawing.Size(96, 33);
            this.CurrentRental.TabIndex = 9;
            this.CurrentRental.Text = "Current Rental";
            this.CurrentRental.UseVisualStyleBackColor = true;
            this.CurrentRental.Click += new System.EventHandler(this.button3_Click);
            // 
            // YourMoviePanel2
            // 
            this.YourMoviePanel2.AutoScroll = true;
            this.YourMoviePanel2.Location = new System.Drawing.Point(111, 12);
            this.YourMoviePanel2.Name = "YourMoviePanel2";
            this.YourMoviePanel2.Size = new System.Drawing.Size(591, 358);
            this.YourMoviePanel2.TabIndex = 0;
            // 
            // YourMovieControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.YourMoviePanel2);
            this.Controls.Add(this.WishListButton);
            this.Controls.Add(this.RentalHistory);
            this.Controls.Add(this.CurrentRental);
            this.Name = "YourMovieControl";
            this.Size = new System.Drawing.Size(777, 392);
            this.Load += new System.EventHandler(this.YourMovieControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button WishListButton;
        private System.Windows.Forms.Button RentalHistory;
        private System.Windows.Forms.Button CurrentRental;
        private System.Windows.Forms.Panel YourMoviePanel2;
    }
}
