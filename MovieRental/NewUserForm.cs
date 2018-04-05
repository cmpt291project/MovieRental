using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MovieRental
{
    public partial class NewUserForm : Form
    {
        public NewUserForm()
        {
            InitializeComponent();
        }

        private void NewUserForm_Load(object sender, EventArgs e) {

            //Telephone.KeyPress += new KeyPressEventHandler(text_KeyPress);
            //CreditCardNumber.KeyPress += new KeyPressEventHandler(text_KeyPress);
        }

        private bool inputValid(string s, ErrorProvider ep, TextBox tb)
        {
            s.Trim();
            if (s.Contains("'") || s == "" || s == "NULL")
            {
                ep.SetError(tb, "Please do not put NULL, ' or leave the field empty."); 
                return false;
            }
            ep.Dispose();
            return true;
        }

        private bool checkEmail(string email)
        {
            if (!inputValid(email, emailerror, EmailAddress))
            {
                return false;
            }
            if (!(EmailAddress.Text.Contains('@') && EmailAddress.Text.Contains('.')))
            {
                emailerror.SetError(EmailAddress, "This email not valid.");
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

            if (countat > 1 || countdot > 1)
            {
                emailerror.SetError(EmailAddress, "This email not valid.");
                return false;
            }

            SqlConnection connection = new SqlConnection(Form4.connectionString);
            connection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select CID from Customer where EmailAddress = '" + EmailAddress.Text + "' and CID != '" + UC1.id + "'", connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                MessageBox.Show("email exist.");
                connection.Close();
                emailerror.SetError(EmailAddress, "This email already registered.");
                return false;
            }
            connection.Close();
            emailerror.Dispose();
            return true;
        }

        private void submit_Click(object sender, EventArgs e)
        {
            if (inputValid(FirstName.Text, firstnameError, FirstName)
                && checkPlan() && inputValid(LastName.Text, lastnameError, LastName)
                && inputValid(Street.Text, sterror, Street)
                && inputValid(City.Text, cterror, City)
                && inputValid(State.Text, staerror, State) && inputValid(ZipCode.Text, ziperror, ZipCode)
                && inputValid(Telephone.Text, telerror, Telephone)
                && checkEmail(EmailAddress.Text) && inputValid(CreditCardNumber.Text, crederror, CreditCardNumber) && inputValid(pass.Text, passerror, pass))
            {
                //MessageBox.Show("success");
                SqlConnection connection = new SqlConnection(Form4.connectionString);
                connection.Open();

                string sqlcid = "Select MAX(CAST(CID as int))+1 as cid from [Customer]";
                SqlDataAdapter findcid = new SqlDataAdapter(sqlcid, connection);
                DataTable dt = new DataTable();
                findcid.Fill(dt);
                string newcid = dt.Rows[0]["cid"].ToString().Trim();


                string insert = "INSERT dbo.[Customer](CID, LastName,FirstName, Street, City, State, ZipCode, Telephone, EmailAddress,AccountNumber, AccountType, AccountCreationDate,CreditCardNumber)  " +
                    "VALUES((Select MAX(CAST(CID as int))+1 from [Customer]), @fn, @ln, @st, @ct, @sta, @zip, @tel, @email, @accnum, @accty, @accdate, @crd)";
                SqlCommand sc = new SqlCommand(insert, connection);
                //sc.Parameters.AddWithValue("@oid", "006");
                DateTime date = DateTime.Today;
                sc.Parameters.AddWithValue("@accdate", date.ToString("d"));

                var checkedButton = panel1.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);
                sc.Parameters.AddWithValue("@accty", checkedButton.Text);

                string acc = genAcc();
                sc.Parameters.AddWithValue("@accnum", acc);

                
                sc.Parameters.AddWithValue("@fn", FirstName.Text);
                sc.Parameters.AddWithValue("@ln", LastName.Text);
                sc.Parameters.AddWithValue("@st", Street.Text);
                sc.Parameters.AddWithValue("@ct", City.Text);
                sc.Parameters.AddWithValue("@sta", State.Text);
                sc.Parameters.AddWithValue("@zip", ZipCode.Text);
                sc.Parameters.AddWithValue("@tel", Telephone.Text);
                sc.Parameters.AddWithValue("@email", EmailAddress.Text);
                sc.Parameters.AddWithValue("@crd", CreditCardNumber.Text);
                //sc.Parameters.AddWithValue("@actual", null);
                sc.ExecuteNonQuery();

                string sqlpass = "INSERT dbo.[Password](EmailAddress, Password, CID, UserType)  " +
                    "VALUES( @email, @pas, @cid, 'c')";
                SqlCommand inspass = new SqlCommand(sqlpass, connection);
                inspass.Parameters.AddWithValue("@email", EmailAddress.Text);
                inspass.Parameters.AddWithValue("@pas", pass.Text);
                inspass.Parameters.AddWithValue("@cid", newcid);
                //string s = "c";
                //inspass.Parameters.AddWithValue("@user", s);
                inspass.ExecuteNonQuery();

                MessageBox.Show("Account created. Your default password is your firstname. Please change it as soon as possible. Now please log in.");
                this.Dispose();
            }
            
        }

        private bool checkPlan() {
            var checkedButton = panel1.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);
            if (checkedButton == null)
            {
                planerror.SetError(label9, "no plan choosed");
                return false;
            }
            planerror.Dispose();
            return true;
        }

        private string genAcc() {
            Random random = new Random();
            const string valid = "1234567890";
            char[] newacc = new char[6];
            for (int i = 0; i < newacc.Length; i++)
            {
                newacc[i] = valid[random.Next(0, valid.Length)];
            }
            string c = new string(newacc);
            while (checkacc(c) == false)
            {
                newacc = new Char[6];
                for (int i = 0; i < newacc.Length; i++)
                {
                    newacc[i] = valid[random.Next(0, valid.Length)];
                }
                c = new string(newacc);
            }
            return c;
        }

        private bool checkacc(string acc) {
            SqlConnection connection = new SqlConnection(Form4.connectionString);
            connection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select CID from Customer where AccountNumber = '" + acc + "' and CID != '" + UC1.id + "'", connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                //MessageBox.Show("email exist.");
                connection.Close();
                //emailerror.SetError(EmailAddress, "This email already registered.");
                return false;
            }
            connection.Close();
            return true;
        }

        private void Telephone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void CreditCardNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void NewUserForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
