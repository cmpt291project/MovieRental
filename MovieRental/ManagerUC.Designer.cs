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
            this.components = new System.ComponentModel.Container();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.GetRevenue = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.name_txt = new System.Windows.Forms.TextBox();
            this.type_txt = new System.Windows.Forms.TextBox();
            this.name_label = new System.Windows.Forms.Label();
            this.type_label = new System.Windows.Forms.Label();
            this.Update = new System.Windows.Forms.Button();
            this.movieBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.movieBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.movieBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.movieBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(23, 48);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 1;
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
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(23, 103);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(183, 68);
            this.dataGridView1.TabIndex = 5;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(23, 188);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(691, 248);
            this.dataGridView2.TabIndex = 6;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            this.dataGridView2.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellValueChanged);
            this.dataGridView2.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView2_DataError);
            this.dataGridView2.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView2_EditingControlShowing);
            this.dataGridView2.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView2_RowHeaderMouseClick);
            this.dataGridView2.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView2_UserDeletingRow);
            // 
            // name_txt
            // 
            this.name_txt.Location = new System.Drawing.Point(359, 103);
            this.name_txt.Name = "name_txt";
            this.name_txt.Size = new System.Drawing.Size(100, 20);
            this.name_txt.TabIndex = 7;
            // 
            // type_txt
            // 
            this.type_txt.Location = new System.Drawing.Point(359, 133);
            this.type_txt.Name = "type_txt";
            this.type_txt.Size = new System.Drawing.Size(100, 20);
            this.type_txt.TabIndex = 8;
            // 
            // name_label
            // 
            this.name_label.AutoSize = true;
            this.name_label.Location = new System.Drawing.Point(271, 110);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(70, 13);
            this.name_label.TabIndex = 9;
            this.name_label.Text = "Movie Name:";
            // 
            // type_label
            // 
            this.type_label.AutoSize = true;
            this.type_label.Location = new System.Drawing.Point(275, 140);
            this.type_label.Name = "type_label";
            this.type_label.Size = new System.Drawing.Size(66, 13);
            this.type_label.TabIndex = 10;
            this.type_label.Text = "Movie Type:";
            // 
            // Update
            // 
            this.Update.Location = new System.Drawing.Point(359, 159);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(75, 23);
            this.Update.TabIndex = 11;
            this.Update.Text = "Update";
            this.Update.UseVisualStyleBackColor = true;
            this.Update.Click += new System.EventHandler(this.Update_Click);
            // 
            // movieBindingSource1
            // 
            this.movieBindingSource1.DataMember = "Movie";
            // 
            // movieBindingSource2
            // 
            this.movieBindingSource2.DataMember = "Movie";
            // 
            // ManagerUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Update);
            this.Controls.Add(this.type_label);
            this.Controls.Add(this.name_label);
            this.Controls.Add(this.type_txt);
            this.Controls.Add(this.name_txt);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.GetRevenue);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "ManagerUC";
            this.Size = new System.Drawing.Size(734, 456);
            this.Load += new System.EventHandler(this.ManagerUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.movieBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.movieBindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button GetRevenue;
        private System.Windows.Forms.DataGridView dataGridView1;
        private MovieRentalDataSet movieRentalDataSet;
        private MovieRentalDataSetTableAdapters.MovieTableAdapter movieTableAdapter;
        private System.Windows.Forms.BindingSource movieBindingSource1;
        private MovieRentalDataSet movieRentalDataSet1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox name_txt;
        private System.Windows.Forms.TextBox type_txt;
        private System.Windows.Forms.Label name_label;
        private System.Windows.Forms.Label type_label;
        private System.Windows.Forms.Button Update;
        private System.Windows.Forms.BindingSource movieBindingSource2;
        private System.Windows.Forms.DataGridViewTextBoxColumn mIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn movieNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn movieTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn distribututionFeeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberOfCopiesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn releaseDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn directorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn currentNumDataGridViewTextBoxColumn;
        private MovieRentalDataSet movieRentalDataSet2;
    }
}
