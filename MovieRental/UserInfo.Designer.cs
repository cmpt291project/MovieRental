namespace MovieRental
{
    partial class UserInfo
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
            /*if (disposing && (components != null))
            {
                components.Dispose();
                //this.SendToBack();
            }
            base.Dispose(disposing);*/
            this.SendToBack();            
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Title = new System.Windows.Forms.Label();
            this.movieTableAdapter1 = new MovieRental.MovieRentalDataSetTableAdapters.MovieTableAdapter();
            this.FirstName = new System.Windows.Forms.TextBox();
            this.user = new System.Windows.Forms.TabControl();
            this.info = new System.Windows.Forms.TabPage();
            this.save = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.edit = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.AccountCreationDate = new System.Windows.Forms.TextBox();
            this.CreditCardNumber = new System.Windows.Forms.TextBox();
            this.EmailAddress = new System.Windows.Forms.TextBox();
            this.Telephone = new System.Windows.Forms.TextBox();
            this.ZipCode = new System.Windows.Forms.TextBox();
            this.State = new System.Windows.Forms.TextBox();
            this.City = new System.Windows.Forms.TextBox();
            this.Street = new System.Windows.Forms.TextBox();
            this.LastName = new System.Windows.Forms.TextBox();
            this.st = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.Label();
            this.plan = new System.Windows.Forms.TabPage();
            this.gb = new System.Windows.Forms.GroupBox();
            this.limited = new System.Windows.Forms.RadioButton();
            this.unlimited3 = new System.Windows.Forms.RadioButton();
            this.unlimited2 = new System.Windows.Forms.RadioButton();
            this.unlimited1 = new System.Windows.Forms.RadioButton();
            this.confirm = new System.Windows.Forms.Button();
            this.modify = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label8 = new System.Windows.Forms.Label();
            this.accountno = new System.Windows.Forms.TextBox();
            this.user.SuspendLayout();
            this.info.SuspendLayout();
            this.plan.SuspendLayout();
            this.gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Title.Location = new System.Drawing.Point(39, 32);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(146, 37);
            this.Title.TabIndex = 0;
            this.Title.Text = "User Info";
            // 
            // movieTableAdapter1
            // 
            this.movieTableAdapter1.ClearBeforeFill = true;
            // 
            // FirstName
            // 
            this.FirstName.Enabled = false;
            this.FirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FirstName.Location = new System.Drawing.Point(39, 86);
            this.FirstName.Name = "FirstName";
            this.FirstName.Size = new System.Drawing.Size(157, 38);
            this.FirstName.TabIndex = 2;
            this.FirstName.Text = "firstname";
            // 
            // user
            // 
            this.user.Controls.Add(this.info);
            this.user.Controls.Add(this.plan);
            this.user.Cursor = System.Windows.Forms.Cursors.Default;
            this.user.Location = new System.Drawing.Point(35, 72);
            this.user.Name = "user";
            this.user.SelectedIndex = 0;
            this.user.Size = new System.Drawing.Size(1108, 781);
            this.user.TabIndex = 3;
            // 
            // info
            // 
            this.info.Controls.Add(this.accountno);
            this.info.Controls.Add(this.label8);
            this.info.Controls.Add(this.save);
            this.info.Controls.Add(this.label9);
            this.info.Controls.Add(this.edit);
            this.info.Controls.Add(this.label7);
            this.info.Controls.Add(this.label6);
            this.info.Controls.Add(this.label5);
            this.info.Controls.Add(this.label4);
            this.info.Controls.Add(this.label3);
            this.info.Controls.Add(this.label2);
            this.info.Controls.Add(this.label1);
            this.info.Controls.Add(this.AccountCreationDate);
            this.info.Controls.Add(this.CreditCardNumber);
            this.info.Controls.Add(this.EmailAddress);
            this.info.Controls.Add(this.Telephone);
            this.info.Controls.Add(this.ZipCode);
            this.info.Controls.Add(this.State);
            this.info.Controls.Add(this.City);
            this.info.Controls.Add(this.Street);
            this.info.Controls.Add(this.LastName);
            this.info.Controls.Add(this.st);
            this.info.Controls.Add(this.name);
            this.info.Controls.Add(this.FirstName);
            this.info.Location = new System.Drawing.Point(8, 39);
            this.info.Name = "info";
            this.info.Padding = new System.Windows.Forms.Padding(3);
            this.info.Size = new System.Drawing.Size(1092, 734);
            this.info.TabIndex = 0;
            this.info.Text = "UserInfo";
            this.info.UseVisualStyleBackColor = true;
            // 
            // save
            // 
            this.save.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.save.Location = new System.Drawing.Point(606, 658);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(205, 60);
            this.save.TabIndex = 24;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(783, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(288, 31);
            this.label9.TabIndex = 23;
            this.label9.Text = "Account Creation Date";
            // 
            // edit
            // 
            this.edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.edit.Location = new System.Drawing.Point(286, 658);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(205, 60);
            this.edit.TabIndex = 21;
            this.edit.Text = "Edit";
            this.edit.UseVisualStyleBackColor = true;
            this.edit.Click += new System.EventHandler(this.edit_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(33, 538);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(239, 31);
            this.label7.TabIndex = 20;
            this.label7.Text = "credit card number";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(33, 400);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 31);
            this.label6.TabIndex = 19;
            this.label6.Text = "Email";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(33, 270);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 31);
            this.label5.TabIndex = 18;
            this.label5.Text = "Telephone";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(684, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 31);
            this.label4.TabIndex = 17;
            this.label4.Text = "ZipCode";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(463, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 31);
            this.label3.TabIndex = 16;
            this.label3.Text = "State";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(246, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 31);
            this.label2.TabIndex = 15;
            this.label2.Text = "City";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(280, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 31);
            this.label1.TabIndex = 14;
            this.label1.Text = "Last Name";
            // 
            // AccountCreationDate
            // 
            this.AccountCreationDate.Enabled = false;
            this.AccountCreationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AccountCreationDate.Location = new System.Drawing.Point(789, 86);
            this.AccountCreationDate.Name = "AccountCreationDate";
            this.AccountCreationDate.Size = new System.Drawing.Size(168, 38);
            this.AccountCreationDate.TabIndex = 13;
            this.AccountCreationDate.Text = "accountcretedate";
            // 
            // CreditCardNumber
            // 
            this.CreditCardNumber.Enabled = false;
            this.CreditCardNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CreditCardNumber.Location = new System.Drawing.Point(39, 599);
            this.CreditCardNumber.Name = "CreditCardNumber";
            this.CreditCardNumber.Size = new System.Drawing.Size(500, 38);
            this.CreditCardNumber.TabIndex = 12;
            this.CreditCardNumber.Text = "creditcard";
            // 
            // EmailAddress
            // 
            this.EmailAddress.Enabled = false;
            this.EmailAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EmailAddress.Location = new System.Drawing.Point(39, 462);
            this.EmailAddress.Name = "EmailAddress";
            this.EmailAddress.Size = new System.Drawing.Size(335, 38);
            this.EmailAddress.TabIndex = 11;
            this.EmailAddress.Text = "email";
            // 
            // Telephone
            // 
            this.Telephone.Enabled = false;
            this.Telephone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Telephone.Location = new System.Drawing.Point(39, 328);
            this.Telephone.Name = "Telephone";
            this.Telephone.Size = new System.Drawing.Size(335, 38);
            this.Telephone.TabIndex = 10;
            this.Telephone.Text = "tel";
            // 
            // ZipCode
            // 
            this.ZipCode.Enabled = false;
            this.ZipCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ZipCode.Location = new System.Drawing.Point(690, 202);
            this.ZipCode.Name = "ZipCode";
            this.ZipCode.Size = new System.Drawing.Size(157, 38);
            this.ZipCode.TabIndex = 9;
            this.ZipCode.Text = "zipcode";
            // 
            // State
            // 
            this.State.Enabled = false;
            this.State.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.State.Location = new System.Drawing.Point(469, 202);
            this.State.Name = "State";
            this.State.Size = new System.Drawing.Size(157, 38);
            this.State.TabIndex = 8;
            this.State.Text = "state";
            // 
            // City
            // 
            this.City.Enabled = false;
            this.City.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.City.HideSelection = false;
            this.City.Location = new System.Drawing.Point(252, 202);
            this.City.Name = "City";
            this.City.Size = new System.Drawing.Size(157, 38);
            this.City.TabIndex = 7;
            this.City.Text = "city";
            // 
            // Street
            // 
            this.Street.Enabled = false;
            this.Street.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Street.Location = new System.Drawing.Point(39, 202);
            this.Street.Name = "Street";
            this.Street.Size = new System.Drawing.Size(157, 38);
            this.Street.TabIndex = 6;
            this.Street.Text = "st";
            // 
            // LastName
            // 
            this.LastName.Enabled = false;
            this.LastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LastName.Location = new System.Drawing.Point(286, 86);
            this.LastName.Name = "LastName";
            this.LastName.Size = new System.Drawing.Size(157, 38);
            this.LastName.TabIndex = 5;
            this.LastName.Text = "lastname";
            // 
            // st
            // 
            this.st.AutoSize = true;
            this.st.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.st.Location = new System.Drawing.Point(33, 148);
            this.st.Name = "st";
            this.st.Size = new System.Drawing.Size(87, 31);
            this.st.TabIndex = 4;
            this.st.Text = "Street";
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.name.Location = new System.Drawing.Point(33, 32);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(147, 31);
            this.name.TabIndex = 3;
            this.name.Text = "First Name";
            // 
            // plan
            // 
            this.plan.Controls.Add(this.gb);
            this.plan.Controls.Add(this.confirm);
            this.plan.Controls.Add(this.modify);
            this.plan.Location = new System.Drawing.Point(8, 39);
            this.plan.Name = "plan";
            this.plan.Padding = new System.Windows.Forms.Padding(3);
            this.plan.Size = new System.Drawing.Size(1092, 734);
            this.plan.TabIndex = 1;
            this.plan.Text = "ManageYourPlan";
            this.plan.UseVisualStyleBackColor = true;
            // 
            // gb
            // 
            this.gb.Controls.Add(this.limited);
            this.gb.Controls.Add(this.unlimited3);
            this.gb.Controls.Add(this.unlimited2);
            this.gb.Controls.Add(this.unlimited1);
            this.gb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gb.Location = new System.Drawing.Point(355, 42);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(355, 337);
            this.gb.TabIndex = 8;
            this.gb.TabStop = false;
            this.gb.Text = "Your Current Plan";
            // 
            // limited
            // 
            this.limited.AutoSize = true;
            this.limited.Checked = true;
            this.limited.Enabled = false;
            this.limited.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.limited.Location = new System.Drawing.Point(43, 80);
            this.limited.Name = "limited";
            this.limited.Size = new System.Drawing.Size(123, 35);
            this.limited.TabIndex = 2;
            this.limited.TabStop = true;
            this.limited.Text = "limited";
            this.limited.UseVisualStyleBackColor = true;
            // 
            // unlimited3
            // 
            this.unlimited3.AutoSize = true;
            this.unlimited3.Enabled = false;
            this.unlimited3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.unlimited3.Location = new System.Drawing.Point(43, 138);
            this.unlimited3.Name = "unlimited3";
            this.unlimited3.Size = new System.Drawing.Size(168, 35);
            this.unlimited3.TabIndex = 3;
            this.unlimited3.Text = "unlimited3";
            this.unlimited3.UseVisualStyleBackColor = true;
            // 
            // unlimited2
            // 
            this.unlimited2.AutoSize = true;
            this.unlimited2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.unlimited2.Location = new System.Drawing.Point(43, 199);
            this.unlimited2.Name = "unlimited2";
            this.unlimited2.Size = new System.Drawing.Size(168, 35);
            this.unlimited2.TabIndex = 4;
            this.unlimited2.TabStop = true;
            this.unlimited2.Text = "unlimited2";
            this.unlimited2.UseVisualStyleBackColor = true;
            // 
            // unlimited1
            // 
            this.unlimited1.AutoSize = true;
            this.unlimited1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.unlimited1.Location = new System.Drawing.Point(43, 260);
            this.unlimited1.Name = "unlimited1";
            this.unlimited1.Size = new System.Drawing.Size(168, 35);
            this.unlimited1.TabIndex = 5;
            this.unlimited1.TabStop = true;
            this.unlimited1.Text = "unlimited1";
            this.unlimited1.UseVisualStyleBackColor = true;
            // 
            // confirm
            // 
            this.confirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.confirm.Location = new System.Drawing.Point(611, 603);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(285, 60);
            this.confirm.TabIndex = 7;
            this.confirm.Text = "Comfirm";
            this.confirm.UseVisualStyleBackColor = true;
            this.confirm.Click += new System.EventHandler(this.confirm_Click);
            // 
            // modify
            // 
            this.modify.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.modify.Location = new System.Drawing.Point(202, 603);
            this.modify.Name = "modify";
            this.modify.Size = new System.Drawing.Size(285, 60);
            this.modify.TabIndex = 6;
            this.modify.Text = "Modify Your Plan";
            this.modify.UseVisualStyleBackColor = true;
            this.modify.Click += new System.EventHandler(this.modify_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(516, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(163, 31);
            this.label8.TabIndex = 25;
            this.label8.Text = "Account No.";
            // 
            // accountno
            // 
            this.accountno.Enabled = false;
            this.accountno.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.accountno.Location = new System.Drawing.Point(522, 86);
            this.accountno.Name = "accountno";
            this.accountno.Size = new System.Drawing.Size(157, 38);
            this.accountno.TabIndex = 26;
            // 
            // UserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.user);
            this.Controls.Add(this.Title);
            this.Name = "UserInfo";
            this.Size = new System.Drawing.Size(1188, 915);
            this.Load += new System.EventHandler(this.UserInfo_Load);
            this.user.ResumeLayout(false);
            this.info.ResumeLayout(false);
            this.info.PerformLayout();
            this.plan.ResumeLayout(false);
            this.gb.ResumeLayout(false);
            this.gb.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title;
        private MovieRentalDataSetTableAdapters.MovieTableAdapter movieTableAdapter1;
        private System.Windows.Forms.TextBox FirstName;
        private System.Windows.Forms.TabControl user;
        private System.Windows.Forms.TabPage info;
        private System.Windows.Forms.TabPage plan;
        private System.Windows.Forms.TextBox LastName;
        private System.Windows.Forms.Label st;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.TextBox Street;
        private System.Windows.Forms.TextBox City;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox AccountCreationDate;
        private System.Windows.Forms.TextBox CreditCardNumber;
        private System.Windows.Forms.TextBox EmailAddress;
        private System.Windows.Forms.TextBox Telephone;
        private System.Windows.Forms.TextBox ZipCode;
        private System.Windows.Forms.TextBox State;
        private System.Windows.Forms.Button edit;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.RadioButton unlimited3;
        private System.Windows.Forms.RadioButton limited;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.Button modify;
        private System.Windows.Forms.RadioButton unlimited1;
        private System.Windows.Forms.RadioButton unlimited2;
        private System.Windows.Forms.GroupBox gb;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.TextBox accountno;
        private System.Windows.Forms.Label label8;
    }
}
