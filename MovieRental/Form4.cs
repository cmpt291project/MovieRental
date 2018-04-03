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
    public partial class Form4 : Form
    {
        public static string connectionString;

        public Form4()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!panel1.Controls.Contains(UC1.Instance))
            {
                panel1.Controls.Add(UC1.Instance);
                UC1.Instance.Dock = DockStyle.Fill;
                UC1.Instance.BringToFront();
            }
            else
                UC1.Instance.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!panel1.Controls.Contains(UC2.Instance))
            {
                panel1.Controls.Add(UC2.Instance);
                UC2.Instance.Dock = DockStyle.Fill;
                UC2.Instance.BringToFront();
            }
            else
                UC2.Instance.BringToFront();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!panel1.Controls.Contains(UC3.Instance))
            {
                panel1.Controls.Add(UC3.Instance);
                UC3.Instance.Dock = DockStyle.Fill;
                UC3.Instance.BringToFront();
            }
            else
                UC3.Instance.BringToFront();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            if (!panel1.Controls.Contains(UC1.Instance))
            {
                panel1.Controls.Add(UC1.Instance);
                UC1.Instance.Dock = DockStyle.Fill;
                UC1.Instance.BringToFront();
            }
            else
                UC1.Instance.BringToFront();


            connectionString = ConfigurationManager.
                ConnectionStrings["MovieRental.Properties." +
                "Settings.MovieRentalConnectionString"].ConnectionString;
            //Console.WriteLine(connectionString);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!panel1.Controls.Contains(ManagerUC2.Instance))
            {
                panel1.Controls.Add(ManagerUC2.Instance);
                ManagerUC2.Instance.Dock = DockStyle.Fill;
                ManagerUC2.Instance.BringToFront();
            }
            else
                ManagerUC2.Instance.BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!panel1.Controls.Contains(EmployeeUC.Instance))
            {
                panel1.Controls.Add(EmployeeUC.Instance);
                EmployeeUC.Instance.Dock = DockStyle.Fill;
                EmployeeUC.Instance.BringToFront();
            }
            else
                EmployeeUC.Instance.BringToFront();
        }

    
    }
}
