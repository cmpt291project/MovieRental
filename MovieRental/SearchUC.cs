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
using System.IO;

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
            panel1.Controls.Clear();
            //MessageBox.Show(search);
            Console.WriteLine(search);
            con.Open();
            DataTable dt5 = new DataTable();
            string seachsql = "select U.MovieName, U.MID, R.rate from (select M.MovieName, M.MID " +
                "from Movie M, (select distinct MID from Casting C,(select * from Actor where FirstName like @search or LastName like @search) T " +
                "where C.AID = T.AID) N where M.MID = N.MID union select MovieName, MID from Movie where MovieName like @search" +
                ") U left join (Select AVG(Rating) as rate, MID from MovieRating Group by MID) R ON U.MID = R.MID";
            //adapt = new SqlDataAdapter("select * from Movie where MovieName like @search", con);
            adapt = new SqlDataAdapter(seachsql, con);
            adapt.SelectCommand.Parameters.AddWithValue("@search", "%" + search + "%");
            adapt.Fill(dt5);
            con.Close();
           // if (dt5.Rows.Count > 0)
          //      dataGridView1.DataSource = dt5;
            int r = 0;
            int c = 0;
            foreach (DataRow row in dt5.Rows)
            {
                if (c > 0 && c % 3 ==0)
                {
                    r++;
                    c = 0;
                }
                MovieBoxRent mbr = new MovieBoxRent(row["MID"].ToString().Trim());
                mbr.createNewBox(panel1, c, r);
                Image im = GetPoster(row["MID"].ToString().Trim());
                if (im == null)
                {
                    mbr.CreatePictureImage((Image)Properties.Resources.ResourceManager.GetObject("Noimage"));
                }
                else {
                    mbr.CreatePictureImage(im);
                }

                mbr.CreateName(row["MovieName"].ToString());
                mbr.CreateScore(row["rate"].ToString());
                mbr.CreateButtonRent();
                c++;
            }

           // con.Close();
            
        }

        private void SearchUC_Load(object sender, EventArgs e)
        {

        }

        private Image GetPoster(string mid) {
            
            string s = "select Poster from Movie where MID = '" + mid + "'";
            adapt = new SqlDataAdapter(s, con);
            DataTable d = new DataTable();
            adapt.Fill(d);
            Image i = null;
            if (d.Rows[0]["Poster"] != DBNull.Value)
            {
                byte[] ImageArray = (byte[])d.Rows[0]["Poster"];
                i = Image.FromStream(new MemoryStream(ImageArray));
            }
            return i;            
        }
    }
}
