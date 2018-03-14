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
    public partial class FeatureControl : UserControl
    {
        private string[] movieInfo = new string[5];
        private int x = 0;
        private static FeatureControl _instance;

        public static FeatureControl Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new FeatureControl();
                return _instance;
            }
        }
        public FeatureControl()
        {
            InitializeComponent();
        }

        private void FeatureControl_Load(object sender, EventArgs e)
        {
            FillData();
        }

        private void FillData()
        {
            string[] filename = { "", "god father", "mad max", "mary and max", "The love witch" };
            SqlConnection connection = new SqlConnection(Form4.connectionString);
            connection.Open();
            SqlDataAdapter a = new SqlDataAdapter("SELECT MovieName, Director, MovieType, ReleaseDate, AddDate FROM Movie WHERE " +
                "ReleaseDate like '" + "2017%" + "'" + "or ReleaseDate like '" + "2018%'", connection);
            DataTable t = new DataTable();
            a.Fill(t);
            int i = 1;

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
                newGroupBox.setGroupBox(MoviePanel, i);
                i++;
                //Console.WriteLine(movieInfo[3].Trim());
                var releaseDate = movieInfo[3].Substring(0, movieInfo[3].IndexOf(' '));
                var addDate = movieInfo[4].Substring(0, movieInfo[4].IndexOf(' '));
                newGroupBox.setImage(newGroupBox.groupBox, filename[1]);
                newGroupBox.setMovieInfo(newGroupBox.groupBox, movieInfo[0], movieInfo[1], movieInfo[2], releaseDate, addDate);

            }
        }
    }
}
