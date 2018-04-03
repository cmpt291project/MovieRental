using System;
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
            con.Open();
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
        }


        private void searchBtn_Click_1(object sender, EventArgs e)
        {
            string searchString = searchTxt.Text.Trim();

            // movie name
            con.Open();
            DataTable dt5 = new DataTable();
            adapt = new SqlDataAdapter("select * from Customer where LastName like @search or FirstName like @search", con);
            adapt.SelectCommand.Parameters.AddWithValue("@search", searchString + "%");
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
            Atype.Text = "";
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
            //MessageBox.Show("update");
            SqlConnection connection = new SqlConnection(Form4.connectionString);
            connection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT top 5 MovieName, M.MID, rate from(Select AVG(Rating) as rate, MID FROM MovieRating group by MID) as T , Movie M where T.MID = M.MID Order by rate DESC", connection);
            //SqlDataAdapter dataAdapter2 = new SqlDataAdapter("SELECT M.MovieName from Movie M, MovieQueue MQ where M.MID = MQ.MID and connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            
            int i = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                //foreach (DataColumn column in dataTable.Columns)
                //{
                MovieBoxRent movieBoxRent = new MovieBoxRent(row["MID"].ToString());
                movieBoxRent.createNewBox(suggest, i);
                //MessageBox.Show(row["MID"].ToString().Trim());
                movieBoxRent.CreatePicture(row["MID"].ToString().Trim());
                movieBoxRent.CreateName(row["MovieName"].ToString());
                //MessageBox.Show(row["MovieName"].ToString());
                movieBoxRent.CreateScore(row["rate"].ToString());
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
            DateTimeOffset localDate = DateTimeOffset.Now;
            cmd = new SqlCommand("update Customer set LastName=@lastname, FirstName=@firstname," +
                    "Street=@street, City=@city, State=@state, ZipCode=@zipcode, Telephone=@phone, CreditCardNumber=@creditcard," +
                    "Rating=@hrate, AccountType=@type, EmailAddress=@email where CID=@cid", con);
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
            cmd.Parameters.AddWithValue("@hrate", rateTextbox.Text);
            cmd.Parameters.AddWithValue("@type", Atype.Text);
            cmd.Parameters.AddWithValue("@email", EmailAddress.Text);
            cmd.ExecuteNonQuery();
            con.Close();
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

        private void sendAddQuery()
        {
                string newMID;
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
                    cmd.Parameters.AddWithValue("@ANumber", newMID);
                    cmd.Parameters.AddWithValue("@AType", Atype.Text);
                    cmd.Parameters.AddWithValue("@ADate", AccountCreationDate.Text);
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
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.e = e;
            if (dataGridView2.Rows[e.RowIndex].Cells.Count >= 10)
            {
                cidtext.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                FirstName.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                LastName.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                Street.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
                City.Text = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
                State.Text = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
                ZipCode.Text = dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString();
                Telephone.Text = dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString();
                EmailAddress.Text = dataGridView2.Rows[e.RowIndex].Cells[8].Value.ToString();
                Atype.Text = dataGridView2.Rows[e.RowIndex].Cells[10].Value.ToString();
                AccountCreationDate.Text = dataGridView2.Rows[e.RowIndex].Cells[11].Value.ToString();
                CreditCardNumber.Text = dataGridView2.Rows[e.RowIndex].Cells[12].Value.ToString();
                rateTextbox.Text = dataGridView2.Rows[e.RowIndex].Cells[13].Value.ToString();
            }
            button2.Enabled = true;
            button3.Enabled = true;
            update.Enabled = true;
            button6.Enabled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Allcustomer_Click(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView2.Enabled = true;
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select concat(C.FirstName, C.LastName) as Fullname, M.MovieName, OrderDate from Movie as M, Customer as C, [Order] as O where M.MID = O.MID and C.CID = O.CID", con);
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
                State.Text != "" && ZipCode.Text != "" && Telephone.Text != "" && EmailAddress.Text != "" && CreditCardNumber.Text != "" && rateTextbox.Text != "")
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
            con.Close();
            MessageBox.Show("Delete User Successfully!");
            DisplayData();
        }
    }
}
