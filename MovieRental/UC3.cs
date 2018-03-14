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
    public partial class UC3 : UserControl
    {
        private static UC3 _instance;
        public static UC3 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UC3();
                return _instance;
            }
        }

        public UC3()
        {
            InitializeComponent();
        }

        private void UC3_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(UC1.info);
           /* SqlConnection scn = new SqlConnection();
            scn.ConnectionString = Form4.connectionString;
            scn.Open();
            SqlCommand scmd = new SqlCommand("select count (*) as cnt from Password where EmailAddress=@email and Password=@pwd", scn);
            scn.Close();*/
        }
    }
}
