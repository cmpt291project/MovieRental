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
    public partial class Like : UserControl
    {
        private static Like _instance;
        public static Like Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Like();
                return _instance;
            }
        }
        public Like()
        {
            InitializeComponent();
        }

        private void Like_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(Form4.connectionString);
            connection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select top 5 M.MID, M.MovieName, (select AVG(rating) from MovieRating mr where mr.MID = M.MID ) rate from (select MovieType, O.MID from[Order] O, Movie M where CID = '" + UC1.id +"' and O.MID = M.MID) T, Movie M where M.MovieType = T.MovieType and T.MID != M.MID Order by NEWID()", connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            int i = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                //foreach (DataColumn column in dataTable.Columns)
                //{
                MovieBoxRent movieBoxRent = new MovieBoxRent(row["MID"].ToString());
                movieBoxRent.createNewBox(panelinlike, i);
                //MessageBox.Show(row["MID"].ToString().Trim());
                movieBoxRent.CreatePicture(row["MID"].ToString().Trim());
                movieBoxRent.CreateName(row["MovieName"].ToString());
                //MessageBox.Show(row["MovieName"].ToString());
                movieBoxRent.CreateScore(row["rate"].ToString());
                movieBoxRent.CreateButtonRent();
                Console.WriteLine(row["MovieName"]);
                i++;
                //}
            }
            connection.Close();
        }
    }
}
