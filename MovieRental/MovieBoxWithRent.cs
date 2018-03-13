using System;

public class MovieBoxWithRent
{
	public MovieBoxWithRent()
	{
        
    }
    private void createNewBox(Panel p)
    {
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();
        SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT top 5 * from(Select AVG(Rating) as rate, MID FROM MovieRating group by MID) as T", connection);
        DataTable dataTable = new DataTable();
        dataAdapter.Fill(dataTable);
        foreach (DataRow row in dataTable.Rows)
        {
            //foreach (DataColumn column in dataTable.Columns)
            //{
            Console.WriteLine(row["MID"]);
            //}
        }
        connection.Close();
        for (int i = 0; i < 5; i++)
        {
            GroupBox gb = new GroupBox();
            gb.Name = "movie";
            gb.Location = new Point(3, 3);
            gb.Size = new Size(200, 290);
            gb.Top = 3;
            gb.Left = 3 + i * 200;
            gb.Text = "Movie";
            gb.FlatStyle = FlatStyle.Standard;
            PictureBox moviePic = new PictureBox();
            moviePic.Name = "pic";
            moviePic.Location = new Point(6, 18);
            moviePic.Size = new Size(180, 210);
            moviePic.Top = 10;
            moviePic.Left = 5;
            moviePic.BackColor = Color.White;
            moviePic.Image = (Image)Properties.Resources.ResourceManager.GetObject("mad max");
            moviePic.SizeMode = PictureBoxSizeMode.Zoom;
            gb.Controls.Add(moviePic);
            LinkLabel movieName = new LinkLabel();
            movieName.Name = "movieName";
            movieName.Text = "Name";
            movieName.Location = new Point(8, 429);
            movieName.Font = new Font("Serif", 10);
            movieName.Top = 225;
            movieName.Left = 3;
            gb.Controls.Add(movieName);
            Label score = new Label();
            score.Name = "score";
            score.Text = "5.0";
            score.Font = new Font("Serif", 10);
            score.Location = new Point(8, 429);
            score.Top = 225;
            score.Left = 160;
            gb.Controls.Add(score);
            Button rent = new Button();
            rent.Name = "rent" + i;
            rent.Size = new Size(75, 35);
            rent.Top = 250;
            rent.Left = 3;
            rent.Text = "Rent Now";
            rent.Click += new EventHandler(NewButton_Click);
            gb.Controls.Add(rent);
            Button wishlist = new Button();
            wishlist.Name = "wishlist";
            wishlist.Size = new Size(75, 35);
            wishlist.Top = 250;
            wishlist.Left = 120;
            wishlist.Text = "Add To Wishlist";
            gb.Controls.Add(wishlist);
            p.Controls.Add(gb);

        }
    }
    private void NewButton_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;

        for (int i = 0; i < 5; i++)
        {
            if (btn.Name == ("rent" + i))
            {
                MessageBox.Show("Hello from " + btn.Name);
                // When find specific button do what do you want.
                //Then exit from loop by break.
                break;
            }
        }
    }
}
