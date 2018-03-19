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

        private string newMID;
        private string MID;
        SqlConnection con = new SqlConnection(Form4.connectionString);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adapt;

        public ManagerUC2()
        {
            InitializeComponent();
            Controls.Add(panel1);
            Controls.Add(panel2);
            panel1.BringToFront();

            DisplayData();
           
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            if (MovieNameTxt.Text != "" && MovieTypeTxt.Text != "")
            {
                using(cmd = new SqlCommand("select MAX(CAST(MID as int))+1 from Movie", con))
                {
                    con.Open();
                    Console.WriteLine(cmd.ExecuteScalar().ToString());
                    newMID = cmd.ExecuteScalar().ToString();
                    Console.WriteLine(newMID);
                    //int test = Convert.ToInt32(maxID);
                    //Console.WriteLine(test);
                    con.Close();

                }
                cmd = new SqlCommand("insert into Movie(MID,MovieName,MovieType,DistribututionFee,NumberOfCopies," +
                    "ReleaseDate,AddDate,Director,CurrentNum) values(@MID,@name,@type,@distFee,@numCopies,@releaseDate" +
                    ",@addDate,@director,@currNum)", con);
                con.Open();
                cmd.Parameters.AddWithValue("@MID", newMID);
                cmd.Parameters.AddWithValue("@name", MovieNameTxt.Text);
                cmd.Parameters.AddWithValue("@type", MovieTypeTxt.Text);
                cmd.Parameters.AddWithValue("@distFee", DistFeeTxt.Text);
                cmd.Parameters.AddWithValue("@numCopies", NumCopiesTxt.Text);
                cmd.Parameters.AddWithValue("@releaseDate", ReleaseDateTxt.Text);
                cmd.Parameters.AddWithValue("@addDate", AddDateTxt.Text);
                cmd.Parameters.AddWithValue("@director", DirectorTxt.Text);
                cmd.Parameters.AddWithValue("@currNum", CurrentNumTxt.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Inserted Successfully");
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Provide Details!");
            }

        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (MovieNameTxt.Text != "" && MovieTypeTxt.Text != "" && DistFeeTxt.Text != "" && NumCopiesTxt.Text != ""
                && ReleaseDateTxt.Text != "" && AddDateTxt.Text != "" && DirectorTxt.Text != "" && CurrentNumTxt.Text != "")
            {
                
                //using (SqlConnection con = new SqlConnection(Form4.connectionString))
                cmd = new SqlCommand("update Movie set MovieName=@name, MovieType=@type, DistribututionFee=@distfee, " +
                    "NumberOfCopies=@numCopies, ReleaseDate=@releaseDate, AddDate=@addDate, Director=@director, " +
                    "CurrentNum=@currNum where MID=@id", con);
                con.Open();

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", MID);
                cmd.Parameters.AddWithValue("@name", MovieNameTxt.Text);
                cmd.Parameters.AddWithValue("@type", MovieTypeTxt.Text);
                cmd.Parameters.AddWithValue("@distFee", DistFeeTxt.Text);
                cmd.Parameters.AddWithValue("@numCopies", NumCopiesTxt.Text);
                cmd.Parameters.AddWithValue("@releaseDate", ReleaseDateTxt.Text);
                cmd.Parameters.AddWithValue("@addDate", AddDateTxt.Text);
                cmd.Parameters.AddWithValue("@director", DirectorTxt.Text);
                cmd.Parameters.AddWithValue("@currNum", CurrentNumTxt.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                DisplayData();
                ClearData();
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

        private void ClearData()
        {
            MovieNameTxt.Clear();
            MovieTypeTxt.Clear();
            DistFeeTxt.Clear();
            NumCopiesTxt.Clear();
            ReleaseDateTxt.Clear();
            AddDateTxt.Clear();
            DirectorTxt.Clear();
            CurrentNumTxt.Clear();
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
            char[] delimiterChars = {' '};
            string[] releaseDateStrings = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString().Split(delimiterChars);
            string[] addDateStrings = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString().Split(delimiterChars);
            ReleaseDateTxt.Text = releaseDateStrings[0];
            AddDateTxt.Text = addDateStrings[0];
            DirectorTxt.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            CurrentNumTxt.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();

        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells["MID"].Value != DBNull.Value)
            {
                if (MessageBox.Show("Delete this Record?", "DataGridView", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (SqlConnection sqlCon = new SqlConnection(Form4.connectionString))
                    {
                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("MovieDeleteByID", sqlCon);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@MID", dataGridView1.CurrentRow.Cells["MID"].Value.ToString());
                        sqlCmd.ExecuteNonQuery();
                        sqlCon.Close();
                    }
                    using (SqlConnection sqlCon = new SqlConnection(Form4.connectionString))
                    {
                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("Delete from Casting Where MID=@MID", sqlCon);
                        sqlCmd.Parameters.AddWithValue("@MID", dataGridView1.CurrentRow.Cells["MID"].Value.ToString());
                        sqlCmd.ExecuteNonQuery();
                        sqlCon.Close();

                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void btnMovies_Click(object sender, EventArgs e)
        {
            panel1.BringToFront();
        }

        private void btnActors_Click(object sender, EventArgs e)
        {
            panel2.BringToFront();
        }
    }
}
