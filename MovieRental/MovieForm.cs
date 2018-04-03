using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieRental
{
    public partial class MovieForm : Form
    {
        public string mid;

        public MovieForm()
        {
            InitializeComponent();
        }
        public MovieForm(string s) {
            InitializeComponent();
            mid = s;
        }

        private void MovieForm_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(Form4.connectionString);
            connection.Open();
            string moviesql = "select * from Movie where MID = '" + mid + "'";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(moviesql, connection);
            DataTable movieTable = new DataTable();
            dataAdapter.Fill(movieTable);
            mName.Text = movieTable.Rows[0]["MovieName"].ToString().Trim();
            director.Text = movieTable.Rows[0]["Director"].ToString().Trim();
            DateTime d = (DateTime)movieTable.Rows[0]["ReleaseDate"];
            release.Text = d.ToString("d");
            copies.Text = movieTable.Rows[0]["CurrentNum"].ToString().Trim();
            //panelInMovieForm.Controls.Add(mName);

            string actorsql = "select * from (select c.AID from Casting C where c.MID = '"+ mid + "') T , Actor A where t.AID = a.AID";
            dataAdapter = new SqlDataAdapter(actorsql, connection);
            DataTable actorTable = new DataTable();
            dataAdapter.Fill(actorTable);

            for (int i = 0; i < actorTable.Rows.Count; i++)
            {
                ActorInfo ai = new ActorInfo();
                ai.createNewBox(actorPanel, i);
                string full = actorTable.Rows[i]["FirstName"].ToString().Trim() +" "+ actorTable.Rows[i]["LastName"].ToString().Trim();
                ai.showName(full);
                DateTime bd = (DateTime)actorTable.Rows[i]["DateOfBirth"];
                ai.showDob(bd);
                string g = actorTable.Rows[i]["Gender"].ToString().Trim();
                ai.showGender(g);
            }


            connection.Close();
        }

        
    }
}
