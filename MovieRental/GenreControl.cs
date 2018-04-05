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
using System.IO;

namespace MovieRental
{
    public partial class GenreControl : UserControl
    {
        private static GenreControl _instance;
        public static GenreControl Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GenreControl();
                return _instance;
            }
        }
        public GenreControl()
        {
            InitializeComponent();
        }

        private void GenreControl_Load(object sender, EventArgs e)
        {
            initialDisplay();
            Drama.Click += new EventHandler(Genre_Click);
            Thriller.Click += new EventHandler(Genre_Click);
            Adventure.Click += new EventHandler(Genre_Click);
            Action.Click += new EventHandler(Genre_Click);
            Comedy.Click += new EventHandler(Genre_Click);
            Horror.Click += new EventHandler(Genre_Click);
        }

        public void Genre_Click(object sender, EventArgs e) {
            LinkLabel lb = (LinkLabel)sender;
            //MessageBox.Show(lb.Name);
            panelInGerneControl.Controls.Clear();
            SqlConnection connection = new SqlConnection(Form4.connectionString);
            connection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select M.MovieName, Poster, M.MID,rate from Movie M left join (Select AVG(Rating) as rate, MID from MovieRating Group by MID) T ON M.MID = T.MID where M.MovieType = '"+ lb.Name.ToString() +"'", connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            int i = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                //foreach (DataColumn column in dataTable.Columns)
                //{
                MovieBoxRent movieBoxRent = new MovieBoxRent(row["MID"].ToString());
                movieBoxRent.createNewBox(panelInGerneControl, i,0);
                //MessageBox.Show(row["MID"].ToString().Trim());
                if (row["Poster"] == DBNull.Value)
                {
                    //MessageBox.Show("image null");
                    //MemoryStream ms = new MemoryStream((byte[])Properties.Resources.ResourceManager.GetObject("001"));
                    movieBoxRent.CreatePictureImage((Image)Properties.Resources.ResourceManager.GetObject("Noimage"));
                }
                else
                {
                    byte[] ImageArray = (byte[])row["Poster"];
                    Image image = Image.FromStream(new MemoryStream(ImageArray));

                    movieBoxRent.CreatePictureImage(image);
                }
                //movieBoxRent.CreatePicture(row["MID"].ToString().Trim());
                movieBoxRent.CreateName(row["MovieName"].ToString());
                //MessageBox.Show(row["MovieName"].ToString());
                movieBoxRent.CreateScore(row["rate"].ToString());
                movieBoxRent.CreateButtonRent();
                //Console.WriteLine(row["MovieName"]);
                i++;
                //}
            }
            connection.Close();

        }

        public void initialDisplay() {
            SqlConnection connection = new SqlConnection(Form4.connectionString);
            connection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select top 5 MovieName, M.MID, rate, Poster from(Select AVG(Rating) as rate, MID from MovieRating Group by MID) as T, Movie M where T.MID = M.MID Order by NEWID()", connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            int i = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                //foreach (DataColumn column in dataTable.Columns)
                //{
                MovieBoxRent movieBoxRent = new MovieBoxRent(row["MID"].ToString());
                movieBoxRent.createNewBox(panelInGerneControl, i,0);
                //MessageBox.Show(row["MID"].ToString().Trim());
                if (row["Poster"] == DBNull.Value)
                {
                    //MessageBox.Show("image null");
                    //MemoryStream ms = new MemoryStream((byte[])Properties.Resources.ResourceManager.GetObject("001"));
                    movieBoxRent.CreatePictureImage((Image)Properties.Resources.ResourceManager.GetObject("Noimage"));
                }
                else
                {
                    byte[] ImageArray = (byte[])row["Poster"];
                    Image image = Image.FromStream(new MemoryStream(ImageArray));

                    movieBoxRent.CreatePictureImage(image);
                }
                //movieBoxRent.CreatePicture(row["MID"].ToString().Trim());
                movieBoxRent.CreateName(row["MovieName"].ToString());
                //MessageBox.Show(row["MovieName"].ToString());
                movieBoxRent.CreateScore(row["rate"].ToString());
                movieBoxRent.CreateButtonRent();
                //Console.WriteLine(row["MovieName"]);
                i++;
                //}
            }
            connection.Close();
        }

        private void Horror_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
