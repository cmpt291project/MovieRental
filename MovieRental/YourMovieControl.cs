using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MovieRental
{
    public partial class YourMovieControl : UserControl
    {
        private static YourMovieControl _instance;
        private string[] movieInfo = new string[10];
        private List<MovieGroupBox> list = new List<MovieGroupBox>();

        public static YourMovieControl Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new YourMovieControl();
                return _instance;
            }
        }
        public YourMovieControl()
        {
            InitializeComponent();
        }

        private void YourMovieControl_Load(object sender, EventArgs e)
        {
            createWishList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            createCurrentRental();
        }

        public void createCurrentRental()
        {
            YourMoviePanel2.Controls.Clear();
            list.Clear();
            SqlConnection connection = new SqlConnection(Form4.connectionString);
            connection.Open();
            SqlDataAdapter a = new SqlDataAdapter("SELECT MovieName, Director, MovieType, ReleaseDate, AddDate, M.MID, Poster FROM [Order] as O, Movie as M WHERE M.MID = O.MID and O.CID = '" + UC1.id + "' and O.ActualReturnDate is null", connection);
            DataTable t = new DataTable();
            a.Fill(t);
            int i = 1;
            int x = 0;
            bool empty = true;
            foreach (DataRow row in t.Rows)
            {
                foreach (DataColumn column in t.Columns)
                {
                    movieInfo[x] = row[column].ToString();
                    x++;

                }
                x = 0;
                MovieGroupBox newGroupBox = new MovieGroupBox();
                newGroupBox.setGroupBox(YourMoviePanel2, i);
                i++;
                var releaseDate = movieInfo[3].Substring(0, movieInfo[3].IndexOf(' '));
                var addDate = movieInfo[4].Substring(0, movieInfo[4].IndexOf(' '));
                newGroupBox.SetReturnButton(newGroupBox.groupBox, "ReturnMovie");

                Byte[] data = new Byte[0];
                data = (Byte[])(row["Poster"]);
                Image image = Image.FromStream(new MemoryStream(data));
                newGroupBox.setImage(newGroupBox.groupBox, image);
                newGroupBox.setMovieInfo(newGroupBox.groupBox, movieInfo[0], movieInfo[1], movieInfo[2], releaseDate, addDate, movieInfo[5].ToString());
                list.Add(newGroupBox);
                empty = false;
            }
            if (empty == true)
            {
                Label emptyLabel = new Label();
                emptyLabel.Location = new Point(50, 100);
                emptyLabel.Font = new Font("Segoe UI", 24);
                emptyLabel.Text = "There is no rented movie currently.";
                emptyLabel.AutoSize = true;
                YourMoviePanel2.Controls.Add(emptyLabel);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            YourMoviePanel2.Controls.Clear();
            list.Clear();
            createRentalHistory();
        }

        private void createRentalHistory()
        {
            SqlConnection connection = new SqlConnection(Form4.connectionString);
            connection.Open();
            SqlDataAdapter a = new SqlDataAdapter("SELECT MovieName, Director, MovieType, ReleaseDate, AddDate, M.MID, Poster FROM [Order] O, Movie as M WHERE M.MID = O.MID and O.CID ='" + UC1.id + "'", connection);
            DataTable t = new DataTable();
            a.Fill(t);
            int i = 1;
            int x = 0;
            foreach (DataRow row in t.Rows)
            {
                foreach (DataColumn column in t.Columns)
                {
                    movieInfo[x] = row[column].ToString();
                    x++;
                }
                x = 0;
                MovieGroupBox newGroupBox = new MovieGroupBox();
                newGroupBox.setGroupBox(YourMoviePanel2, i);
                i++;
                var releaseDate = movieInfo[3].Substring(0, movieInfo[3].IndexOf(' '));
                var addDate = movieInfo[4].Substring(0, movieInfo[4].IndexOf(' '));
                Byte[] data = new Byte[0];
                data = (Byte[])(row["Poster"]);
                Image image = Image.FromStream(new MemoryStream(data));
                newGroupBox.setImage(newGroupBox.groupBox, image);
                newGroupBox.setMovieInfo(newGroupBox.groupBox, movieInfo[0], movieInfo[1], movieInfo[2], releaseDate, addDate, movieInfo[5].ToString());
                list.Add(newGroupBox);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            createWishList();
        }

        public void createWishList()
        {
            YourMoviePanel2.Controls.Clear();
            list.Clear();
            SqlConnection connection = new SqlConnection(Form4.connectionString);
            connection.Open();
            SqlDataAdapter a = new SqlDataAdapter("SELECT MovieName, Director, MovieType, ReleaseDate, AddDate, M.MID, Poster FROM MovieQueue as MQ, Movie as M WHERE M.MID = MQ.MID and MQ.CID ='" + UC1.id + "'", connection);
            DataTable t = new DataTable();
            a.Fill(t);
            int i = 1;
            int x = 0;
            bool empty = true;
            foreach (DataRow row in t.Rows)
            {
                foreach (DataColumn column in t.Columns)
                {
                    movieInfo[x] = row[column].ToString();
                    x++;
                }
                x = 0;
                MovieGroupBox newGroupBox = new MovieGroupBox();
                newGroupBox.setGroupBox(YourMoviePanel2, i);
                i++;
                var releaseDate = movieInfo[3].Substring(0, movieInfo[3].IndexOf(' '));
                var addDate = movieInfo[4].Substring(0, movieInfo[4].IndexOf(' '));
                Byte[] data = new Byte[0];
                data = (Byte[])(row["Poster"]);
                Image image = Image.FromStream(new MemoryStream(data));
                newGroupBox.setImage(newGroupBox.groupBox, image);
                newGroupBox.setMovieInfo(newGroupBox.groupBox, movieInfo[0], movieInfo[1], movieInfo[2], releaseDate, addDate, movieInfo[5].ToString());
                newGroupBox.SetChooseMovieButton(newGroupBox.groupBox, "Rent");
                newGroupBox.SetIndex(newGroupBox.groupBox,i-1);
                newGroupBox.DeleteMovieFromListButton(newGroupBox.groupBox, "Delete");
                empty = false;
            }
            if (empty == true)
            {
                Label emptyLabel = new Label();
                emptyLabel.Location = new Point(100, 100);
                emptyLabel.Font = new Font("Arial", 20);
                emptyLabel.Text = "Wish List is empty.";
                emptyLabel.AutoSize = true;
                YourMoviePanel2.Controls.Add(emptyLabel);
            }
        }
    }
}
