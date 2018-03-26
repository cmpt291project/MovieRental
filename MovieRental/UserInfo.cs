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
            SqlConnection connection = new SqlConnection(Form4.connectionString);
            connection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from Customer C Where C.CID = '"+ UC1.id +"'", connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            FirstName.Text = dataTable.Rows[0]["FirstName"].ToString();
            LastName.Text = dataTable.Rows[0]["LastName"].ToString();
            Street.Text = dataTable.Rows[0]["Street"].ToString();
            City.Text = dataTable.Rows[0]["City"].ToString();
            State.Text = dataTable.Rows[0]["State"].ToString();
            ZipCode.Text = dataTable.Rows[0]["ZipCode"].ToString();
            Telephone.Text = dataTable.Rows[0]["Telephone"].ToString();
            EmailAddress.Text = dataTable.Rows[0]["EmailAddress"].ToString();
            CreditCardNumber.Text = dataTable.Rows[0]["CreditCardNumber"].ToString();
            AccountCreationDate.Text = dataTable.Rows[0]["AccountCreationDate"].ToString();
            connection.Close();
        }
    }
}
