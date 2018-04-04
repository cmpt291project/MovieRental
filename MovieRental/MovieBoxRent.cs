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
using System.IO;

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
     /*   public void CreatePicture(MemoryStream ms) {
            moviePic.Name = "pic";
            moviePic.Location = new Point(6, 18);
            moviePic.Size = new Size(180, 210);
            moviePic.Top = 10;
            moviePic.Left = 5;
            moviePic.BackColor = Color.White;

            movieName.Image = Image.FromStream(ms);
            //moviePic.Image = (Image)Properties.Resources.ResourceManager.GetObject(filename);
            moviePic.SizeMode = PictureBoxSizeMode.StretchImage;
            gb.Controls.Add(moviePic);
        }*/
        public void CreatePictureImage(Image ms)
        {
            moviePic.Name = "pic";
            moviePic.Location = new Point(6, 18);
            moviePic.Size = new Size(180, 210);
            moviePic.Top = 10;
            moviePic.Left = 5;
            moviePic.BackColor = Color.White;

            //movieName.Image = new Bitmap(ms);
            moviePic.Image = ms;
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

            movieName.Click += new EventHandler(moviePage);

            gb.Controls.Add(movieName);
        }
        public void CreateScore(string s) {
            score.Name = "score";
            if (s == "")
            {
                s = "0";
            }
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
            rent.Size = new Size(75, 40);
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
            wishlist.Size = new Size(75, 40);
            wishlist.Top = 270;
            wishlist.Left = 120;
            if (CheckMovieWishlist(MID))
            {
                wishlist.Text = "Added";
                wishlist.Enabled = false;
            }
            else
            {
                wishlist.Text = "Add To Wishlist";
                wishlist.Click += new EventHandler(Wish_Click);
            }            
            gb.Controls.Add(wishlist);
            
        }

        public void NewButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            //btn.Enabled = false;
            SqlConnection connection = new SqlConnection(Form4.connectionString);
            connection.Open();
            SqlDataAdapter selectMovie = new SqlDataAdapter("SELECT * from Movie M where M.MID = " + MID , connection);
            DataTable movieRow = new DataTable();
            selectMovie.Fill(movieRow);
            int num = Convert.ToInt32(movieRow.Rows[0]["CurrentNum"]);
            if (num > 0)
            {
                CheckUserRentStatus(connection, num, movieRow,selectMovie);
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

        private bool CheckMovieWishlist(string mid) {
            SqlConnection con = new SqlConnection(Form4.connectionString);
            con.Open();
            SqlDataAdapter checkWish = new SqlDataAdapter("select * from MovieQueue mq where mq.CID = '"+ UC1.id +"' and mq.MID = '"+ mid+"'",con);
            DataTable record = new DataTable();
            checkWish.Fill(record);
            if (record.Rows.Count > 0)
            {
                con.Close();
                return true;               
            }
            con.Close();
            return false;
        }

        private void RentMovie(SqlConnection connection, int num, DataTable movie, SqlDataAdapter selectMovie) {
            //SqlCommand sq = new SqlCommand("UPDATE dbo.Movie SET CurrentNum = @curNum WHERE MID = @MID GO ", connection);
            movie.Rows[0].BeginEdit();
            movie.Rows[0]["CurrentNum"] = num - 1;
            movie.Rows[0].EndEdit();
            SqlCommandBuilder sb = new SqlCommandBuilder(selectMovie);
            selectMovie.Update(movie);
            //SqlCommand sq = new SqlCommand("INSERT dbo.Order SET CurrentNum = @curNum WHERE MID = @MID GO ", connection);
            //MessageBox.Show("rent");

            string insert = "INSERT dbo.[Order](OID, MID, CID, EID, OrderDate, ReturnDate)  VALUES((Select MAX(CAST(OID as int))+1 from [Order]), @mid, @cid, @eid, @date, @return)";
            SqlCommand sc = new SqlCommand(insert, connection);
            //sc.Parameters.AddWithValue("@oid", "006");
            DateTime date = DateTime.Today;
            DateTime ret = new DateTime(date.Year, date.Month+1, date.Day);
            if (date.Month == 12)
            {
                ret = new DateTime(date.Year+1, 1, date.Day);
            }
                        
            sc.Parameters.AddWithValue("@mid", MID);
            sc.Parameters.AddWithValue("@cid", UC1.id);
            sc.Parameters.AddWithValue("@eid", "1");
            sc.Parameters.AddWithValue("@date", date.Date.ToString("d"));
            sc.Parameters.AddWithValue("@return", ret);
            //sc.Parameters.AddWithValue("@actual", null);
            sc.ExecuteNonQuery();
        }

        private void CheckUserRentStatus(SqlConnection con, int num, DataTable movie, SqlDataAdapter select) {
            SqlDataAdapter checkUserRent = new SqlDataAdapter("select COUNT(OID) cur,O.CID from[Order] O where O.CID = '" + UC1.id + "' and  ActualReturnDate IS NULL group by O.CID", con);
            DataTable userStatus = new DataTable();
            checkUserRent.Fill(userStatus);
            SqlDataAdapter checkUserMonthRent = new SqlDataAdapter("select COUNT(OID) curMon from(select MONTH(OrderDate) as m, MONTH(GETDATE()) as tm, YEAR(OrderDate) as y, Year(GETDATE()) as ty, OID from[Order] O where O.CID = '" + UC1.id + "') D where m = tm and ty = y",con);
            DataTable userMonth = new DataTable();
            checkUserMonthRent.Fill(userMonth);

            SqlDataAdapter plan = new SqlDataAdapter("select NumberATime, NumberEachMonth from[Plan] p, Customer c where c.AccountType = p.[Plan] and c.CID = '" + UC1.id + "'", con);
            DataTable p = new DataTable();
            plan.Fill(p);
            if (userStatus.Rows.Count == 0 && userMonth.Rows.Count ==0)
            {
                MessageBox.Show("rent successfull");
                RentMovie(con, num, movie, select);
                rent.Text = "Rented";
                rent.Enabled = false;

            }
            else if (userStatus.Rows.Count != 0 && userStatus.Rows[0]["cur"].ToString() == p.Rows[0]["NumberATime"].ToString())
            {
                MessageBox.Show("You already rent" + userStatus.Rows[0]["cur"] + "movies. Limit each time reached. Please return your current rental first. ");
            }
            else if (userMonth.Rows.Count != 0 && userMonth.Rows[0]["curMon"].ToString() == p.Rows[0]["NumberEachMonth"].ToString())
            {
                MessageBox.Show("You already rent" + userMonth.Rows[0]["curMon"] + "movies. Monthly limit reached.  Please return your current rental first.");
            }
            else
            {
                DateTime d = DateTime.Today;
                MessageBox.Show("rent successfull" + d.Date.ToString("d"));                
               //MessageBox.Show(userStatus.Rows[0]["cur"]);
                RentMovie(con, num, movie, select);
                rent.Text = "Rented";
                rent.Enabled = false;
            }
            //MessageBox.Show("not null");
        }

        public void Wish_Click(object sender, EventArgs e) {
            Button btn = (Button)sender;
            MessageBox.Show("add to wishlist");
            SqlConnection con = new SqlConnection(Form4.connectionString);
            con.Open();
            string insert = "INSERT dbo.[MovieQueue](CID, MID, Sequence)  VALUES(@cid, @mid, (Select MAX(Sequence) + 1 from MovieQueue mq where mq.CID = '"+ UC1.id+"'))";
            SqlCommand sc = new SqlCommand(insert, con);
            //sc.Parameters.AddWithValue("@oid", "006");
           
            sc.Parameters.AddWithValue("@mid", MID);
            sc.Parameters.AddWithValue("@cid", UC1.id);
            //sc.Parameters.AddWithValue("@actual", null);
            sc.ExecuteNonQuery();
            con.Close();
            wishlist.Text = "Added";
            wishlist.Enabled = false;
        }

        private void moviePage(object sender, EventArgs e) {
            LinkLabel lb = (LinkLabel)sender;
            MovieForm mv = new MovieForm(MID);
            mv.Show();
        }
    }
}
