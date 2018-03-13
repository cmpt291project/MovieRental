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
    public partial class Form3 : Form
    {
        //static int attempt = 3;
        string connectionString;
        public static string info = "";
        public Form3()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.
                ConnectionStrings["MovieRental.Properties." +
                "Settings.MovieRentalConnectionString"].ConnectionString;
            Console.WriteLine(connectionString);
        }

       

        

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            SqlConnection scn = new SqlConnection();
            scn.ConnectionString = connectionString;
            scn.Open();

            SqlCommand scmd = new SqlCommand("select count (*) as cnt from Password where EmailAddress=@email and Password=@pwd", scn);
            scmd.Parameters.Clear();
            scmd.Parameters.AddWithValue("@email", textBox1.Text);
            scmd.Parameters.AddWithValue("@pwd", textBox2.Text);


            if (scmd.ExecuteScalar().ToString() == "1")
            {
                //pictureBox1.Image = new Bitmap(@"C:\Users\Mic 18\Documents\Visual Studio 2015\Projects\mylogin\granted.png");
                MessageBox.Show("YOU ARE GRANTED WITH ACCESS");
                SqlCommand scmd2 = new SqlCommand("select UserType from Password where EmailAddress=@email and Password=@pwd", scn);
                scmd.Parameters.Clear();
                scmd2.Parameters.AddWithValue("@email", textBox1.Text);
                scmd2.Parameters.AddWithValue("@pwd", textBox2.Text);
                Console.WriteLine(scmd2.ExecuteScalar().ToString().Length);
                bool result = scmd2.ExecuteScalar().ToString().Equals("c         ");
                Console.WriteLine(result);
                if (result)
                {
                    info = scmd2.ExecuteScalar().ToString();
                    /*var customerForm = new Form2();
                    customerForm.Show();
                    this.Owner = customerForm;*/
                    Console.WriteLine("CUSTOMER");
                    this.Hide();
                }
                else
                {
                    info = scmd2.ExecuteScalar().ToString();
                    var employeeForm = new EmployeeHome();
                    employeeForm.Show();
                    this.Owner = employeeForm;
                    Console.WriteLine("EMPLOYEE");
                    this.Hide();
                }
                
            }

            else
            {

                //pictureBox1.Image = new Bitmap(@"C:\Users\Mic 18\Documents\Visual Studio 2015\Projects\mylogin\denied.jpg");
                MessageBox.Show("YOU ARE NOT GRANTED WITH ACCESS");
                //lbl_Msg.Text = ("You Have Only " + Convert.ToString(attempt) + " Attempt Left To Try");
                // --attempt;
                textBox1.Clear();
                textBox2.Clear();
            }
            scn.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Under development");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Under development");
        }

        
    }
}
