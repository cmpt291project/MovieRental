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
using System.Globalization;

namespace MovieRental
{
    public partial class ManagerUC2 : UserControl
    {
        private static ManagerUC2 _instance;
        public static ManagerUC2 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ManagerUC2();
                return _instance;
            }
        }

        private string MID;
        SqlConnection con = new SqlConnection(Form4.connectionString);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adapt;

        public ManagerUC2()
        {
            InitializeComponent();
            DisplayData();
        }

        private void Insert_Click(object sender, EventArgs e)
        {

        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (MovieNameTxt.Text != "" && MovieTypeTxt.Text != "")
            {
                
                //using (SqlConnection con = new SqlConnection(Form4.connectionString))
                cmd = new SqlCommand("update Movie set MovieName=@name,MovieType=@type where MID=@id", con);
                con.Open();

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", MID.Trim());
                cmd.Parameters.AddWithValue("@name", MovieNameTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@type", MovieTypeTxt.Text.Trim());
                cmd.ExecuteNonQuery();
                con.Close();
                DisplayData();
                //ClearData();
            }
            else
            {
                Console.WriteLine("Please Try Again");
            }

        }

        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("SELECT * from Movie", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            //dataGridView2.Columns["MID"].Visible = false;
            con.Close();
            /*foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                row.Cells[5].Value = DateTime.Now.ToShortDateString();
                row.Cells[6].Value = DateTime.Now.ToShortDateString();
            }*/

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            MovieNameTxt.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            //movieName = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            MovieTypeTxt.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            //movieType = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            DistFeeTxt.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            NumCopiesTxt.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            ReleaseDateTxt.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            AddDateTxt.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            DirectorTxt.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            CurrentNumTxt.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();

        }
    }
}
