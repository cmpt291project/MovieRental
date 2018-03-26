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

namespace MovieRental
{
    public partial class YourMovieControl : UserControl
    {
        private static YourMovieControl _instance;
        private string[] movieInfo = new string[6];
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
            Label label = new Label();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            YourMoviePanel2.Controls.Clear();
            list.Clear();
            SqlConnection connection = new SqlConnection(Form4.connectionString);
            connection.Open();
            SqlDataAdapter a = new SqlDataAdapter("SELECT MovieName, Director, MovieType, ReleaseDate, AddDate, M.MID FROM [Order] as O, Movie as M WHERE M.MID = O.MID and O.CID = '" + UC1.id + "' and O.ActualReturnDate is null", connection);
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
                    //Console.WriteLine(row[column]);
                }
                x = 0;
                MovieGroupBox newGroupBox = new MovieGroupBox();
                newGroupBox.setGroupBox(YourMoviePanel2, i);
                i++;
                var releaseDate = movieInfo[3].Substring(0, movieInfo[3].IndexOf(' '));
                var addDate = movieInfo[4].Substring(0, movieInfo[4].IndexOf(' '));
                newGroupBox.SetReturnButton(newGroupBox.groupBox, "ReturnMovie");
                newGroupBox.setImage(newGroupBox.groupBox, movieInfo[5].ToString().Trim());
                newGroupBox.setMovieInfo(newGroupBox.groupBox, movieInfo[0], movieInfo[1], movieInfo[2], releaseDate, addDate, movieInfo[5].ToString());
                list.Add(newGroupBox);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            YourMoviePanel2.Controls.Clear();
            list.Clear();
            SqlConnection connection = new SqlConnection(Form4.connectionString);
            connection.Open();
            SqlDataAdapter a = new SqlDataAdapter("SELECT MovieName, Director, MovieType, ReleaseDate, AddDate, M.MID FROM [Order] O, Movie as M WHERE M.MID = O.MID and O.CID ='" + UC1.id + "'", connection);
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
                    //Console.WriteLine(row[column]);
                }
                x = 0;
                MovieGroupBox newGroupBox = new MovieGroupBox();
                newGroupBox.setGroupBox(YourMoviePanel2, i);
                i++;
                var releaseDate = movieInfo[3].Substring(0, movieInfo[3].IndexOf(' '));
                var addDate = movieInfo[4].Substring(0, movieInfo[4].IndexOf(' '));

                newGroupBox.setImage(newGroupBox.groupBox, movieInfo[5].ToString().Trim());
                newGroupBox.setMovieInfo(newGroupBox.groupBox, movieInfo[0], movieInfo[1], movieInfo[2], releaseDate, addDate, movieInfo[5].ToString());
                list.Add(newGroupBox);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            YourMoviePanel2.Controls.Clear();
            list.Clear();
            SqlConnection connection = new SqlConnection(Form4.connectionString);
            connection.Open();
            SqlDataAdapter a = new SqlDataAdapter("SELECT distinct (MovieName), Director, MovieType, ReleaseDate, AddDate, M.MID FROM MovieQueue as MQ, Movie as M WHERE M.MID = MQ.MID and MQ.CID ='" + UC1.id + "'", connection);
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
                    //Console.WriteLine(row[column]);
                }
                x = 0;
                MovieGroupBox newGroupBox = new MovieGroupBox();
                newGroupBox.setGroupBox(YourMoviePanel2, i);
                i++;
                var releaseDate = movieInfo[3].Substring(0, movieInfo[3].IndexOf(' '));
                var addDate = movieInfo[4].Substring(0, movieInfo[4].IndexOf(' '));

                newGroupBox.setImage(newGroupBox.groupBox, movieInfo[5].ToString().Trim());
                newGroupBox.setMovieInfo(newGroupBox.groupBox, movieInfo[0], movieInfo[1], movieInfo[2], releaseDate, addDate, movieInfo[5].ToString());
                newGroupBox.SetChooseMovieButton(newGroupBox.groupBox, "Rent");
                newGroupBox.DeleteMovieFromListButton(newGroupBox.groupBox, "Delete");
                list.Add(newGroupBox);
            }
            
        }
    }
}
