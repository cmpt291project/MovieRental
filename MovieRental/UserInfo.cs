using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace MovieRental
{
    public partial class UserInfo : UserControl
    {
        private static UserInfo _instance;
        public static UserInfo Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserInfo();
                return _instance;
            }
        }
        public UserInfo()
        {
            InitializeComponent();
        }

        private void UserInfo_Load(object sender, EventArgs e)
        {
            changeCheckBoxState(false);
            changeFieldState(false);
            confirm.Enabled = false;
            modify.Enabled = true;
            save.Enabled = false;
            edit.Enabled = true;
            SqlConnection connection = new SqlConnection(Form4.connectionString);
            connection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from Customer C Where C.CID = '" + UC1.id + "'", connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            //set information in text field
            userInfoLoad(dataTable);
            //set check box
            grpBox_Validated(dataTable);

            connection.Close();
            //groupBox1.Click += new EventHandler(grpBox_Validated);                        
        }

        private void grpBox_Validated(DataTable dt)
        {
            // GroupBox g = sender as GroupBox;
            var a = (from RadioButton r in gb.Controls where r.Text == dt.Rows[0]["AccountType"].ToString().Trim() select r.Checked = true).FirstOrDefault();
            
            
            //var selectedRb = (from rb in buttons where rb.Checked == true select rb).FirstOrDefault();
            //MessageBox.Show(checkedButton.Text);
           // strChecked = a.First();
        }
        private void userInfoLoad( DataTable dataTable) {
            
            if (dataTable.Rows.Count > 0)
            {
                FirstName.Text = dataTable.Rows[0]["FirstName"].ToString().Trim();
                LastName.Text = dataTable.Rows[0]["LastName"].ToString().Trim();
                Street.Text = dataTable.Rows[0]["Street"].ToString().Trim();
                City.Text = dataTable.Rows[0]["City"].ToString().Trim();
                State.Text = dataTable.Rows[0]["State"].ToString().Trim();
                ZipCode.Text = dataTable.Rows[0]["ZipCode"].ToString().Trim();
                Telephone.Text = dataTable.Rows[0]["Telephone"].ToString().Trim();
                EmailAddress.Text = dataTable.Rows[0]["EmailAddress"].ToString().Trim();
                CreditCardNumber.Text = dataTable.Rows[0]["CreditCardNumber"].ToString().Trim();
                DateTime dt = (DateTime)dataTable.Rows[0]["AccountCreationDate"];
                AccountCreationDate.Text = dt.ToString("d");
                accountno.Text = dataTable.Rows[0]["AccountNumber"].ToString();

            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            changeFieldState(true);
            save.Enabled = true;
            edit.Enabled = false;

        }

        private void changeFieldState(bool st) {
            FirstName.Enabled = st;
            LastName.Enabled = st;
            Street.Enabled = st;
            City.Enabled = st;
            State.Enabled = st;
            ZipCode.Enabled = st;
            Telephone.Enabled = st;
            EmailAddress.Enabled = st;
            CreditCardNumber.Enabled = st;
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (inputValid(FirstName.Text) && inputValid(LastName.Text)&& inputValid(Street.Text)&& inputValid(City.Text) && inputValid(State.Text) && inputValid(ZipCode.Text)&& inputValid(Telephone.Text) && checkEmail(EmailAddress.Text) && inputValid(CreditCardNumber.Text))
            {
                MessageBox.Show("New information saved.");
                SqlConnection connection = new SqlConnection(Form4.connectionString);
                connection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from Customer C Where C.CID = '" + UC1.id + "'", connection);
                DataTable userTable = new DataTable();
                dataAdapter.Fill(userTable);
                userTable.Rows[0].BeginEdit();


                userTable.Rows[0]["FirstName"] = FirstName.Text.Trim();
                userTable.Rows[0]["LastName"] = LastName.Text.Trim();
                userTable.Rows[0]["Street"] = Street.Text.Trim();
                userTable.Rows[0]["City"] = City.Text.Trim();
                userTable.Rows[0]["State"] = State.Text.Trim();
                userTable.Rows[0]["ZipCode"] = ZipCode.Text.Trim();
                userTable.Rows[0]["Telephone"] = Telephone.Text.Trim();
                userTable.Rows[0]["EmailAddress"] = EmailAddress.Text.Trim();
                userTable.Rows[0]["CreditCardNumber"] = CreditCardNumber.Text.Trim();

                userTable.Rows[0].EndEdit();
                //userTable.Rows[0].EndEdit();
                SqlCommandBuilder sb = new SqlCommandBuilder(dataAdapter);
                dataAdapter.Update(userTable);
                connection.Close();
            
                save.Enabled = false;
                edit.Enabled = true;

                changeFieldState(false);
            }
            else
            {
                MessageBox.Show("Invalid Input! Please do not input ', NULL or leave any field empty.");
            }
            

        }

        private bool inputValid(string s) {
            s.Trim();
            if (s.Contains("'") || s == "" || s == "NULL")
            {
                return false;
            }
            return true;
        }

        private bool checkEmail(string email) {
            if (!inputValid(email))
            {
                return false;
            }
            if (!(EmailAddress.Text.Contains('@') && EmailAddress.Text.Contains('.')))
            {
                MessageBox.Show("email not valid");
                return false;
            }
            int countat = 0;
            int countdot = 0;
            foreach (char c in EmailAddress.Text)
            {
                if (c == '@')
                {
                    countat++;
                }

                if (c == '.')
                {
                    countdot++;
                }
            }

            if (countat > 1 || countdot > 1) {
                MessageBox.Show("email not valid");
                return false;
            }

            SqlConnection connection = new SqlConnection(Form4.connectionString);
            connection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select CID from Customer where EmailAddress = '" + EmailAddress.Text + "' and CID != '" + UC1.id + "'", connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);            
            if (dataTable.Rows.Count > 0)
            {
                MessageBox.Show("email already registered by other customer.");
                connection.Close();
                return false;
            }

            return true;
        }

        private void changeCheckBoxState(bool b) {
            limited.Enabled = b;
            unlimited1.Enabled = b;
            unlimited2.Enabled = b;
            unlimited3.Enabled = b;
        }

        private void modify_Click(object sender, EventArgs e)
        {
            confirm.Enabled = true;
            changeCheckBoxState(true);
            modify.Enabled = false;
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(Form4.connectionString);
            connection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from Customer C Where C.CID = '" + UC1.id + "'", connection);
            DataTable userTable = new DataTable();
            dataAdapter.Fill(userTable);
            userTable.Rows[0].BeginEdit();
            var checkedButton = gb.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);
            userTable.Rows[0]["AccountType"] = checkedButton.Text;

            userTable.Rows[0].EndEdit();
           
            SqlCommandBuilder sb = new SqlCommandBuilder(dataAdapter);
            dataAdapter.Update(userTable);
            connection.Close();

            confirm.Enabled = false;
            modify.Enabled = true;

            changeCheckBoxState(false);

            MessageBox.Show("Your new plan will start from next month.");
        }

      /*  private void EmailAddress_TextChanged(object sender, EventArgs e)
        {
            if (EmailAddress.Text.Contains('@') && EmailAddress.Text.Contains('.'))
            {

            }
        }*/

        private void Telephone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void CreditCardNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
