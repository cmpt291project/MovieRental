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
    public partial class SearchUC : UserControl
    {
        SqlDataAdapter adapt;
        SqlConnection con = new SqlConnection(Form4.connectionString);

        private static SearchUC _instance;
        public static SearchUC Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SearchUC();
                return _instance;
            }
        }

        public SearchUC()
        {
            InitializeComponent();
        }

        public void GetSearchParameter(string search)
        {
            Console.WriteLine(search);
            con.Open();
            DataTable dt5 = new DataTable();
            adapt = new SqlDataAdapter("select * from Movie where MovieName like @search", con);
            adapt.SelectCommand.Parameters.AddWithValue("@search", "%" + search + "%");
            adapt.Fill(dt5);
            con.Close();
            if (dt5.Rows.Count > 0)
                dataGridView1.DataSource = dt5;
            
        }
    }
}
