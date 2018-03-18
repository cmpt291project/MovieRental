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
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select distinct top 5 O.MID, M.MovieType, M.MID as mm, M.MovieName, T.rate from[Order] as O, Movie as M, (Select AVG(Rating) as rate, MID from MovieRating Group by MID) as T where CID = '" + UC1.id + "' and O.MID = M.MID and M.MID = T.MID", connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            int i = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                //foreach (DataColumn column in dataTable.Columns)
                //{
                MovieBoxRent movieBoxRent = new MovieBoxRent(row["mm"].ToString());
                movieBoxRent.createNewBox(panelinlike, i);
                //MessageBox.Show(row["MID"].ToString().Trim());
                movieBoxRent.CreatePicture(row["mm"].ToString().Trim());
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
