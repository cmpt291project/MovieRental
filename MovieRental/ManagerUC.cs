using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;

namespace MovieRental
{
    public partial class ManagerUC : UserControl
    {
        private static ManagerUC _instance;
        public static ManagerUC Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ManagerUC();
                return _instance;
            }
        }

        public ManagerUC()
        {
            InitializeComponent();
        }

        private void ManagerUC_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/yyyy";
            dateTimePicker1.ShowUpDown = true;
        }

        private void GetRevenue_Click(object sender, EventArgs e)
        {
            GetSubRevenue();
        }

        private void GetSubRevenue()
        {
            Console.WriteLine(dateTimePicker1.Text);
            char[] delimiterChars = { '/' };
            string[] dateStrings = dateTimePicker1.Text.Split(delimiterChars);
            Console.WriteLine(dateStrings[0] + " " + dateStrings[1]);
            string queryDate = dateStrings[1] + "-01-" + dateStrings[0];
            Console.WriteLine(queryDate);
            SqlConnection connection = new SqlConnection(Form4.connectionString);
            connection.Open();
            SqlDataAdapter a = new SqlDataAdapter("SELECT sum(MonthlyFee) as Revenue from (select C.AccountType, R.MonthlyFee from Customer as C, RentalPlan as R where AccountCreationDate <='" + queryDate + "' and C.AccountType = R.AccountType) as Fees", connection);
            DataTable t = new DataTable();
            a.Fill(t);
            DataGridView.DataSource = t;

            connection.Close();
        }

        private void CompareDates()
        {
            DateTime localDate = DateTime.Now;
            String[] cultureNames = { "en-US", "en-GB", "fr-FR",
                                "de-DE", "ru-RU" };

            /*foreach (var cultureName in cultureNames)
            {
                var culture = new CultureInfo(cultureName);
                Console.WriteLine("{0}: {1}", cultureName,
                                  localDate.ToString(culture));
            }*/
            var culture = new CultureInfo("en-US");
            //Console.WriteLine("Local date/time: " + localDate.ToString(culture));

            SqlConnection connection = new SqlConnection(Form4.connectionString);
            connection.Open();
            SqlCommand a = new SqlCommand("SELECT AccountCreationDate FROM Customer WHERE AccountNumber = '748792'", connection);
            string joinDate = a.ExecuteScalar().ToString();
            string currentDate = localDate.ToString(culture);
            Console.WriteLine("date from DB: " + joinDate + " current date: " + currentDate);

            char[] delimiterChars = { ' ', '/' };
            string[] joinDateStrings = joinDate.Split(delimiterChars);
            string[] currentDateStrings = currentDate.Split(delimiterChars);
            if (currentDate[0] - joinDate[0] == 1)
                Console.WriteLine("TIME TO PAY UP");

            connection.Close();
        }

        private void GetMovies_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(Form4.connectionString);
            connection.Open();
            SqlDataAdapter a = new SqlDataAdapter("SELECT * from Movie", connection);
            DataTable t = new DataTable();
            a.Fill(t);
            DataGridView.DataSource = t;

            connection.Close();
        }


        private void DataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine("HELLO");
        }
    }
}
