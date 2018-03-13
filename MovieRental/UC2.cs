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
    public partial class UC2 : UserControl
    {
        private string[] movieInfo = new string[5];
        private int x = 0;
        private static UC2 _instance;
        public static UC2 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UC2();
                return _instance;
            }
        }
        public UC2()
        {
            InitializeComponent();
            FillData();
        }

        private void UC2_Load(object sender, EventArgs e)
        {
            MessageBox.Show(UC1.info);
        }

        

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            

        }

        private void button5_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] filename = { "", "god father", "mad max", "mary and max", "The love witch" };
            for (int i = 1; i < 5; i++)
            {
                MovieGroupBox newGroupBox = new MovieGroupBox();
                newGroupBox.setGroupBox(YourMoviePanel, i);
                newGroupBox.setImage(newGroupBox.groupBox, filename[i]);
                newGroupBox.setMovieInfo(newGroupBox.groupBox, "God", "Nick", "Bento Box", "2018-02-11", "2018-05-03");
            }
            
        }

        private void Features_Click(object sender, EventArgs e)
        {

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
                //Console.Write("row data: " + movieInfo.Length);
                MovieGroupBox newGroupBox = new MovieGroupBox();
                newGroupBox.setGroupBox(panel2, i);
                i++;
                Console.WriteLine(movieInfo[3].Trim());
                var releaseDate = movieInfo[3].Substring(0, movieInfo[3].IndexOf(' '));
                var addDate = movieInfo[4].Substring(0, movieInfo[4].IndexOf(' '));
                newGroupBox.setImage(newGroupBox.groupBox, filename[1]);
                newGroupBox.setMovieInfo(newGroupBox.groupBox, movieInfo[0], movieInfo[1], movieInfo[2], releaseDate, addDate);
                
            }
            /*for (int i = 1; i < 5; i++)
            {
                MovieGroupBox newGroupBox = new MovieGroupBox();
                newGroupBox.setGroupBox(Features, i);
                newGroupBox.setImage(newGroupBox.groupBox, filename[i]);
                newGroupBox.setMovieInfo(newGroupBox.groupBox, "God", "Nick", "Bento Box", "2018-02-11", "2018-05-03");
            }*/
        }

        public static void ClearAll(Control control)
        {
            foreach (Control c in control.Controls)
            {
                var texbox = c as TextBox;
                var comboBox = c as ComboBox;
                var dateTimePicker = c as DateTimePicker;

                if (texbox != null)
                    texbox.Clear();
                if (comboBox != null)
                    comboBox.SelectedIndex = -1;
                if (dateTimePicker != null)
                {
                    dateTimePicker.Format = DateTimePickerFormat.Short;
                    dateTimePicker.CustomFormat = " ";
                }
                if (c.HasChildren)
                    ClearAll(c);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ClearAll(panel2);
        }

        private void Suggestion_Click(object sender, EventArgs e)
        {

        }
    }
}
