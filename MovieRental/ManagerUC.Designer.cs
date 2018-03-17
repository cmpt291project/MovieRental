namespace MovieRental
{
    partial class ManagerUC
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.GetRevenue = new System.Windows.Forms.Button();
            this.GetMovies = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(23, 48);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // DataGridView
            // 
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.Location = new System.Drawing.Point(229, 13);
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.ReadOnly = true;
            this.DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView.Size = new System.Drawing.Size(468, 419);
            this.DataGridView.TabIndex = 2;
            this.DataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellContentClick_1);
            // 
            // GetRevenue
            // 
            this.GetRevenue.Location = new System.Drawing.Point(23, 74);
            this.GetRevenue.Name = "GetRevenue";
            this.GetRevenue.Size = new System.Drawing.Size(88, 23);
            this.GetRevenue.TabIndex = 3;
            this.GetRevenue.Text = "Get Revenue";
            this.GetRevenue.UseVisualStyleBackColor = true;
            this.GetRevenue.Click += new System.EventHandler(this.GetRevenue_Click);
            // 
            // GetMovies
            // 
            this.GetMovies.Location = new System.Drawing.Point(23, 125);
            this.GetMovies.Name = "GetMovies";
            this.GetMovies.Size = new System.Drawing.Size(88, 26);
            this.GetMovies.TabIndex = 4;
            this.GetMovies.Text = "Get Movies";
            this.GetMovies.UseVisualStyleBackColor = true;
            this.GetMovies.Click += new System.EventHandler(this.GetMovies_Click);
            // 
            // ManagerUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GetMovies);
            this.Controls.Add(this.GetRevenue);
            this.Controls.Add(this.DataGridView);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "ManagerUC";
            this.Size = new System.Drawing.Size(722, 448);
            this.Load += new System.EventHandler(this.ManagerUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView DataGridView;
        private System.Windows.Forms.Button GetRevenue;
        private System.Windows.Forms.Button GetMovies;
    }
}
