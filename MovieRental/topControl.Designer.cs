namespace MovieRental
{
    partial class topControl
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
            this.panelintop = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelintop
            // 
            this.panelintop.AutoSize = true;
            this.panelintop.Location = new System.Drawing.Point(3, 3);
            this.panelintop.Name = "panelintop";
            this.panelintop.Size = new System.Drawing.Size(1410, 638);
            this.panelintop.TabIndex = 1;
            // 
            // topControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.panelintop);
            this.Name = "topControl";
            this.Size = new System.Drawing.Size(1400, 666);
            this.Load += new System.EventHandler(this.topControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelintop;
    }
}
