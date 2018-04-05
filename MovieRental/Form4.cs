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
    }
}
