namespace MovieRental
{
    partial class HelpForm
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
            this.infotext = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // infotext
            // 
            this.infotext.Location = new System.Drawing.Point(35, 23);
            this.infotext.Name = "infotext";
            this.infotext.Size = new System.Drawing.Size(1056, 809);
            this.infotext.TabIndex = 0;
            this.infotext.Text = "";
            // 
            // HelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 873);
            this.Controls.Add(this.infotext);
            this.Name = "HelpForm";
            this.Text = "HelpForm";
            this.Load += new System.EventHandler(this.HelpForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox infotext;
    }
}