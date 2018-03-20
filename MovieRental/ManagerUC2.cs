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
        private string EID;
        private string newAID;
        private string newEID;
        SqlConnection con = new SqlConnection(Form4.connectionString);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adapt;

        public ManagerUC2()
        {
            InitializeComponent();
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(panel3);
            Controls.Add(panel4);
            panel1.BringToFront();
            dataGridView1.BringToFront();
            DisplayData();
           
        }

        private void btnInsertCasting_Click(object sender, EventArgs e)
        {
            using (cmd = new SqlCommand("insert into Casting(MID,AID) values(@MID,@AID)", con))
            {

                con.Open();
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@AID", AIDtxt.Text);
                cmd.Parameters.AddWithValue("@MID", MIDtxt.Text);
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        private void btnInsertActor_Click(object sender, EventArgs e)
        {
            using (cmd = new SqlCommand("select MAX(CAST(AID as int))+1 from Actor", con))
            {
                con.Open();
                //Console.WriteLine(cmd.ExecuteScalar().ToString());
                newAID = cmd.ExecuteScalar().ToString();
                //Console.WriteLine(newMID);
                //int test = Convert.ToInt32(maxID);
                //Console.WriteLine(test);
                con.Close();

            }
            
            cmd = new SqlCommand("insert into Actor(AID,LastName,FirstName,Gender,DateOfBirth) " +
                    "values(@AID,@lname,@fname,@gender,@dob)", con);
            con.Open();
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@AID", newAID);
            cmd.Parameters.AddWithValue("@lname", LastNameTxt.Text);
            cmd.Parameters.AddWithValue("@fname", BirthdateTxt.Text);
            cmd.Parameters.AddWithValue("@gender", FirstNameTxt.Text);
            cmd.Parameters.AddWithValue("@dob", GenderTxt.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            DisplayActors();

               

            
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
                cmd.Parameters.Clear();
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
        private void btnInsertEmployee_Click(object sender, EventArgs e)
        {
            using (cmd = new SqlCommand("select MAX(CAST(EID as int))+1 from Employee", con))
            {
                con.Open();
                //Console.WriteLine(cmd.ExecuteScalar().ToString());
                newEID = cmd.ExecuteScalar().ToString();
                Console.WriteLine(newEID);
                //int test = Convert.ToInt32(maxID);
                //Console.WriteLine(test);
                con.Close();

            }
            cmd = new SqlCommand("insert into Employee(EID,SocialSecurityNumber,LastName,FirstName,Street,City,State," +
                "ZipCode,Telephone,StartDate,HourlyRate,EmployeeType,EmailAddress) values(@EID,@socialsec,@lastname," +
                "@firstname,@street,@city,@state,@zipcode,@phone,@startdate,@hrate,@type,@email)", con);
            con.Open();
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@EID", newEID);
            cmd.Parameters.AddWithValue("@socialsec", SocialSecurityTxt.Text);
            cmd.Parameters.AddWithValue("@lastname", eLastNameTxt.Text);
            cmd.Parameters.AddWithValue("@firstname", eFirstNameTxt.Text);
            cmd.Parameters.AddWithValue("@street", StreetTxt.Text);
            cmd.Parameters.AddWithValue("@city", CityTxt.Text);
            cmd.Parameters.AddWithValue("@state", StateTxt.Text);
            cmd.Parameters.AddWithValue("@zipcode", ZipCodeTxt.Text);
            cmd.Parameters.AddWithValue("@phone", TelephoneTxt.Text);
            cmd.Parameters.AddWithValue("@startdate", StartDateTxt.Text);
            cmd.Parameters.AddWithValue("@hrate", HourlyRateTxt.Text);
            cmd.Parameters.AddWithValue("@type", TypeTxt.Text);
            cmd.Parameters.AddWithValue("@email", EmailTxt.Text);
            cmd.ExecuteNonQuery();
            con.Close();
           

            cmd = new SqlCommand("insert into Password(EmailAddress,Password,EID,CID,UserType) values(@email,@password,@EID,@CID,@type)", con);
            con.Open();
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@email", EmailTxt.Text);
            cmd.Parameters.AddWithValue("@password", PasswordTxt.Text);
            cmd.Parameters.AddWithValue("@EID", newEID);
            cmd.Parameters.AddWithValue("@CID", DBNull.Value);
            cmd.Parameters.AddWithValue("@type", "e");
            cmd.ExecuteNonQuery();
            con.Close();
            DisplayEmployees();
        }

        private void btnUpdateEmployee_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("update Employee set SocialSecurityNumber=@socialsec, LastName=@lastname, FirstName=@firstname," +
                "Street=@street, City=@city, State=@state, ZipCode=@zipcode, Telephone=@phone, StartDate=@startdate," +
                "HourlyRate=@hrate, EmployeeType=@type, EmailAddress=@email where EID=@eid", con);
            con.Open();
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@eid", EID);
            cmd.Parameters.AddWithValue("@socialsec", SocialSecurityTxt.Text);
            cmd.Parameters.AddWithValue("@lastname", eLastNameTxt.Text);
            cmd.Parameters.AddWithValue("@firstname", eFirstNameTxt.Text);
            cmd.Parameters.AddWithValue("@street", StreetTxt.Text);
            cmd.Parameters.AddWithValue("@city", CityTxt.Text);
            cmd.Parameters.AddWithValue("@state", StateTxt.Text);
            cmd.Parameters.AddWithValue("@zipcode", ZipCodeTxt.Text);
            cmd.Parameters.AddWithValue("@phone", TelephoneTxt.Text);
            cmd.Parameters.AddWithValue("@startdate", StartDateTxt.Text);
            cmd.Parameters.AddWithValue("@hrate", HourlyRateTxt.Text);
            cmd.Parameters.AddWithValue("@type", TypeTxt.Text);
            cmd.Parameters.AddWithValue("@email", EmailTxt.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            DisplayEmployees();
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

        private void DisplayEmployees()
        {
            con.Open();
            DataTable dt4 = new DataTable();
            adapt = new SqlDataAdapter("SELECT * from Employee", con);
            adapt.Fill(dt4);
            dataGridView4.DataSource = dt4;
            con.Close();

        }

        private void DisplayActors()
        {
            con.Open();
            DataTable dt2 = new DataTable();
            adapt = new SqlDataAdapter("SELECT * from Actor", con);
            adapt.Fill(dt2);
            dataGridView2.DataSource = dt2;
            con.Close();
            
        }
        private void DisplayRecentMovies()
        {
            con.Open();
            DataTable dt3 = new DataTable();
            adapt = new SqlDataAdapter("SELECT TOP 5 * from Movie order by AddDate DESC", con);
            adapt.Fill(dt3);
            dataGridView3.DataSource = dt3;
            con.Close();
        }

        private void ActiveEmployees()
        {
            con.Open();
            DataTable dt5 = new DataTable();
            adapt = new SqlDataAdapter("select * from Employee as E, (select top 1 EID, count(*) as numOrder from [Order]" +
                "group by EID) as most where E.EID = most.EID", con);
            adapt.Fill(dt5);
            dataGridView5.DataSource = dt5;
            dataGridView5.Columns["EID1"].Visible = false;
            con.Close();
        }

        private void ActiveCustomers()
        {

            con.Open();
            DataTable dt5 = new DataTable();
            adapt = new SqlDataAdapter("select * from Customer as C, (select top 3 CID, count(*) as numOrder from [Order]" +
                "group by CID) as Active where C.CID = Active.CID", con);
            adapt.Fill(dt5);
            dataGridView5.DataSource = dt5;
            dataGridView5.Columns["CID1"].Visible = false;
            con.Close();
        }

        private void ActiveRentals()
        {
            con.Open();
            DataTable dt5 = new DataTable();
            adapt = new SqlDataAdapter("select * from Movie as M, (select top 3 MID, count(*) as numRentals from [Order] " +
                "group by MID) as Active where M.MID = Active.MID", con);
            adapt.Fill(dt5);
            dataGridView5.DataSource = dt5;
            dataGridView5.Columns["MID1"].Visible = false;
            con.Close();

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

        private void dataGridView4_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            EID = dataGridView4.Rows[e.RowIndex].Cells[0].Value.ToString();
            SocialSecurityTxt.Text = dataGridView4.Rows[e.RowIndex].Cells[1].Value.ToString();
            eLastNameTxt.Text = dataGridView4.Rows[e.RowIndex].Cells[2].Value.ToString();
            eFirstNameTxt.Text = dataGridView4.Rows[e.RowIndex].Cells[3].Value.ToString();
            StreetTxt.Text = dataGridView4.Rows[e.RowIndex].Cells[4].Value.ToString();
            CityTxt.Text = dataGridView4.Rows[e.RowIndex].Cells[5].Value.ToString();
            StateTxt.Text = dataGridView4.Rows[e.RowIndex].Cells[6].Value.ToString();
            ZipCodeTxt.Text = dataGridView4.Rows[e.RowIndex].Cells[7].Value.ToString();
            TelephoneTxt.Text = dataGridView4.Rows[e.RowIndex].Cells[8].Value.ToString();
            char[] delimiterChars = { ' ' };
            string[] startDateStrings = dataGridView4.Rows[e.RowIndex].Cells[9].Value.ToString().Split(delimiterChars);
            StartDateTxt.Text = startDateStrings[0];
            HourlyRateTxt.Text = dataGridView4.Rows[e.RowIndex].Cells[10].Value.ToString();
            TypeTxt.Text = dataGridView4.Rows[e.RowIndex].Cells[11].Value.ToString();
            EmailTxt.Text = dataGridView4.Rows[e.RowIndex].Cells[12].Value.ToString();

        }

        private void dataGridView4_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (dataGridView4.CurrentRow.Cells["EID"].Value != DBNull.Value)
            {
                if (MessageBox.Show("Delete this Record?", "DataGridView", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (SqlConnection sqlCon = new SqlConnection(Form4.connectionString))
                    {
                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("EmployeeDeleteByID", sqlCon);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@EID", dataGridView4.CurrentRow.Cells["EID"].Value.ToString());
                        sqlCmd.ExecuteNonQuery();
                        sqlCon.Close();
                    }
                    using (SqlConnection sqlCon = new SqlConnection(Form4.connectionString))
                    {
                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("Delete from Password Where EID=@EID", sqlCon);
                        sqlCmd.Parameters.AddWithValue("EID", dataGridView4.CurrentRow.Cells["EID"].Value.ToString());
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


        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView2.BringToFront();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView3.BringToFront();
            DisplayRecentMovies();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(comboBox1.SelectedIndex);
            switch(comboBox1.SelectedIndex)
            {
                case 0:
                    panel1.BringToFront();
                    dataGridView1.BringToFront();
                    break;

                case 1:
                    panel2.BringToFront();
                    DisplayActors();
                    dataGridView2.BringToFront();
                    
                    break;
                case 2:
                    Console.WriteLine("Employees");
                    panel3.BringToFront();
                    DisplayEmployees();
                    dataGridView4.BringToFront();
                    break;

                case 3:
                    Console.WriteLine("Rentals");
                    panel4.BringToFront();
                    dataGridView5.BringToFront();
                    break;

                default:
                    Console.WriteLine("DEFAULT");
                    break;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(comboBox2.SelectedIndex)
            {
                case 0:
                    ActiveEmployees();
                    break;

                case 1:
                    ActiveCustomers();
                    break;

                case 2:
                    ActiveRentals();
                    break;
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            Console.WriteLine(searchTxt.Text);
            // movie name
            // movie type
            // customer email or CID

        }
    }
}
