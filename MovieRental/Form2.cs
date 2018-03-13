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
            Console.WriteLine(a);
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
            groupBox2.Visible = false;
            groupBox1.Visible = false;
            groupBox3.Visible = false;
            groupBox7.Visible = true;
            groupBox8.Visible = true;
            groupBox9.Visible = true;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox6.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < 4; i++)
            {

                    GroupBox GroupBox1 = new GroupBox();
                    GroupBox1.Name = "Movie Name";
                    GroupBox1.Location = new Point(200, 200);
                    GroupBox1.Size = new Size(200, 100);
                    GroupBox1.Top = i * 100;
                    GroupBox1.Left = 200;
                    GroupBox1.BackColor = Color.FromArgb(255, 232, 232);
                    GroupBox1.Text = "Movie Title";
                    GroupBox1.Font = new Font("Segoe UI", 15);
                    GroupBox1.FlatStyle = FlatStyle.Standard;
                    tabPage3.Controls.Add(GroupBox1);

                
                PictureBox image = new PictureBox();
                image.Location = new Point(0, 0);
                image.Size = new Size(120, 120);
                image.Top = i * 10;
                image.Left = 20;
                //image.
                //image.FlatStyle = FlatStyle.Standard;
                string path = "god_father.jpg";
                Bitmap bmp = new Bitmap(System.Reflection.Assembly.GetEntryAssembly().GetManifestResourceStream("MovieRental.Resources.god father"));// + path));
                //image.Image = new Bitmap(MovieRental.Properties.Resources.i);
                image.Image = bmp;
                image.SizeMode = PictureBoxSizeMode.Zoom;
                GroupBox1.Controls.Add(image);
            }

        }
    }
}
