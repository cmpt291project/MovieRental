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
    public partial class topControl : UserControl
    {
        private static topControl _instance;
        public static topControl Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new topControl();
                return _instance;
            }
        }

        public topControl()
        {
            InitializeComponent();
        }

        private void topControl_Load(object sender, EventArgs e)
        {
            update();
        }

        public void update() {
            SqlConnection connection = new SqlConnection(Form4.connectionString);
            connection.Open();
            string sql = "select * from (select top 10 count(MID) num, mid from[Order] O group by MID order by num DESC) T , Movie M left join(Select AVG(Rating) as rate, MID from MovieRating Group by MID ) as T2 on T2.MID = m.MID where T.MID = M.mid ";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                MovieBoxRent movieBoxRent = new MovieBoxRent(dataTable.Rows[i]["MID"].ToString());
                movieBoxRent.createNewBox(panelintop, i,0);
                //MessageBox.Show(row["MID"].ToString().Trim());
                if (dataTable.Rows[i]["Poster"] == DBNull.Value)
                {
                    //MessageBox.Show("image null");
                    //MemoryStream ms = new MemoryStream((byte[])Properties.Resources.ResourceManager.GetObject("001"));
                    movieBoxRent.CreatePictureImage((Image)Properties.Resources.ResourceManager.GetObject("Noimage"));
                }
                else
                {
                    byte[] ImageArray = (byte[])dataTable.Rows[i]["Poster"];
                    Image image = Image.FromStream(new MemoryStream(ImageArray));

                    movieBoxRent.CreatePictureImage(image);
                }
                //movieBoxRent.CreatePicture(dataTable.Rows[i]["MID"].ToString().Trim());
                movieBoxRent.CreateName(dataTable.Rows[i]["MovieName"].ToString());
                //MessageBox.Show(row["MovieName"].ToString());
                movieBoxRent.CreateScore(dataTable.Rows[i]["rate"].ToString());
                movieBoxRent.CreateButtonRent();
            }

            connection.Close();
        }
    }
}
