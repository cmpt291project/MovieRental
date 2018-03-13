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


    public partial class Form2 : Form
    {
        string connectionString = "Data Source=DESKTOP-MJ5OPGU;Initial Catalog=MovieRental;Integrated Security=True";
        public Form2()
        {
            InitializeComponent();
            
        }

        void FillData()
        {

            //string connectionString = "Data Source=DESKTOP-V2MG4LO;Initial Catalog=MovieRental;Integrated Security=True";
            //var cs = System.Configuration.ConfigurationManager.
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            //Console.WriteLine("SELECT * FROM Actor WHERE FirstName=" + textBox1.Text);

            SqlDataAdapter a = new SqlDataAdapter("SELECT FirstName, LastName FROM Actor WHERE FirstName ='" + textBox1.Text + "'", connection);

            DataTable t = new DataTable();
            a.Fill(t);
            dataGridView1.DataSource = t;
            connection.Close();
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                FillData();
                Console.WriteLine(tabControl1.SelectedIndex);
            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(comboBox1.Text);
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            //Console.WriteLine("SELECT * FROM Actor WHERE FirstName=" + textBox1.Text);

            SqlDataAdapter a = new SqlDataAdapter("SELECT MovieName, NumberOfCopies FROM Movie " +
                "WHERE MovieType ='" + comboBox1.Text + "'", connection);

            DataTable t = new DataTable();
            a.Fill(t);
            dataGridView1.DataSource = t;
            connection.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            groupBox1.Visible = false;
            groupBox3.Visible = false;
            groupBox7.Visible = true;
            groupBox8.Visible = true;
            groupBox9.Visible = true;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox6.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


 //       private void button6_Click(object sender, EventArgs e)
 //       {
 //           movieslist.Items.Add("1"); 
 //       }

        private void button6_Click_1(object sender, EventArgs e)
        {
            movielist.Items.Add("1");
            //groupBox13.Controls.Add(name);
            //name.Text = "Yo";
            
            createNewBox(ranking);
        }

        private void createNewBox(Panel p) {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlDataAdapter dataAdapter= new SqlDataAdapter("SELECT top 5 * from(Select AVG(Rating) as rate, MID FROM MovieRating group by MID) as T", connection);
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
                gb.Left = 3+ i*200;
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
        private void ranking_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}
