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
using System.IO;

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
        string strFilePath = "";
        Image DefaultImage;
        Byte[] ImageByteArray;

        public ManagerUC2()
        {
            InitializeComponent();
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(panel3);
            Controls.Add(panel4);
            Controls.Add(panel5);
            panel5.Controls.Add(dataGridView1);
            panel5.Controls.Add(dataGridView2);
            panel5.Controls.Add(dataGridView3);
            panel5.Controls.Add(dataGridView4);
            panel5.Controls.Add(dataGridView5);
            panel5.Controls.Add(dataGridView6);
            /*Controls.Add(dataGridView1);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView3);
            Controls.Add(dataGridView4);
            Controls.Add(dataGridView5);
            Controls.Add(dataGridView6);*/
            panel1.BringToFront();
            dataGridView1.BringToFront();
            
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM-yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "MM/dd/yyyy";
            dateTimePicker3.Format = DateTimePickerFormat.Custom;
            dateTimePicker3.CustomFormat = "MM/dd/yyyy";
            dateTimePicker4.Format = DateTimePickerFormat.Custom;
            dateTimePicker4.CustomFormat = "MM/dd/yyyy";
            dateTimePicker5.Format = DateTimePickerFormat.Custom;
            dateTimePicker5.CustomFormat = "MM/dd/yyyy";

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = (Image)Properties.Resources.ResourceManager.GetObject("Noimage");
            pictureBox1.Tag = 1;
            Console.WriteLine(pictureBox1.Tag);
            DisplayData();

        }

        private void btnInsertCasting_Click(object sender, EventArgs e)
        {
            if (MIDtxt.Text != "" && AIDtxt.Text != "")
            {
                if (!ValidateCastingForm())
                {
                    MessageBox.Show("Please fix error.");
                    return;
                }
                using (cmd = new SqlCommand("select top 1 * from Casting as C where C.AID=@AID and C.MID=@MID", con))
                {
                    con.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@AID", AIDtxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@MID", MIDtxt.Text.Trim());
                    string test = (string)cmd.ExecuteScalar();

                    con.Close();
                    if (test != null)
                    {
                        MessageBox.Show("Record already exists.");
                        return;
                    }
                }
                using (cmd = new SqlCommand("insert into Casting(MID,AID) values(@MID,@AID)", con))
                {

                    con.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@AID", AIDtxt.Text);
                    cmd.Parameters.AddWithValue("@MID", MIDtxt.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    ClearCastingData();

                }
            }
            else
                MessageBox.Show("Please fill out Casting fields.");
        }

        private void btnInsertActor_Click(object sender, EventArgs e)
        {
            if (LastNameTxt.Text != "" && FirstNameTxt.Text != "" && genderCB.Text != "")
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
                cmd.Parameters.AddWithValue("@fname", FirstNameTxt.Text);
                //cmd.Parameters.AddWithValue("@gender", GenderTxt.Text);
                cmd.Parameters.AddWithValue("@gender", genderCB.Text);
                //cmd.Parameters.AddWithValue("@dob", BirthdateTxt.Text);
                cmd.Parameters.AddWithValue("@dob", Convert.ToDateTime(dateTimePicker4.Text));
                cmd.ExecuteNonQuery();
                con.Close();
                DisplayActors();
                ClearActorData();

            }
            else
                MessageBox.Show("Please fill out Actor fields.");

            
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            if (MovieNameTxt.Text != "" && MovieTypeTxt.Text != "" && DistFeeTxt.Text != "" && NumCopiesTxt.Text != ""
                && DirectorTxt.Text != "" && CurrentNumTxt.Text != "" && picNameTxt.Text.Trim() != "" && (int)pictureBox1.Tag != 1)
            {
                if (strFilePath == "")
                {
                    if (ImageByteArray.Length != 0)
                    {
                        ImageByteArray = new byte[] { };
                    }
                }
                else
                {
                    Image temp = new Bitmap(strFilePath);
                    MemoryStream strm = new MemoryStream();
                    temp.Save(strm, System.Drawing.Imaging.ImageFormat.Jpeg);
                    ImageByteArray = strm.ToArray();
                }

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
                    "ReleaseDate,AddDate,Director,CurrentNum,Poster,PosterTitle) values(@MID,@name,@type,@distFee,@numCopies,@releaseDate" +
                    ",@addDate,@director,@currNum,@poster,@posterTitle)", con);
                con.Open();
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@MID", newMID);
                cmd.Parameters.AddWithValue("@name", MovieNameTxt.Text);
                cmd.Parameters.AddWithValue("@type", MovieTypeTxt.Text);
                cmd.Parameters.AddWithValue("@distFee", DistFeeTxt.Text);
                cmd.Parameters.AddWithValue("@numCopies", NumCopiesTxt.Text);
                //cmd.Parameters.AddWithValue("@releaseDate", ReleaseDateTxt.Text);
                cmd.Parameters.AddWithValue("@releaseDate", Convert.ToDateTime(dateTimePicker2.Text));
                cmd.Parameters.AddWithValue("@addDate", Convert.ToDateTime(dateTimePicker3.Text));

                //cmd.Parameters.AddWithValue("@addDate", AddDateTxt.Text);
                cmd.Parameters.AddWithValue("@director", DirectorTxt.Text);
                cmd.Parameters.AddWithValue("@currNum", CurrentNumTxt.Text);
                cmd.Parameters.AddWithValue("@poster", ImageByteArray);
                cmd.Parameters.AddWithValue("@posterTitle", picNameTxt.Text.Trim());
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
            if (eLastNameTxt.Text != "" && eFirstNameTxt.Text != "" && StreetTxt.Text != "" && CityTxt.Text != ""
                && StateTxt.Text != "" && ZipCodeTxt.Text != "" && TelephoneTxt.Text != "" && HourlyRateTxt.Text != ""
                && TypeCB.Text != "" && SocialSecurityTxt.Text != "" && EmailTxt.Text != "" && PasswordTxt.Text != "")
            {
                if (!ValidateEmployeeForm())
                {
                    MessageBox.Show("Please fix errors.");
                    return;
                }

                using (cmd = new SqlCommand("select top 1 * from Password where EmailAddress=@email", con))
                {
                    con.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@email", EmailTxt.Text);
                    string test = (string)cmd.ExecuteScalar();

                    con.Close();
                    if (test != null)
                    {
                        MessageBox.Show("Email Already Exists.");
                        return;
                    }
                }

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
                cmd.Parameters.AddWithValue("@socialsec", SocialSecurityTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@lastname", eLastNameTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@firstname", eFirstNameTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@street", StreetTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@city", CityTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@state", StateTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@zipcode", ZipCodeTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@phone", TelephoneTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@startdate", Convert.ToDateTime(dateTimePicker5.Text));
                cmd.Parameters.AddWithValue("@hrate", HourlyRateTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@type", TypeCB.Text.Trim());
                cmd.Parameters.AddWithValue("@email", EmailTxt.Text.Trim());
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
                ClearEmployeeData();
            }
            else
                MessageBox.Show("Please fill out the fields.");
        }

        private void btnUpdateEmployee_Click(object sender, EventArgs e)
        {
            if (eLastNameTxt.Text != "" && eFirstNameTxt.Text != "" && StreetTxt.Text != "" && CityTxt.Text != ""
                && StateTxt.Text != "" && ZipCodeTxt.Text != "" && TelephoneTxt.Text != "" && HourlyRateTxt.Text != ""
                && TypeCB.Text != "" && SocialSecurityTxt.Text != "" && EmailTxt.Text != "")
            {
                if (!ValidateEmployeeForm())
                {
                    MessageBox.Show("Please fix errors.");
                    return;
                }

                using (cmd = new SqlCommand("select EmailAddress from Password where EID=@eid", con))
                {
                    con.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@eid", EID);
                    string test = (string)cmd.ExecuteScalar();
                    Console.WriteLine(test.Trim() + " " + EmailTxt.Text.Trim());
                    if (test.Trim() == EmailTxt.Text.Trim())
                    {
                        Console.WriteLine("Emails Match");
                    }
                    else
                    {
                        cmd = new SqlCommand("select EmailAddress from Password where EmailAddress=@email", con);
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@email", EmailTxt.Text.Trim());
                        string test2 = (string)cmd.ExecuteScalar();
                        if (test2.Trim() != null)
                        {
                            con.Close();
                            MessageBox.Show("Email Already Exists.");
                            return;

                        }
                    }
                    
                    con.Close();
                }
               


                cmd = new SqlCommand("update Employee set SocialSecurityNumber=@socialsec, LastName=@lastname, FirstName=@firstname," +
                    "Street=@street, City=@city, State=@state, ZipCode=@zipcode, Telephone=@phone, StartDate=@startdate," +
                    "HourlyRate=@hrate, EmployeeType=@type, EmailAddress=@email where EID=@eid", con);
                con.Open();
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@eid", EID);
                cmd.Parameters.AddWithValue("@socialsec", SocialSecurityTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@lastname", eLastNameTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@firstname", eFirstNameTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@street", StreetTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@city", CityTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@state", StateTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@zipcode", ZipCodeTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@phone", TelephoneTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@startdate", Convert.ToDateTime(dateTimePicker5.Text));
                cmd.Parameters.AddWithValue("@hrate", HourlyRateTxt.Text.Trim());
                cmd.Parameters.AddWithValue("@type", TypeCB.Text.Trim());
                cmd.Parameters.AddWithValue("@email", EmailTxt.Text);
                cmd.ExecuteNonQuery();
                con.Close();

                if (PasswordTxt.Text.Trim() != "")
                {
                    cmd = new SqlCommand("update Password set EmailAddress=@email, Password=@password, EID=@EID, CID=@CID,UserType=@type where EID=@EID", con);
                    con.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@email", EmailTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", PasswordTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@EID", EID);
                    cmd.Parameters.AddWithValue("@CID", DBNull.Value);
                    cmd.Parameters.AddWithValue("@type", "e");
                    cmd.ExecuteNonQuery();
                    con.Close();


                }
                if (PasswordTxt.Text.Trim() == "")
                {
                    cmd = new SqlCommand("update Password set EmailAddress=@email, EID=@EID, CID=@CID,UserType=@type where EID=@EID", con);
                    con.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@email", EmailTxt.Text.Trim());
                    cmd.Parameters.AddWithValue("@EID", EID);
                    cmd.Parameters.AddWithValue("@CID", DBNull.Value);
                    cmd.Parameters.AddWithValue("@type", "e");
                    cmd.ExecuteNonQuery();
                    con.Close();


                }

                DisplayEmployees();
                ClearEmployeeData();
            }
            else
                MessageBox.Show("Please fill out the fields.");
        }


        private void Update_Click(object sender, EventArgs e)
        {
            if (MovieNameTxt.Text != "" && MovieTypeTxt.Text != "" && DistFeeTxt.Text != "" && NumCopiesTxt.Text != ""
                && DirectorTxt.Text != "" && CurrentNumTxt.Text != "" && picNameTxt.Text.Trim() != "" && (int)pictureBox1.Tag != 1)
            {
                if (!ValidateMovieForm())
                {
                    MessageBox.Show("Please fix error.");
                    return;
                }
                Console.WriteLine("strFilePath: " + strFilePath);
                if (strFilePath == "")
                {
                    cmd = new SqlCommand("update Movie set MovieName=@name, MovieType=@type, DistribututionFee=@distfee, " +
                     "NumberOfCopies=@numCopies, ReleaseDate=@releaseDate, AddDate=@addDate, Director=@director, " +
                     "CurrentNum=@currNum, PosterTitle=@posterTitle where MID=@id", con);
                    con.Open();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@id", MID);
                    cmd.Parameters.AddWithValue("@name", MovieNameTxt.Text);
                    cmd.Parameters.AddWithValue("@type", MovieTypeTxt.Text);
                    cmd.Parameters.AddWithValue("@distFee", DistFeeTxt.Text);
                    cmd.Parameters.AddWithValue("@numCopies", NumCopiesTxt.Text);
                    //cmd.Parameters.AddWithValue("@releaseDate", ReleaseDateTxt.Text);
                    cmd.Parameters.AddWithValue("@releaseDate", Convert.ToDateTime(dateTimePicker2.Text));
                    cmd.Parameters.AddWithValue("@addDate", Convert.ToDateTime(dateTimePicker3.Text));
                    cmd.Parameters.AddWithValue("@director", DirectorTxt.Text);
                    cmd.Parameters.AddWithValue("@currNum", CurrentNumTxt.Text);
                    //cmd.Parameters.AddWithValue("@poster", ImageByteArray);
                    cmd.Parameters.AddWithValue("@posterTitle", picNameTxt.Text.Trim());
                    cmd.ExecuteNonQuery();
                    con.Close();

                    /*if (ImageByteArray.Length != 0)
                    {
                        ImageByteArray = new byte[] { };
                    }*/
                }
                else
                {
                    Image temp = new Bitmap(strFilePath);
                    MemoryStream strm = new MemoryStream();
                    temp.Save(strm, System.Drawing.Imaging.ImageFormat.Jpeg);
                    ImageByteArray = strm.ToArray();



                    //using (SqlConnection con = new SqlConnection(Form4.connectionString))
                    cmd = new SqlCommand("update Movie set MovieName=@name, MovieType=@type, DistribututionFee=@distfee, " +
                         "NumberOfCopies=@numCopies, ReleaseDate=@releaseDate, AddDate=@addDate, Director=@director, " +
                         "CurrentNum=@currNum, Poster=@poster, PosterTitle=@posterTitle where MID=@id", con);
                    con.Open();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@id", MID);
                    cmd.Parameters.AddWithValue("@name", MovieNameTxt.Text);
                    cmd.Parameters.AddWithValue("@type", MovieTypeTxt.Text);
                    cmd.Parameters.AddWithValue("@distFee", DistFeeTxt.Text);
                    cmd.Parameters.AddWithValue("@numCopies", NumCopiesTxt.Text);
                    //cmd.Parameters.AddWithValue("@releaseDate", ReleaseDateTxt.Text);
                    cmd.Parameters.AddWithValue("@releaseDate", Convert.ToDateTime(dateTimePicker2.Text));
                    cmd.Parameters.AddWithValue("@addDate", Convert.ToDateTime(dateTimePicker3.Text));
                    cmd.Parameters.AddWithValue("@director", DirectorTxt.Text);
                    cmd.Parameters.AddWithValue("@currNum", CurrentNumTxt.Text);
                    cmd.Parameters.AddWithValue("@poster", ImageByteArray);
                    cmd.Parameters.AddWithValue("@posterTitle", picNameTxt.Text.Trim());
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                DisplayData();
                ClearData();
            }
            else
            {
                Console.WriteLine("Please Try Again");
                MessageBox.Show("Please fill out all the fields.");
            }

        }

        private void UploadBtn_Click(object sender, EventArgs e)
        {
            //ImageUpload form = new ImageUpload();
            //form.Show();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images(.jpg,.png)|*.png;*.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                strFilePath = ofd.FileName;
                Console.WriteLine("strFilePath" + strFilePath);
                pictureBox1.Image = new Bitmap(strFilePath);
                if (picNameTxt.Text.Trim().Length == 0)
                    picNameTxt.Text = System.IO.Path.GetFileName(strFilePath);

                pictureBox1.Tag = 2;
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
            //pictureBox1.Image = (Image)dt.Rows[0][9];

            //byte[] img = (byte[])dt.Rows[1]["Poster"];
            /*Console.WriteLine(dt.Rows[0][10]);
            byte[] ImageArray = (byte[])dt.Rows[0][9];
            pictureBox1.Image = Image.FromStream(new MemoryStream(ImageArray));*/
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

        private void DisplayCasting()
        {
            con.Open();
            DataTable dt5 = new DataTable();
            adapt = new SqlDataAdapter("select * from Casting", con);
            adapt.Fill(dt5);
            dataGridView3.DataSource = dt5;
            con.Close();
        }

        private void ClearData()
        {
            MovieNameTxt.Clear();
            MovieTypeTxt.Clear();
            DistFeeTxt.Clear();
            NumCopiesTxt.Clear();
            DirectorTxt.Clear();
            CurrentNumTxt.Clear();
            picNameTxt.Clear();
            pictureBox1.Image = (Image)Properties.Resources.ResourceManager.GetObject("Noimage");
            pictureBox1.Tag = 1;
            searchMovieTxt.Clear();
        }

        private void ClearActorData()
        {
            LastNameTxt.Clear();
            FirstNameTxt.Clear();
            genderCB.SelectedIndex = -1;
            searchActorTxt.Clear();

        }
        private void ClearCastingData()
        {
            MIDtxt.Clear();
            AIDtxt.Clear();
        }

        private void ClearEmployeeData()
        {
            eLastNameTxt.Clear();
            eFirstNameTxt.Clear();
            StreetTxt.Clear();
            CityTxt.Clear();
            StateTxt.Clear();
            ZipCodeTxt.Clear();
            TelephoneTxt.Clear();
            HourlyRateTxt.Clear();
            //TypeTxt.Clear();
            TypeCB.SelectedIndex = -1;
            SocialSecurityTxt.Clear();
            EmailTxt.Clear();
            PasswordTxt.Clear();
        }

        private void ClearRentals()
        {
            MovieTypeCB.SelectedIndex = -1;
            searchTxt.Clear();
            Search2Txt.Clear();
            comboBox2.SelectedIndex = -1;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            MovieNameTxt.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            //movieName = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            MovieTypeTxt.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
            //movieType = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            DistFeeTxt.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();
            NumCopiesTxt.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString().Trim();
            /*char[] delimiterChars = {' '};
            string[] releaseDateStrings = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString().Split(delimiterChars);
            string[] addDateStrings = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString().Split(delimiterChars);
            ReleaseDateTxt.Text = releaseDateStrings[0];
            AddDateTxt.Text = addDateStrings[0];*/
            DirectorTxt.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString().Trim();
            CurrentNumTxt.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString().Trim();
            dateTimePicker2.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString().Trim();
            dateTimePicker3.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString().Trim();
            if (dataGridView1.Rows[e.RowIndex].Cells[9].Value == DBNull.Value)
            {
                pictureBox1.Image = (Image)Properties.Resources.ResourceManager.GetObject("Noimage");
                pictureBox1.Tag = 1;
            }
            else
            {
                byte[] ImageArray = (byte[])dataGridView1.Rows[e.RowIndex].Cells[9].Value;
                ImageByteArray = ImageArray;
                pictureBox1.Image = Image.FromStream(new MemoryStream(ImageArray));
                pictureBox1.Tag = 2;
            }
            picNameTxt.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString().Trim();
            //pictureBox1.Image = dataGridView1.Rows[e.RowIndex].Cells[9].Value;
            Console.WriteLine("picbox tag: " + (int)pictureBox1.Tag);

        }

        private void dataGridView4_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            EID = dataGridView4.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
            SocialSecurityTxt.Text = dataGridView4.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
            eLastNameTxt.Text = dataGridView4.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
            eFirstNameTxt.Text = dataGridView4.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();
            StreetTxt.Text = dataGridView4.Rows[e.RowIndex].Cells[4].Value.ToString();
            CityTxt.Text = dataGridView4.Rows[e.RowIndex].Cells[5].Value.ToString().Trim();
            StateTxt.Text = dataGridView4.Rows[e.RowIndex].Cells[6].Value.ToString().Trim();
            ZipCodeTxt.Text = dataGridView4.Rows[e.RowIndex].Cells[7].Value.ToString().Trim();
            TelephoneTxt.Text = dataGridView4.Rows[e.RowIndex].Cells[8].Value.ToString().Trim();
            dateTimePicker5.Text = dataGridView4.Rows[e.RowIndex].Cells[9].Value.ToString().Trim();
            HourlyRateTxt.Text = dataGridView4.Rows[e.RowIndex].Cells[10].Value.ToString().Trim();
            //TypeTxt.Text = dataGridView4.Rows[e.RowIndex].Cells[11].Value.ToString().Trim();
            if (dataGridView4.Rows[e.RowIndex].Cells[11].Value.ToString().Trim() == "manager")
                TypeCB.SelectedIndex = 1;
            else if (dataGridView4.Rows[e.RowIndex].Cells[11].Value.ToString().Trim() == "regular")
                TypeCB.SelectedIndex = 0;
            else
                TypeCB.SelectedIndex = -1;

            EmailTxt.Text = dataGridView4.Rows[e.RowIndex].Cells[12].Value.ToString().Trim();

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

            ClearData();
        }

        int pos = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Before" + pos);
            if (pos == 2)
            {
                dataGridView3.BringToFront();
                DisplayRecentMovies();
                pos--;
            }
            else if (pos == 1)
            {
                pos--;
                dataGridView2.BringToFront();
            }
            else
                dataGridView2.BringToFront();

            Console.WriteLine("After" + pos);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Before" + pos);
            if (pos == 0)
            {
                pos++;
                dataGridView3.BringToFront();
                DisplayRecentMovies();
            }
            else if (pos == 1)
            {
                DisplayCasting();
                pos++;
                
            }

            Console.WriteLine("After" + pos);
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
            Console.WriteLine(comboBox2.SelectedIndex);
            dataGridView5.BringToFront();

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

       

        private void searchTxt_TextChanged(object sender, EventArgs e)
        {
            Search2Txt.Clear();
            string searchString = searchTxt.Text.Trim();

            // movie name
            con.Open();
            DataTable dt5 = new DataTable();
            adapt = new SqlDataAdapter("select * from Movie where MovieName like @search and MID in (select MID from [Order])", con);
            adapt.SelectCommand.Parameters.AddWithValue("@search", "%" + searchString + "%");
            adapt.Fill(dt5);
            con.Close();
            if (dt5.Rows.Count > 0) 
                dataGridView5.DataSource = dt5;
            con.Close();
            dataGridView5.BringToFront();
        }

        private void Search2Txt_TextChanged(object sender, EventArgs e)
        {
            searchTxt.Clear();
            string searchString = Search2Txt.Text.Trim();
            con.Open();
            DataTable dt6 = new DataTable();
            adapt = new SqlDataAdapter("select * from [Order] where CID in (select CID from Customer where EmailAddress like @search)", con);
            adapt.SelectCommand.Parameters.Clear();
            adapt.SelectCommand.Parameters.AddWithValue("@search", "%" + searchString + "%");
            adapt.Fill(dt6);
            if (dt6.Rows.Count > 0)
                dataGridView5.DataSource = dt6;
            else
                Console.WriteLine("NO RESULTS AGAIN");
            con.Close();
            dataGridView5.BringToFront();
        }



        private void MovieTypeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt7 = new DataTable();
            Console.WriteLine(MovieTypeCB.Text);
            con.Open();
            adapt = new SqlDataAdapter("select * from [Order] where MID in (select MID from Movie where MovieType = @type)", con);
            adapt.SelectCommand.Parameters.Clear();
            adapt.SelectCommand.Parameters.AddWithValue("@type", MovieTypeCB.Text);
            adapt.Fill(dt7);
            dataGridView5.DataSource = dt7;
            dataGridView5.BringToFront();
            con.Close();



        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            Console.WriteLine(comboBox2.SelectedIndex);
            if (comboBox2.SelectedIndex == 0)
            {
                con.Open();
                DataTable dt7 = new DataTable();
                char[] delimiterChars = { ' ', '/' };
                string[] dateStrings = dateTimePicker1.Value.ToString().Split(delimiterChars);
                //Console.WriteLine(dateStrings[2] + "-" + dateStrings[0] + "%");
                int month = Convert.ToInt32(dateStrings[0]);

                adapt = new SqlDataAdapter("select * from Employee as E, (select EID, count(*) as numOrder from [Order] " +
                    "where OrderDate like @date group by EID) as E2 where E.EID = E2.EID", con);
                adapt.SelectCommand.Parameters.Clear();
                adapt.SelectCommand.Parameters.AddWithValue("@date", dateStrings[2] + "%");
                adapt.Fill(dt7);
                dataGridView5.DataSource = dt7;

                DataTable dt8 = new DataTable();
                adapt = new SqlDataAdapter("select * from Employee as E, (select EID, count(*) as numOrder from [Order] " +
                    "where OrderDate like @date group by EID) as E2 where E.EID = E2.EID", con);
                adapt.SelectCommand.Parameters.Clear();
                if (month < 10)
                    adapt.SelectCommand.Parameters.AddWithValue("@date", dateStrings[2] + "-0" + dateStrings[0] + "%");
                else
                    adapt.SelectCommand.Parameters.AddWithValue("@date", dateStrings[2] + "-" + dateStrings[0] + "%");
                adapt.Fill(dt8);
                dataGridView6.DataSource = dt8;
                con.Close();

            }

            else if (comboBox2.SelectedIndex == 1)
            {
                con.Open();
                char[] delimiterChars = { ' ', '/' };
                string[] dateStrings = dateTimePicker1.Value.ToString().Split(delimiterChars);
                //Console.WriteLine(dateStrings[0]);
                int month = Convert.ToInt32(dateStrings[0]);

                DataTable dt7 = new DataTable();
                adapt = new SqlDataAdapter("select * from Customer as C, (select count(*) as numOrders, CID from [Order] " +
                    "where OrderDate like @date group by CID) as orderCount " +
                    "where C.CID = orderCount.CID", con);
                adapt.SelectCommand.Parameters.Clear();
                adapt.SelectCommand.Parameters.AddWithValue("@date", dateStrings[2] + "%");
                adapt.Fill(dt7);
                dataGridView5.DataSource = dt7;

                DataTable dt8 = new DataTable();
                adapt = new SqlDataAdapter("select * from Customer as C, (select count(*) as numOrders, CID from [Order] " +
                   "where OrderDate like @date group by CID) as orderCount " +
                   "where C.CID = orderCount.CID", con);
                adapt.SelectCommand.Parameters.Clear();
                if (month < 10)
                    adapt.SelectCommand.Parameters.AddWithValue("@date", dateStrings[2] + "-0" + dateStrings[0] + "%");
                else
                    adapt.SelectCommand.Parameters.AddWithValue("@date", dateStrings[2] + "-" + dateStrings[0] + "%");
                adapt.Fill(dt8);
                dataGridView6.DataSource = dt8;
                con.Close();
            } 
            else if (comboBox2.SelectedIndex == 2)
            {

                char[] delimiterChars = { ' ', '/' };
                string[] dateStrings = dateTimePicker1.Value.ToString().Split(delimiterChars);
                //Console.WriteLine(dateStrings[2]);
                int month = Convert.ToInt32(dateStrings[0]);
                con.Open();
                DataTable dt7 = new DataTable();
                adapt = new SqlDataAdapter("select * from Movie as M, (select MID, count(*) as numRentals from [Order] " +
                    "where OrderDate like @date group by MID) as Active where M.MID = Active.MID", con);
                adapt.SelectCommand.Parameters.Clear();
                adapt.SelectCommand.Parameters.AddWithValue("@date", dateStrings[2] + "%");
                adapt.Fill(dt7);
                dataGridView5.DataSource = dt7;
                dataGridView5.Columns["MID1"].Visible = false;


                DataTable dt8 = new DataTable();
                adapt = new SqlDataAdapter("select * from Movie as M, (select MID, count(*) as numRentals from [Order] " +
                    "where OrderDate like @date group by MID) as Active where M.MID = Active.MID", con);
                adapt.SelectCommand.Parameters.Clear();
                if (month < 10)
                    adapt.SelectCommand.Parameters.AddWithValue("@date", dateStrings[2] + "-0" + dateStrings[0] + "%");
                else
                    adapt.SelectCommand.Parameters.AddWithValue("@date", dateStrings[2] + "-" + dateStrings[0] + "%");
                adapt.Fill(dt8);
                dataGridView6.DataSource = dt8;
                con.Close();
            }
        }

        private void searchByYear_Click(object sender, EventArgs e)
        {
            dataGridView5.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView6.BringToFront();
        }

        private void MovieNameTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void NumCopiesTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void CurrentNumTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void DistFeeTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void MovieTypeTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void MIDtxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void AIDtxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void NumCopiesTxt_TextChanged(object sender, EventArgs e)
        {
            //Console.WriteLine("TEXT CHANGED");
            string text = NumCopiesTxt.Text;
            bool hasLetter = false;
            foreach(char c in text)
            {
                if (!char.IsDigit(c))
                {
                    hasLetter = true;
                    break;
                }
            }
            if (hasLetter)
            {
                errorProvider1.SetError(NumCopiesTxt, "Only digits allowed");
                
            }
            else
                errorProvider1.SetError(NumCopiesTxt, "");
        }

        private bool ValidateCastingForm()
        {
            bool valid = false;
            int counter = 0;
            if (errorProvider1.GetError(MIDtxt) == "")
                counter++;

            if (errorProvider1.GetError(AIDtxt) == "")
                counter++;

            if (counter == 2)
                valid = true;

            return valid;
        }

        private bool ValidateMovieForm()
        {
            bool valid = false;
            int counter = 0;
            if (errorProvider1.GetError(NumCopiesTxt) == "")
                counter++;

            if (errorProvider1.GetError(CurrentNumTxt) == "")
                counter++;

            if (errorProvider1.GetError(DistFeeTxt) == "")
                counter++;

            if (errorProvider1.GetError(MovieTypeTxt) == "")
                counter++;

            if (counter == 4)
                valid = true;

            return valid;
        }

        private bool ValidateEmployeeForm()
        {
            bool valid = false;
            int counter = 0;
            if (errorProvider1.GetError(ZipCodeTxt) == "")
                counter++;

            if (errorProvider1.GetError(TelephoneTxt) == "")
                counter++;

            if (errorProvider1.GetError(HourlyRateTxt) == "")
                counter++;

            if (errorProvider1.GetError(SocialSecurityTxt) == "")
                counter++;

            if (counter == 4)
                valid = true;

            return valid;
        }

        private void CurrentNumTxt_TextChanged(object sender, EventArgs e)
        {
            string text = CurrentNumTxt.Text;
            bool hasLetter = false;
            foreach (char letter in text)
            {
                if (!char.IsDigit(letter))
                {
                    hasLetter = true;
                    break;
                }
            }
            if (hasLetter)
            {
                errorProvider1.SetError(CurrentNumTxt, "Only digits allowed");

            }
            else
                errorProvider1.SetError(CurrentNumTxt, "");
        }

        private void MIDtxt_TextChanged(object sender, EventArgs e)
        {
            string text = MIDtxt.Text;
            bool hasLetter = false;
            foreach (char letter in text)
            {
                if (!char.IsDigit(letter))
                {
                    hasLetter = true;
                    break;
                }
            }
            if (hasLetter)
            {
                errorProvider1.SetError(MIDtxt, "Only digits allowed");

            }
            else
                errorProvider1.SetError(MIDtxt, "");
        }

        private void AIDtxt_TextChanged(object sender, EventArgs e)
        {
            string text = AIDtxt.Text;
            bool hasLetter = false;
            foreach (char letter in text)
            {
                if (!char.IsDigit(letter))
                {
                    hasLetter = true;
                    break;
                }
            }
            if (hasLetter)
            {
                errorProvider1.SetError(AIDtxt, "Only digits allowed");

            }
            else
                errorProvider1.SetError(AIDtxt, "");
        }

        private void DistFeeTxt_TextChanged(object sender, EventArgs e)
        {
            string text = DistFeeTxt.Text;
            bool hasLetter = false;
            int numDecimal = 0;

            foreach (char c in text)
            {
                if (!char.IsDigit(c))
                {
                    if (c == '.' && numDecimal < 1)
                    {
                        numDecimal++;
                        continue;
                    }
                        
                        
                    hasLetter = true;
                    break;
                }
            }
            if (hasLetter)
            {
                errorProvider1.SetError(DistFeeTxt, "Only digits with one decimal is allowed");

            }
            else
                errorProvider1.SetError(DistFeeTxt, "");
        }
        
        private void MovieTypeTxt_TextChanged(object sender, EventArgs e)
        {
            string text = MovieTypeTxt.Text;
            bool hasNonLetter = false;

            foreach (char c in text)
            {
                if (!char.IsLetter(c))
                {
                    hasNonLetter = true;
                    break;
                }
            }
            if (hasNonLetter)
            {
                errorProvider1.SetError(MovieTypeTxt, "Only letters allowed");

            }
            else
                errorProvider1.SetError(MovieTypeTxt, "");
        }

        private void ZipCodeTxt_TextChanged(object sender, EventArgs e)
        {
            //Console.WriteLine("ZIPCODETXT CHANGED");
            string text = ZipCodeTxt.Text;
            bool nonAlphaNumeric = false;
            foreach (char c in text)
            {
                if (!char.IsDigit(c) && !char.IsLetter(c))
                {
                    nonAlphaNumeric = true;
                    break;
                }
            }
            if (nonAlphaNumeric)
            {
                errorProvider1.SetError(ZipCodeTxt, "Only alphanumeric characters allowed");

            }
            else
                errorProvider1.SetError(ZipCodeTxt, "");
        }

        private void TelephoneTxt_TextChanged(object sender, EventArgs e)
        {
            string text = TelephoneTxt.Text;
            bool hasLetter = false;
            foreach (char letter in text)
            {
                if (!char.IsDigit(letter))
                {
                    hasLetter = true;
                    break;
                }
            }
            if (hasLetter)
            {
                errorProvider1.SetError(TelephoneTxt, "Only digits allowed");

            }
            else
                errorProvider1.SetError(TelephoneTxt, "");
        }

        private void HourlyRateTxt_TextChanged(object sender, EventArgs e)
        {
            string text = HourlyRateTxt.Text;
            bool hasLetter = false;
            int numDecimal = 0;

            foreach (char c in text)
            {
                if (!char.IsDigit(c))
                {
                    if (c == '.' && numDecimal < 1)
                    {
                        numDecimal++;
                        continue;
                    }


                    hasLetter = true;
                    break;
                }
            }
            if (hasLetter)
            {
                errorProvider1.SetError(HourlyRateTxt, "Only digits with one decimal is allowed");

            }
            else
                errorProvider1.SetError(HourlyRateTxt, "");
        }

        private void SocialSecurityTxt_TextChanged(object sender, EventArgs e)
        {
            string text = SocialSecurityTxt.Text;
            bool hasLetter = false;
            foreach (char letter in text)
            {
                if (!char.IsDigit(letter))
                {
                    hasLetter = true;
                    break;
                }
            }
            if (hasLetter)
            {
                errorProvider1.SetError(SocialSecurityTxt, "Only digits allowed");

            }
            else
                errorProvider1.SetError(SocialSecurityTxt, "");
        }

        private void ZipCodeTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TelephoneTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void HourlyRateTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void SocialSecurityTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void clearDataBtn_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void searchMovieTxt_TextChanged(object sender, EventArgs e)
        {
            string searchString = searchMovieTxt.Text.Trim();
            if (searchString == "")
            {
                DisplayData();
                return;
            }
            // movie name
            con.Open();
            DataTable dt5 = new DataTable();
            adapt = new SqlDataAdapter("select * from Movie where MovieName like @search", con);
            adapt.SelectCommand.Parameters.AddWithValue("@search", "%" + searchString + "%");
            adapt.Fill(dt5);
            con.Close();
            if (dt5.Rows.Count > 0)
                dataGridView1.DataSource = dt5;
            con.Close();
            dataGridView1.BringToFront();
        }

        private void searchActorTxt_TextChanged(object sender, EventArgs e)
        {
            string searchString = searchActorTxt.Text.Trim();
            if (searchString == "")
            {
                DisplayActors();
                return;
            }
            // movie name
            con.Open();
            DataTable dt5 = new DataTable();
            adapt = new SqlDataAdapter("select * from Actor where FirstName like @search or LastName like @search", con);
            adapt.SelectCommand.Parameters.AddWithValue("@search", "%" + searchString + "%");
            adapt.Fill(dt5);
            con.Close();
            if (dt5.Rows.Count > 0)
                dataGridView2.DataSource = dt5;
            con.Close();
            dataGridView2.BringToFront();
        }

        private void ClearEmployeeBtn_Click(object sender, EventArgs e)
        {
            ClearEmployeeData();
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            foreach(Control p in UC1.Instance.Controls)
            {
                if (p.Name == "pnl")
                    if (!p.Controls.Contains(UC1.Instance))
                    {
                        p.Controls.Add(UC1.Instance);
                        UC1.Instance.Dock = DockStyle.Fill;
                        UC1.Instance.BringToFront();
                    }
                    else
                    {
                       UC1.Instance.BringToFront();
                    }
            }

            ClearActorData();
            ClearData();
            ClearEmployeeData();
            ClearCastingData();
            ClearRentals();
            comboBox1.SelectedIndex = -1;
            panel1.BringToFront();
            dataGridView1.BringToFront();
            UC1.email = "";
            UC1.id = "";

            SendToBack();
            //Hide();

        }
    }
}
