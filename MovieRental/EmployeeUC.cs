using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MovieRental
{
    public partial class EmployeeUC : UserControl
    {
        private static EmployeeUC _instance;
        SqlConnection con = new SqlConnection(Form4.connectionString);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adapt;
        DataGridViewCellMouseEventArgs e;
        string currentPage = "";
        private string[] movieInfo = new string[10];
        bool fn = false, ln = false, strt = false, stat = false, zip = false, citys = false, tele = false, emai = false, credit = false, plan = false, Null = false;
        public static EmployeeUC Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new EmployeeUC();
                return _instance;
            }
        }

        public EmployeeUC()
        {
            InitializeComponent();
            DisplayData();
        }

        public void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DisplayData()
        {
            dataGridView2.Enabled = true;
            button1.Enabled = true;
            year.Visible = false;
            con.Open();
            currentPage = "Customer";
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("SELECT * from Customer", con);
            adapt.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
            panel2.Visible = false;
            add.Visible = false;
            save.Visible = true;
            button2.Enabled = false;
            button3.Enabled = false;
            update.Enabled = false;
            button6.Enabled = false;
            panel1.Visible = true;
            reportPanel.Visible = false;
            comboBox1.Visible = false;
            searchBtn.Enabled = true;
            suggest.Controls.Clear();
            label12.Text = "Address";
            label10.Text = "CustomerName";
            searchTxt.Text = "";
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            month.SelectedIndex = -1;
        }


        private void searchBtn_Click_1(object sender, EventArgs e)
        {
            string searchString = searchTxt.Text.Trim();

            // movie name
            con.Open();
            DataTable dt5 = new DataTable();
            if (currentPage == "Customer")
            {
                adapt = new SqlDataAdapter("select * from Customer where LastName like @search or FirstName like @search or Street like @search or City like @search or State like @search or ZipCode like @search or Telephone like @search or AccountType like @search or Rating like @search or EmailAddress like @search", con);
            }
            else
            {
                adapt = new SqlDataAdapter("select * from (select C.FirstName, C.LastName, M.MovieName, OrderDate from Movie as M, Customer as C, [Order] as O where M.MID = O.MID and C.CID = O.CID) A where LastName like @search or FirstName like @search or MovieName like @search or OrderDate like @search", con);
            }
            adapt.SelectCommand.Parameters.AddWithValue("@search", "%" + searchString + "%");
            adapt.Fill(dt5);
            con.Close();
            if (dt5.Rows.Count > 0)
                dataGridView2.DataSource = dt5;
            else
            {
                MessageBox.Show("No user found!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DisplayData();   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            add.Visible = true;
            save.Visible = false;
            panel2.Visible = true;
            dataGridView2.Enabled = false;
            changeFieldState(true);
            clearTable();
        }

        private void clearTable()
        {
            cidtext.Text = "";
            FirstName.Text = "";
            LastName.Text = "";
            Street.Text = "";
            City.Text = "";
            State.Text = "";
            ZipCode.Text = "";
            Telephone.Text = "";
            EmailAddress.Text = "";
            Atype.Text = "";
            AccountCreationDate.Text = "";
            CreditCardNumber.Text = "";
        }
        private void save_Click(object sender, EventArgs e)
        {

        }

        private void edit_Click(object sender, EventArgs e)
        {
            

        }

        private void changeFieldState(bool st)
        {
            FirstName.Enabled = st;
            LastName.Enabled = st;
            Street.Enabled = st;
            City.Enabled = st;
            State.Enabled = st;
            ZipCode.Enabled = st;
            Telephone.Enabled = st;
            EmailAddress.Enabled = st;
            CreditCardNumber.Enabled = st;
        }

        private void edit_Click_1(object sender, EventArgs e)
        {
            changeFieldState(true);
            save.Enabled = true;
        }

        private void save_Click_1(object sender, EventArgs e)
        {
            changeFieldState(false);
            save.Enabled = false;
            panel4.BringToFront();
            dataGridView2.Enabled = true;
            panel2.Visible = false;
            sendSaveQuery();
            MessageBox.Show("Save successfully!");
            save.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            dataGridView2.Enabled = true;
            suggestion();
        }

        private void suggestion()
        {
            SqlConnection connection = new SqlConnection(Form4.connectionString);
            connection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select top 5 Poster, M.MID, M.MovieName, (select AVG(rating) from MovieRating mr where mr.MID = M.MID ) rate from (select MovieType, O.MID from[Order] O, Movie M where CID = '" + UC1.id + "' and O.MID = M.MID) T, Movie M where M.MovieType = T.MovieType and T.MID != M.MID Order by NEWID()", connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            int i = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                //foreach (DataColumn column in dataTable.Columns)
                //{
                MovieBoxRent movieBoxRent = new MovieBoxRent(row["MID"].ToString());
                movieBoxRent.createNewBox(suggest, i, 0);
                //MessageBox.Show(row["MID"].ToString().Trim());
                if (row["Poster"] == DBNull.Value)
                {

                    movieBoxRent.CreatePictureImage((Image)Properties.Resources.ResourceManager.GetObject("Noimage"));
                }
                else
                {
                    byte[] ImageArray = (byte[])row["Poster"];
                    Image image = Image.FromStream(new MemoryStream(ImageArray));

                    movieBoxRent.CreatePictureImage(image);
                }

                movieBoxRent.CreateName(row["MovieName"].ToString());
                //MessageBox.Show(row["MovieName"].ToString());
                movieBoxRent.CreateScore(row["rate"].ToString());
                //movieBoxRent.CreateButtonRent();
                //Console.WriteLine(row["MovieName"]);
                i++;
                //}
            }
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            dataGridView2.Enabled = true;
            label10.Text = FirstName.Text.Trim()+ ", " + LastName.Text.Trim();
            label12.Text = Street.Text.Trim() + "Street " + City.Text.Trim() + ", " + State.Text.Trim() + " " + ZipCode.Text.Trim();
        }

        private void sendSaveQuery()
        {
            if (cidtext.Text == "")
            {
                sendAddQuery();
                return;
            }
            if (!checkemail())
            {
                MessageBox.Show("The email address has been taken.");
                errorProvider1.SetError(EmailAddress, "The email address has been taken.");
                return;
            }

            if (!inputValid(EmailAddress.Text))
            {
                return;
            }
            if (!(EmailAddress.Text.Contains('@') && EmailAddress.Text.Contains('.')))
            {
                MessageBox.Show("email not valid");
                return;
            }
            int countat = 0;
            int countdot = 0;
            foreach (char c in EmailAddress.Text)
            {
                if (c == '@')
                {
                    countat++;
                }

                if (c == '.')
                {
                    countdot++;
                }
            }

            if (countat > 1 || countdot > 1)
            {
                MessageBox.Show("email not valid");
                return;
            }
            DateTimeOffset localDate = DateTimeOffset.Now;
            cmd = new SqlCommand("update Customer set LastName=@lastname, FirstName=@firstname," +
                    "Street=@street, City=@city, State=@state, ZipCode=@zipcode, Telephone=@phone, CreditCardNumber=@creditcard," +
                    "AccountType=@type, EmailAddress=@email where CID=@cid", con);
            con.Open();
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@cid", cidtext.Text);
            cmd.Parameters.AddWithValue("@lastname", LastName.Text);
            cmd.Parameters.AddWithValue("@firstname", FirstName.Text);
            cmd.Parameters.AddWithValue("@street", Street.Text);
            cmd.Parameters.AddWithValue("@city", City.Text);
            cmd.Parameters.AddWithValue("@state", State.Text);
            cmd.Parameters.AddWithValue("@zipcode", ZipCode.Text);
            cmd.Parameters.AddWithValue("@phone", Telephone.Text);
            cmd.Parameters.AddWithValue("@creditcard", CreditCardNumber.Text);
            cmd.Parameters.AddWithValue("@type", Atype.Text);
            cmd.Parameters.AddWithValue("@email", EmailAddress.Text);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("update Password set EmailAddress=@email, Password=@password, CID=@cid, UserType=@type", con);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@email", EmailAddress.Text);
            cmd.Parameters.AddWithValue("@password", password.Text);
            cmd.Parameters.AddWithValue("@cid", cidtext.Text);
            cmd.Parameters.AddWithValue("@type", "c");
            cmd.ExecuteNonQuery();
            con.Close();
            DisplayData();
        }
        private bool CheckCustomer()
        {
            SqlConnection connection = new SqlConnection(Form4.connectionString);
            connection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select CID from Customer C where C.CID =" + UC1.id, connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["CID"].ToString() == "")
                {
                    return false;
                }
            }
            //MessageBox.Show(dataTable.Rows.Count.ToString());
            connection.Close();
            return true;
        }

        private bool checkallbool()
        {
            if (fn == false && ln == false && strt == false && stat == false && zip == false && citys == false && tele == false && emai == false && credit == false && plan == false && Null == false)
                return true;
            return false;
        }

        private bool checkemail()
        {
            SqlConnection connection = new SqlConnection(Form4.connectionString);
            connection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select EmailAddress from Customer", connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["EmailAddress"].ToString().Trim() == EmailAddress.Text)
                {
                    return false;
                }
            }
            //MessageBox.Show(dataTable.Rows.Count.ToString());
            connection.Close();
            return true;
        }

        private bool inputValid(string s)
        {
            s.Trim();
            if (s.Contains("'") || s == "" || s == "NULL")
            {
                return false;
            }
            return true;
        }

        private void sendAddQuery()
        {
            if (checkallbool()) {
                if (!checkemail())
                {
                    MessageBox.Show("The email address has been taken.");
                    errorProvider1.SetError(EmailAddress, "The email address has been taken.");
                    return;
                }

                if (!inputValid(EmailAddress.Text))
                {
                    return;
                }
                if (!(EmailAddress.Text.Contains('@') && EmailAddress.Text.Contains('.')))
                {
                    MessageBox.Show("email not valid");
                    return;
                }
                int countat = 0;
                int countdot = 0;
                foreach (char c in EmailAddress.Text)
                {
                    if (c == '@')
                    {
                        countat++;
                    }

                    if (c == '.')
                    {
                        countdot++;
                    }
                }

                if (countat > 1 || countdot > 1)
                {
                    MessageBox.Show("email not valid");
                    return;
                }
                string cid = "";
                SqlConnection connection = new SqlConnection(Form4.connectionString);
                connection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("select MAX(CID)+1 as CID from Customer", connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    cid = row["CID"].ToString();
                            
                }
                //MessageBox.Show(dataTable.Rows.Count.ToString());
                connection.Close();
                string newMID;
                Random generator = new Random();
                int r = generator.Next(0, 999999);

                using (cmd = new SqlCommand("select MAX(CID)+1 from Customer", con))
                {
                    con.Open();
                    newMID = cmd.ExecuteScalar().ToString();
                    con.Close();

                }
                using (cmd = new SqlCommand("insert into Customer(CID, LastName, FirstName, Street, City, State, ZipCode, Telephone, EmailAddress, AccountNumber, AccountType," +
                    "AccountCreationDate, CreditCardNumber) values(@CID,@FN,@SN,@Street,@City,@State,@ZipCode,@Telephone,@Email,@ANumber,@AType,@ADate,@CCN)", con))
                {

                    con.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@CID", newMID);
                    cmd.Parameters.AddWithValue("@FN", FirstName.Text);
                    cmd.Parameters.AddWithValue("@SN", LastName.Text);
                    cmd.Parameters.AddWithValue("@Street", Street.Text);
                    cmd.Parameters.AddWithValue("@City", City.Text);
                    cmd.Parameters.AddWithValue("@State", State.Text);
                    cmd.Parameters.AddWithValue("@ZipCode", ZipCode.Text);
                    cmd.Parameters.AddWithValue("@Telephone", Telephone.Text);
                    cmd.Parameters.AddWithValue("@Email", EmailAddress.Text);
                    cmd.Parameters.AddWithValue("@ANumber", r);
                    cmd.Parameters.AddWithValue("@AType", Atype.Text);
                    DateTime date = DateTime.Today;
                    cmd.Parameters.AddWithValue("@ADate", date.Date.ToString("d"));
                    cmd.Parameters.AddWithValue("@CCN", CreditCardNumber.Text);
                    if (checkBlank())
                    {
                        cmd.ExecuteNonQuery();
                        con.Close();
                        DisplayData();
                        add.Visible = false;
                    }
                    else
                    {
                        con.Close();
                        MessageBox.Show("Please fill in all blanks");
                    }

                }
                con.Open();
                cmd = new SqlCommand("insert into Password(EmailAddress, Password, CID, UserType) values(@email, @password, @cid, @type)", con);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@email", EmailAddress.Text);
                cmd.Parameters.AddWithValue("@password", password.Text);
                cmd.Parameters.AddWithValue("@cid", cid);
                cmd.Parameters.AddWithValue("@type", "c");
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                MessageBox.Show("Please fix the error before add!");
            }
            DisplayData();
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.e = e;
            if (dataGridView2.Rows[e.RowIndex].Cells.Count >= 10)
            {
                cidtext.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
                FirstName.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                LastName.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
                Street.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();
                City.Text = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString().Trim();
                State.Text = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString().Trim();
                ZipCode.Text = dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString().Trim();
                Telephone.Text = dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString().Trim();
                EmailAddress.Text = dataGridView2.Rows[e.RowIndex].Cells[8].Value.ToString().Trim();
                Atype.Text = dataGridView2.Rows[e.RowIndex].Cells[10].Value.ToString().Trim();
                AccountCreationDate.Text = dataGridView2.Rows[e.RowIndex].Cells[11].Value.ToString().Trim();
                CreditCardNumber.Text = dataGridView2.Rows[e.RowIndex].Cells[12].Value.ToString().Trim();
            }
            button2.Enabled = true;
            button3.Enabled = true;
            update.Enabled = true;
            button6.Enabled = true;
        }

        private void Allcustomer_Click(object sender, EventArgs e)
        {
            DisplayData();
            currentPage = "Customer";
        }

        private void Street_TextChanged(object sender, EventArgs e)
        {
            checkTextBox(Street, strt, 2);
        }

        private void City_TextChanged(object sender, EventArgs e)
        {
            checkTextBox(City, citys, 0);
        }

        private void State_TextChanged(object sender, EventArgs e)
        {
            checkTextBox(State, stat, 0);
        }

        private void ZipCode_TextChanged(object sender, EventArgs e)
        {
            checkTextBox(ZipCode, zip, 2);
        }

        private void Telephone_TextChanged(object sender, EventArgs e)
        {
            checkTextBox(Telephone, tele, 1);
        }

        private void EmailAddress_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(EmailAddress, "");
        }

        private void CreditCardNumber_TextChanged(object sender, EventArgs e)
        {
            checkTextBox(CreditCardNumber, credit, 1);
        }

        private void reportbutton_Click(object sender, EventArgs e)
        {
            reportPanel.Visible = true;
            year.Visible = true;
            comboBox1.Visible = false;
            searchBtn.Enabled = false;
        }

        private void mostcustomer_Click(object sender, EventArgs e)
        {
            createMostActiveCustomer();
            ReportLabel.Text = "Most Active Customer";
        }

        public void createMostActiveCustomer()
        {
            //Reporting.Controls.Clear();
            if (month.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a month!");
                return;
            }
            if (year.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a year");
                return;
            }
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select C.FirstName, C.LastName, count(O.MID) from Customer as C, [Order] as O where C.CID = O.CID and month(O.OrderDate) = '" + MonthToInt(month.SelectedItem.ToString()) + "' and year(O.OrderDate) = '" + year.SelectedItem.ToString() + "' group by C.FirstName, C.LastName", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        public int MonthToInt(string month)
        {
            int num = 1;
            
            switch (month)
            {
                case "January":
                    num = 1;
                    break;
                case "February":
                    num = 2;
                    break;
                case "March":
                    num = 3;
                    break;
                case "April":
                    num = 4;
                    break;
                case "May":
                    num = 5;
                    break;
                case "June":
                    num = 6;
                    break;
                case "July":
                    num = 7;
                    break;
                case "August":
                    num = 8;
                    break;
                case "September":
                    num = 9;
                    break;
                case "October":
                    num = 10;
                    break;
                case "November":
                    num = 11;
                    break;
                case "December":
                    num = 12;
                    break;
                default:
                    break;
            }
            return num;


        }

        private void FirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void LastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void Street_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void City_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void State_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void ZipCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void Telephone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void CreditCardNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void Atype_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (month.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a month!");
                return;
            }
            if (year.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a year");
                return;
            }
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select M.MovieName, count(O.MID) as NumOfSelling from Movie M, [Order] as O where M.MID = O.MID and month(O.OrderDate) = '" + MonthToInt(month.SelectedItem.ToString()) + "' and year(O.OrderDate) = '" + year.SelectedItem.ToString() + "' group by M.MovieName order by NumOfSelling DESC", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecordOrderChange();
        }

        private void RecordOrderChange()
        {
            if (year.SelectedIndex == -1)
            {
                year.SelectedItem = "2018";
            }
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select C.FirstName, C.LastName, M.MovieName, OrderDate from Movie as M, Customer as C, [Order] as O where M.MID = O.MID and C.CID = O.CID and month(O.OrderDate) = '" + MonthToInt(comboBox1.SelectedItem.ToString()) + "' and year(O.OrderDate) = '" + year.SelectedItem.ToString() + "'", con);
            adapt.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
        }

        private void month_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void logout_Click(object sender, EventArgs e)
        {
            foreach (Control p in UC1.Instance.Controls)
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
            UC1.Instance.clean();
            SendToBack();
            clearText();
        }

        private void clearText()
        {
            DisplayData();
        }

        private void Atype_MouseClick(object sender, MouseEventArgs e)
        {
            Atype.DroppedDown = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView2.Enabled = true;
            year.Visible = true;
            searchBtn.Enabled = true;
            button1.Enabled = false;
            comboBox1.Visible = true;
            currentPage = "[Order]";
            reportPanel.Visible = false;
            panel1.Visible = false;
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select C.FirstName, C.LastName, M.MovieName, OrderDate from Movie as M, Customer as C, [Order] as O where M.MID = O.MID and C.CID = O.CID and month(O.OrderDate) = '4' and year(O.OrderDate) = '2018'", con);
            adapt.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
            panel2.Visible = false;
        }

        private bool checkChooseRow()
        {
            if (e == null)
            {
                return false;
            }
            return dataGridView2.Rows[e.RowIndex].Cells.Count > 0;
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (checkChooseRow())
            {
                panel2.Visible = true;
                dataGridView2.Enabled = false;
                changeFieldState(true);
            }
            else
                MessageBox.Show("Please choose a Customer to Edit.");
        }

        private bool checkBlank()
        {
            if (FirstName.Text != "" && LastName.Text != "" && Street.Text != "" && City.Text != "" && 
                State.Text != "" && ZipCode.Text != "" && Telephone.Text != "" && EmailAddress.Text != "" && CreditCardNumber.Text != "")
            {
                return true;
            }
            return false;
        }
        private void add_Click(object sender, EventArgs e)
        {
            sendAddQuery();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand sqlCmd = new SqlCommand("Delete from Customer Where CID=@CID", con);
            sqlCmd.Parameters.AddWithValue("CID", dataGridView2.CurrentRow.Cells["CID"].Value.ToString());
            sqlCmd.ExecuteNonQuery();
            sqlCmd = new SqlCommand("Delete from Password Where CID=@CID", con);
            sqlCmd.Parameters.AddWithValue("CID", dataGridView2.CurrentRow.Cells["CID"].Value.ToString());
            sqlCmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Delete User Successfully!");
            DisplayData();
        }

        private void FirstName_TextChanged(object sender, EventArgs e)
        {
            checkTextBox(FirstName, fn, 0);
        }

        private void LastName_TextChanged(object sender, EventArgs e)
        {
            checkTextBox(LastName, ln, 0);
        }



        private void checkTextBox(TextBox box, bool value, int k)
        {
            string text = box.Text;
            value = false;
            string str = "";
            switch (k)
            {
                case 0: //name
                    foreach (char c in text)
                    {
                        if (!char.IsLetter(c))
                        {
                            value = true;
                            break;
                        }
                    }
                    str = "Only letters allowed";
                    break;
                case 1: //number
                    foreach (char letter in text)
                    {
                        if (!char.IsDigit(letter))
                        {
                            value = true;
                            break;
                        }
                    }
                    str = "Only numbers allowed";
                    break;
                case 2: //Zipcode
                    foreach (char c in text)
                    {
                        if (!char.IsDigit(c) && !char.IsLetter(c))
                        {
                            value = true;
                            break;
                        }
                    }
                    str = "Only alphanumeric characters allowed";
                    break;
                case 3: // decimal number
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


                            value = true;
                            break;
                        }
                    }
                    str = "only one decimal point allowed";
                    break;
                default:
                    break;
            }
            string tmp = box.Text.ToUpper();
            if (tmp == "NULL") {
                str = "The value cannot be NULL";
                value = true;
            }
            /*if (value)
            {
                errorProvider1.SetError(box, str);
            }
            else
                errorProvider1.SetError(box, "");*/
        }
    }
}
