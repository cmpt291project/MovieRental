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
using System.Configuration;

namespace MovieRental
{
    class MovieBoxRent
    {
        public GroupBox gb;
        public PictureBox moviePic;
        public LinkLabel movieName;
        public Label score;
        public Button rent;
        public Button wishlist;
        public string MID;

        public MovieBoxRent(string mid)
        {
            gb = new GroupBox();
            moviePic = new PictureBox();
            movieName = new LinkLabel();
            score = new Label();
            rent = new Button();
            wishlist = new Button();
            MID = mid;

        }
        public void createNewBox(Panel p, int i)
        {
            gb.Name = "movie";
            gb.Location = new Point(3, 3);
            gb.Size = new Size(200, 320);
            gb.Top = 3;
            gb.Left = 3 + i*200;
            gb.Text = "Movie";
            gb.FlatStyle = FlatStyle.Standard;

            p.Controls.Add(gb);

        }
        public void CreatePicture(string filename) {
            moviePic.Name = "pic";
            moviePic.Location = new Point(6, 18);
            moviePic.Size = new Size(180, 210);
            moviePic.Top = 10;
            moviePic.Left = 5;
            moviePic.BackColor = Color.White;
            moviePic.Image = (Image)Properties.Resources.ResourceManager.GetObject(filename);
            moviePic.SizeMode = PictureBoxSizeMode.Zoom;
            gb.Controls.Add(moviePic);
        }
        public void CreateName(string name) {
            movieName.Name = "movieName";
            movieName.Text = name;
            movieName.Location = new Point(8, 429);
            movieName.Font = new Font("Serif", 10);
            movieName.Top = 225;
            movieName.Left = 3;
            movieName.MaximumSize = new Size(150, 40);
            movieName.AutoSize = true;
            
            gb.Controls.Add(movieName);
        }
        public void CreateScore(string s) {
            score.Name = "score";
            score.Text = s;
            score.Font = new Font("Serif", 10);
            score.Location = new Point(8, 429);
            score.Top = 225;
            score.Left = 160;
            gb.Controls.Add(score);
        }
        public void CreateButtonRent()
        {
            rent.Name = "rent";
            rent.Size = new Size(75, 35);
            rent.Top = 270;
            rent.Left = 3;
            if (CheckMovieRent(MID) == false)
            {
                rent.Text = "Rented";
                rent.Enabled = false;
            }
            else
            {
                rent.Text = "Rent Now";
                rent.Click += new EventHandler(NewButton_Click);
            }
            
            //rent.Enabled = false;
            gb.Controls.Add(rent);

            wishlist.Name = "wishlist";
            wishlist.Size = new Size(75, 35);
            wishlist.Top = 270;
            wishlist.Left = 120;
            wishlist.Text = "Add To Wishlist";
            gb.Controls.Add(wishlist);
            
        }

        public void NewButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            //btn.Enabled = false;
            SqlConnection connection = new SqlConnection(Form4.connectionString);
            connection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * from Movie M where M.MID = " + MID , connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            int num = Convert.ToInt32(dataTable.Rows[0]["CurrentNum"]);
            if (num > 0)
            {
                //SqlCommand sq = new SqlCommand("UPDATE dbo.Movie SET CurrentNum = @curNum WHERE MID = @MID GO ", connection);
                dataTable.Rows[0].BeginEdit();
                dataTable.Rows[0]["CurrentNum"] = num-1;
                dataTable.Rows[0].EndEdit();
                SqlCommandBuilder sb = new SqlCommandBuilder(dataAdapter);
                dataAdapter.Update(dataTable);
                SqlCommand sq = new SqlCommand("INSERT dbo.Order SET CurrentNum = @curNum WHERE MID = @MID GO ", connection);
                MessageBox.Show("rent");

                string insert = "INSERT dbo.[Order](OID, MID, CID, EID, OrderDate, ReturnDate)  VALUES((Select MAX(OID)+1 from [Order]), @mid, @cid, @eid, @date, @return)";
                SqlCommand sc = new SqlCommand(insert, connection);
                sc.Parameters.AddWithValue("@oid", "006");
                sc.Parameters.AddWithValue("@mid", MID);
                sc.Parameters.AddWithValue("@cid", UC1.id);
                sc.Parameters.AddWithValue("@eid", "001");
                sc.Parameters.AddWithValue("@date", "2018-01-01");
                sc.Parameters.AddWithValue("@return", "2018-01-01");
                //sc.Parameters.AddWithValue("@actual", null);
                sc.ExecuteNonQuery();

            }
            else
            {
                MessageBox.Show("Sorry. No copy available right now.");
            }

            //MessageBox.Show(dataTable.Rows[0]["CurrentNum"].ToString());
            connection.Close();
            //MessageBox.Show("Hello from " + btn.Name);
            // When find specific button do what do you want.
            //Then exit from loop by break.
            //  break;
            // }
            //}
        }

        private bool CheckMovieRent(string mid) {
            SqlConnection connection = new SqlConnection(Form4.connectionString);
            connection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select ActualReturnDate, O.MID, M.CurrentNum from[Order] O, Movie M where O.CID =" + UC1.id + "and O.MID =" + mid +" and O.MID = M.MID", connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            foreach (DataRow row in dataTable.Rows)
            {
                //MessageBox.Show(row["ActualReturnDate"].ToString());
                if (row["ActualReturnDate"].ToString()=="")
                {
                    return false;
                }               
            }            
            //MessageBox.Show(dataTable.Rows.Count.ToString());
            connection.Close();
            return true;
        }


    }
}
