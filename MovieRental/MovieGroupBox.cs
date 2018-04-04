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
    class MovieGroupBox
    {
        public GroupBox groupBox;
        public PictureBox pictureBox;
        public TextBox textBox;
        public string MID;
        public string[] defaultString = { "Name:", "Director:", "Type:", "Release Date:", "Return Date:" };
        public MovieGroupBox()
        {
            groupBox = new GroupBox();
            pictureBox = new PictureBox();
            textBox = new TextBox();
        }
        
        public void setGroupBox(Panel tabpage, int index)
        {
            groupBox.Name = "Movie Name";
            groupBox.Location = new Point(150, 200);
            groupBox.Size = new Size(400, 200);
            groupBox.Top = index * 220 - 195;
            groupBox.Left = 65;
            groupBox.BackColor = Color.FromArgb(222, 222, 255);
            //groupBox.Text = "Movie Title";
            groupBox.Font = new Font("Segoe UI", 15);
            groupBox.FlatStyle = FlatStyle.Standard;
            tabpage.Controls.Add(groupBox);
        }

        public void setLabel(GroupBox groupBox, string labelname)
        {
            Label label1 = new Label();
            label1.Location = new Point(-50, 0);
            label1.Size = new Size(50, 10);
            label1.Text = labelname;
            groupBox.Controls.Add(label1);
        }

        public void setImage(GroupBox groupBox, Image ximage)
        {
            PictureBox image = new PictureBox();
            image.Location = new Point(0, 0);
            image.Size = new Size(180, 180);
            image.Top = 10;
            image.Left = -20;
            image.Image = ximage;
            image.SizeMode = PictureBoxSizeMode.Zoom;
            groupBox.Controls.Add(image);
        }
        
        public void setMovieInfo(GroupBox groupBox, string name, string director, string actor, string date, string returndate, string mid)
        {
            MID = mid;
            for (int i = 0; i < 5; i++)
            {
                Label label = new Label();
                label.Text = defaultString[i];
                label.Font = new Font("Segoe UI", 11);
                label.ForeColor = System.Drawing.Color.FromArgb(0, 128, 255);
                label.Location = new Point(155, 0);
                label.Size = new Size(91, 30);
                label.Top =  i * 30 + 30;
                groupBox.Controls.Add(label);

                TextBox text = new TextBox();
                switch (i)
                {
                    case 0:
                        text.Text = name;
                        break;
                    case 1:
                        text.Text = director;
                        break;
                    case 2:
                        text.Text = actor;
                        break;
                    case 3:
                        text.Text = date;
                        break;
                    case 4:
                        text.Text = returndate;
                        break;
                    default:
                        break;
                }
                text.Font = new Font("Segoe UI", 11);
                text.Location = new Point(260, 0);
                text.Size = new Size(135, 21);
                text.Top = i * 30 + 25;
                groupBox.Controls.Add(text);

            }  
        }

        public void SetChooseMovieButton(GroupBox groupBox, string name)
        {
            Button button = new Button();
            button.Location = new Point(220, 175);
            button.Text = name;
            button.Font = new Font("Segoe UI", 9);
            button.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
            groupBox.Controls.Add(button);
            button.Click += new EventHandler(AddMovieToRentList);
        }

        public void SetReturnButton(GroupBox groupBox, string name)
        {
            Button button = new Button();
            button.Location = new Point(220, 175);
            button.Text = name;
            button.Font = new Font("Segoe UI", 9);
            button.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
            groupBox.Controls.Add(button);
            button.Click += new EventHandler(returnMovieFromCurrent);
        }

        public void returnMovieFromCurrent(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(Form4.connectionString);
            connection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select ActualReturnDate, OID from [Order] as O where O.CID ='" + UC1.id +"' and ActualReturnDate is null", connection);
            SqlDataAdapter selectMovie = new SqlDataAdapter("SELECT CurrentNum, MID from Movie M where M.MID = " + MID, connection);
            DataTable movieRow = new DataTable();
            selectMovie.Fill(movieRow);
            int num = Convert.ToInt32(movieRow.Rows[0]["CurrentNum"]);
            movieRow.Rows[0].BeginEdit();
            movieRow.Rows[0]["CurrentNum"] = num + 1;
            movieRow.Rows[0].EndEdit();
            SqlCommandBuilder sd = new SqlCommandBuilder(selectMovie);
            selectMovie.Update(movieRow);

            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataTable.Rows[0].BeginEdit();
            DateTime date = DateTime.Today;
            dataTable.Rows[0]["ActualReturnDate"] = date.Date.ToString("d");
            dataTable.Rows[0].EndEdit();
            SqlCommandBuilder sb = new SqlCommandBuilder(dataAdapter);
            dataAdapter.Update(dataTable);
            connection.Close();
            MessageBox.Show("Return Successfully!");
            YourMovieControl.Instance.createCurrentRental();
            updateall();
        }

        public void DeleteMovieFromListButton(GroupBox groupBox, string name)
        {
            Button button = new Button();
            button.Location = new Point(320, 175);
            button.Text = name;
            button.Font = new Font("Segoe UI", 9);
            button.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
            groupBox.Controls.Add(button);
            button.Click += new EventHandler(DeleteFromWishList);
        }

        public void DeleteFromWishList(object sender, EventArgs e)
        {
            DeleteMovieInWishList();
        }

        public void DeleteMovieInWishList()
        {
            SqlConnection con = new SqlConnection(Form4.connectionString);
            con.Open();
            SqlCommand delete = new SqlCommand("DELETE FROM MovieQueue WHERE MID = '" + MID + "'");
            delete.Connection = con;
            delete.ExecuteNonQuery();
            con.Close();
            updateall();
        }

        public void AddMovieToRentList(object sender, EventArgs e)
        {

                if (CheckMovieRent("Order") == true)
                {
                    rent("Order");
                    MessageBox.Show("Rent Successfully!");
                    updateall();
                }
                else
                {
                    MessageBox.Show("You can only rent a limited number of movies at a time.");
                }

            


        }

        private bool CheckMovieRent(string name)
        {
            SqlConnection connection = new SqlConnection(Form4.connectionString);
            connection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select ActualReturnDate, O.MID, M.CurrentNum from["+ name + "] O, Movie M where O.CID =" + UC1.id, connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            foreach (DataRow row in dataTable.Rows)
            {
                //MessageBox.Show(row["ActualReturnDate"].ToString());
                if (row["ActualReturnDate"].ToString() == "")
                {
                    return false;
                }
            }
            //MessageBox.Show(dataTable.Rows.Count.ToString());
            connection.Close();
            return true;
        }

        private void rent(string name)
        {
            DataTable movie = new DataTable();
            SqlConnection connection = new SqlConnection(Form4.connectionString);
            connection.Open();
            SqlDataAdapter selectMovie = new SqlDataAdapter("SELECT * from Movie M where M.MID = " + MID, connection);
            selectMovie.Fill(movie);
            SqlCommandBuilder sb = new SqlCommandBuilder(selectMovie);
            int num = Convert.ToInt32(movie.Rows[0]["CurrentNum"]);
            movie.Rows[0].BeginEdit();
            movie.Rows[0]["CurrentNum"] = num - 1;
            movie.Rows[0].EndEdit();

            selectMovie.Update(movie);

            string insert = "INSERT dbo.[" + name + "](OID, MID, CID, EID, OrderDate, ReturnDate)  VALUES((Select MAX(OID)+1 from [Order]), @mid, @cid, @eid, @date, @return)";
            SqlCommand sc = new SqlCommand(insert, connection);
            DateTime date = DateTime.Today;
            DateTime ret = new DateTime(date.Year, date.Month + 1, date.Day);
            if (date.Month == 12)
            {
                ret = new DateTime(date.Year + 1, 1, date.Day);
            }
            
            sc.Parameters.AddWithValue("@mid", MID);
            sc.Parameters.AddWithValue("@cid", UC1.id);
            sc.Parameters.AddWithValue("@eid", "001");
            sc.Parameters.AddWithValue("@date", date.Date.ToString("d"));
            sc.Parameters.AddWithValue("@return", ret);
            //sc.Parameters.AddWithValue("@actual", null);
            sc.ExecuteNonQuery();
            connection.Close();
            DeleteMovieInWishList();
            YourMovieControl.Instance.createWishList();
        }


        private void updateall()
        {
            Ranking.Instance.update();

        }
    }
}
