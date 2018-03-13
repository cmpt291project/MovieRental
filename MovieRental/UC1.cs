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
using System.Configuration;

namespace MovieRental
{
    public partial class UC1 : UserControl
    {
        private static UC1 _instance;
        public static UC1 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UC1();
                return _instance;
            }
        }
        public UC1()
        {
            InitializeComponent();
        }

        private void UC1_Load(object sender, EventArgs e)
        {
            Console.WriteLine(Form4.connectionString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Panel pnl = Parent as Panel;
            if (pnl != null)
            {
                if (!pnl.Controls.Contains(UC2.Instance))
                {
                    pnl.Controls.Add(UC2.Instance);
                    UC2.Instance.Dock = DockStyle.Fill;
                    UC2.Instance.BringToFront();
                }
                else
                    UC2.Instance.BringToFront();
            }
        }
    }
}
