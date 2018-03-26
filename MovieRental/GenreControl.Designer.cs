namespace MovieRental
{
    partial class GenreControl
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
            this.Drama = new System.Windows.Forms.LinkLabel();
            this.panelInGerneControl = new System.Windows.Forms.Panel();
            this.Thriller = new System.Windows.Forms.LinkLabel();
            this.Action = new System.Windows.Forms.LinkLabel();
            this.Comedy = new System.Windows.Forms.LinkLabel();
            this.Adventure = new System.Windows.Forms.LinkLabel();
            this.Horror = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // Drama
            // 
            this.Drama.AutoSize = true;
            this.Drama.Location = new System.Drawing.Point(22, 25);
            this.Drama.Name = "Drama";
            this.Drama.Size = new System.Drawing.Size(75, 25);
            this.Drama.TabIndex = 4;
            this.Drama.TabStop = true;
            this.Drama.Text = "Drama";
            // 
            // panelInGerneControl
            // 
            this.panelInGerneControl.Location = new System.Drawing.Point(0, 72);
            this.panelInGerneControl.Name = "panelInGerneControl";
            this.panelInGerneControl.Size = new System.Drawing.Size(1410, 555);
            this.panelInGerneControl.TabIndex = 5;
            // 
            // Thriller
            // 
            this.Thriller.AutoSize = true;
            this.Thriller.Location = new System.Drawing.Point(121, 25);
            this.Thriller.Name = "Thriller";
            this.Thriller.Size = new System.Drawing.Size(78, 25);
            this.Thriller.TabIndex = 6;
            this.Thriller.TabStop = true;
            this.Thriller.Text = "Thriller";
            // 
            // Action
            // 
            this.Action.AutoSize = true;
            this.Action.Location = new System.Drawing.Point(236, 25);
            this.Action.Name = "Action";
            this.Action.Size = new System.Drawing.Size(72, 25);
            this.Action.TabIndex = 7;
            this.Action.TabStop = true;
            this.Action.Text = "Action";
            // 
            // Comedy
            // 
            this.Comedy.AutoSize = true;
            this.Comedy.Location = new System.Drawing.Point(350, 25);
            this.Comedy.Name = "Comedy";
            this.Comedy.Size = new System.Drawing.Size(91, 25);
            this.Comedy.TabIndex = 5;
            this.Comedy.TabStop = true;
            this.Comedy.Text = "Comedy";
            // 
            // Adventure
            // 
            this.Adventure.AutoSize = true;
            this.Adventure.Location = new System.Drawing.Point(483, 25);
            this.Adventure.Name = "Adventure";
            this.Adventure.Size = new System.Drawing.Size(110, 25);
            this.Adventure.TabIndex = 5;
            this.Adventure.TabStop = true;
            this.Adventure.Text = "Adventure";
            // 
            // Horror
            // 
            this.Horror.AutoSize = true;
            this.Horror.Location = new System.Drawing.Point(639, 25);
            this.Horror.Name = "Horror";
            this.Horror.Size = new System.Drawing.Size(72, 25);
            this.Horror.TabIndex = 8;
            this.Horror.TabStop = true;
            this.Horror.Text = "Horror";
            // 
            // GenreControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.Horror);
            this.Controls.Add(this.Adventure);
            this.Controls.Add(this.Comedy);
            this.Controls.Add(this.Action);
            this.Controls.Add(this.Thriller);
            this.Controls.Add(this.panelInGerneControl);
            this.Controls.Add(this.Drama);
            this.Name = "GenreControl";
            this.Size = new System.Drawing.Size(1410, 680);
            this.Load += new System.EventHandler(this.GenreControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel Drama;
        private System.Windows.Forms.Panel panelInGerneControl;
        private System.Windows.Forms.LinkLabel Thriller;
        private System.Windows.Forms.LinkLabel Action;
        private System.Windows.Forms.LinkLabel Comedy;
        private System.Windows.Forms.LinkLabel Adventure;
        private System.Windows.Forms.LinkLabel Horror;
    }
}
