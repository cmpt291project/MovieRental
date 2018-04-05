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

namespace MovieRental
{
    public partial class RateForm : Form
    {
        private string mid;
        private List<RateBox> actors;
        public RateForm()
        {
            InitializeComponent();
        }

        public RateForm(string mid) {
            InitializeComponent();
            this.mid = mid;
            actors = new List<RateBox>();
            
        }


        private void RateForm_Load(object sender, EventArgs e)
        {
            SqlConnection c = new SqlConnection(Form4.connectionString);           
            c.Open();
            string sqlgetmovie = "select MovieName from Movie where MID = '" + mid +"'";
            SqlDataAdapter moviedataAdapter = new SqlDataAdapter(sqlgetmovie, c);
            DataTable moviedataTable = new DataTable();
            moviedataAdapter.Fill(moviedataTable);
            movieName.Text = moviedataTable.Rows[0]["MovieName"].ToString().Trim();

            string sqlactor = "Select LastName, FirstName, C.AID from Casting C, Actor A where c.mid = '" + mid +"'and A.AID = C.AID";
            SqlDataAdapter actordataAdapter = new SqlDataAdapter(sqlactor, c);
            DataTable actorData = new DataTable();
            actordataAdapter.Fill(actorData);
            int i = 0;
            //MessageBox.Show(actorData.Rows.Count.ToString());
            foreach (DataRow row in actorData.Rows)
            {
                RateBox rateBox = new RateBox();
                rateBox.NewGroupBox(panel1, i, row["AID"].ToString().Trim());
                rateBox.NewLabel(row["FirstName"].ToString().Trim() +" " + row["LastName"].ToString().Trim());
                rateBox.NewScore();
                actors.Add(rateBox);
                i++;
            }
            
            c.Close();
        }

        private void submit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Form4.connectionString);
            con.Open();
            CheckMRate(con);
            CheckARate(con);

            con.Close();
            this.Dispose();
            MessageBox.Show("Thanks for the rating.");           
        }

        private void CheckMRate(SqlConnection c) {
            string check = "select * from MovieRating where CID = '" + UC1.id + "' and MID = '" + mid + "'";
            SqlDataAdapter da = new SqlDataAdapter(check, c);
            DataTable d = new DataTable();
            da.Fill(d);
            var checkedButton = rateMovie.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);
            if (d.Rows.Count > 0)
            {
                d.Rows[0].BeginEdit();
                d.Rows[0]["Rating"] = Convert.ToInt32(checkedButton.Text);
                d.Rows[0].EndEdit();
                SqlCommandBuilder sb = new SqlCommandBuilder(da);
                da.Update(d);
            }
            else {
                string insert = "INSERT dbo.[MovieRating](CID, MID, Rating)  VALUES(@cid, @mid, @rate)";
                SqlCommand sc = new SqlCommand(insert, c);
                
                sc.Parameters.AddWithValue("@cid", UC1.id);
                sc.Parameters.AddWithValue("@mid", mid);
                sc.Parameters.AddWithValue("@rate", Convert.ToInt32(checkedButton.Text));
                sc.ExecuteNonQuery();
            }
            
        }

        private void CheckARate(SqlConnection c) {
            foreach (RateBox box in actors)
            {
                string check = "select * from ActorRating where CID = '" + UC1.id + "' and AID = '" + box.gb.Name + "'";
                SqlDataAdapter da = new SqlDataAdapter(check, c);
                DataTable d = new DataTable();
                da.Fill(d);
                var checkedScore = box.gb.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);

                if (d.Rows.Count > 0)
                {
                    d.Rows[0].BeginEdit();
                    d.Rows[0]["Rating"] = Convert.ToInt32(checkedScore.Text);
                    d.Rows[0].EndEdit();
                    SqlCommandBuilder sb = new SqlCommandBuilder(da);
                    da.Update(d);
                }
                else {
                    string insertactor = "INSERT dbo.[ActorRating](CID, AID, Rating)  VALUES(@cid, @aid, @r)";
                    SqlCommand command = new SqlCommand(insertactor, c);
                    command.Parameters.AddWithValue("@cid", UC1.id);
                    command.Parameters.AddWithValue("@aid", box.gb.Name);
                    command.Parameters.AddWithValue("@r", Convert.ToInt32(checkedScore.Text));
                    command.ExecuteNonQuery();

                }
            }
        }

        

        
    }
}
