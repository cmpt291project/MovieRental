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
using System.Configuration;

namespace MovieRental
{


    public partial class Form2 : Form
    {
        string connectionString;
        public Form2()
        {
            InitializeComponent();
            
            connectionString = ConfigurationManager.
                ConnectionStrings["MovieRental.Properties." +
                "Settings.MovieRentalConnectionString"].ConnectionString;
            FillFeatureTabData();
        }

        void FillData()
        {

            //string connectionString = "Data Source=DESKTOP-V2MG4LO;Initial Catalog=MovieRental;Integrated Security=True";
            //var cs = System.Configuration.ConfigurationManager.
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            //Console.WriteLine("SELECT * FROM Actor WHERE FirstName=" + textBox1.Text);

            SqlDataAdapter a = new SqlDataAdapter("SELECT FirstName, LastName FROM Actor WHERE FirstName ='" + textBox1.Text + "'", connection);

            DataTable t = new DataTable();
            a.Fill(t);
            dataGridView1.DataSource = t;
            connection.Close();
        }

        void FillFeatureTabData()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlDataAdapter a = new SqlDataAdapter("SELECT MovieName, MovieType FROM Movie WHERE " +
                "ReleaseDate like '" + "2017%" + "'" + "or ReleaseDate like '" + "2018%'", connection);
            DataTable t = new DataTable();
            a.Fill(t);
            foreach (DataRow row in t.Rows)
            {
                foreach (DataColumn column in t.Columns)
                {
                    Console.WriteLine(row[column]);
                }
            }
            //Console.WriteLine(a);
            dataGridView2.DataSource = t;
            connection.Close();

        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                FillData();
                Console.WriteLine(tabControl1.SelectedIndex);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(
            System.Reflection.Assembly.GetEntryAssembly().
            GetManifestResourceStream("MyProject.Resources.myimage.png"));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(comboBox1.Text);
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            //Console.WriteLine("SELECT * FROM Actor WHERE FirstName=" + textBox1.Text);

            SqlDataAdapter a = new SqlDataAdapter("SELECT MovieName, NumberOfCopies FROM Movie " +
                "WHERE MovieType ='" + comboBox1.Text + "'", connection);

            DataTable t = new DataTable();
            a.Fill(t);
            Console.WriteLine(a);
            dataGridView1.DataSource = t;
            connection.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string[] filename = { "", "god father", "mad max", "mary and max", "The love witch" };
            for (int i = 1; i < 5; i++)
            {
                MovieGroupBox newGroupBox = new MovieGroupBox();
                newGroupBox.setGroupBox(tabPage3, i);
                newGroupBox.setImage(newGroupBox.groupBox, filename[i]);
                newGroupBox.setMovieInfo(newGroupBox.groupBox, "God", "Nick", "Bento Box", "2018-02-11", "2018-05-03"); 
            }

        }
    }
}
