using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace MovieRental
{
    public partial class TestForm : Form
    {
        public static string connectionString;

        public TestForm()
        {
            InitializeComponent();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            connectionString = ConfigurationManager.
                ConnectionStrings["MovieRental.Properties." +
                "Settings.MovieRentalConnectionString"].ConnectionString;
            Console.WriteLine(connectionString);
            if (!MoviePanel.Controls.Contains(FeatureControl.Instance))
            {
                MoviePanel.Controls.Add(FeatureControl.Instance);
                FeatureControl.Instance.Dock = DockStyle.Fill;
                FeatureControl.Instance.BringToFront();
            }
            else
                FeatureControl.Instance.BringToFront();

            
        }
    }
}
