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

//using App1.config;
namespace MovieRental
{
    public partial class Form1 : Form
    {
        string connectionString;

        public Form1()
        {
            InitializeComponent();
            //FillData();
            //Console.WriteLine("Hello");
            connectionString = ConfigurationManager.
                ConnectionStrings["MovieRental.Properties." +
                "Settings.MovieRentalConnectionString"].ConnectionString;
            Console.WriteLine(connectionString);
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            maskedTextBox1.Text = "New Test";
            FillData();
            //string connectionString = "Data Source=DESKTOP-V2MG4LO;Initial Catalog=MovieRental;Integrated Security=True";
            //SqlConnection connection = new SqlConnection(connectionString);
           // connection.Open();
            //string cmdString = "select AID from Actor";
            //SqlCommand cmd = new SqlCommand(cmdString, connection);
            //SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //maskedTextBox1.Text = sda; 
            //connection.Close();

        }

        //comment by yan test
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


        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'movieRentalDataSet.Actor' table. You can move, or remove it, as needed.
           

        }

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var newForm = new Form2();
            newForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var newForm = new Form3();
            newForm.Show();
        }

        private void actorBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }

    }
}
