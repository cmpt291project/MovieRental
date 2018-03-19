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
    public partial class ManagerUC : UserControl
    {
        private string movieName;
        private string movieType;
        private int ID;
        private string MID;
       // DateTimePicker dtp = new DateTimePicker();
        //Rectangle _Rectangle;
        

        private static ManagerUC _instance;
        public static ManagerUC Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ManagerUC();
                return _instance;
            }
        }

        public ManagerUC()
        {
            InitializeComponent();
            /*dataGridView2.Controls.Add(dtp);
            dtp.Visible = false;
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.TextChanged += new EventHandler(dtp_TextChange);*/
            //dtp.Visible = false;
            //dtp.CustomFormat = "dd/MM/yyyy";
            /*dtp.ValueChanged += dg1_ValueChanged;
            dataGridView2.Controls.Add(dtp);
            dataGridView2.CellClick += dataGridView2_CellClick;*/
            DisplayData();
        }

        SqlConnection con = new SqlConnection(Form4.connectionString);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adapt;


        private void ManagerUC_Load(object sender, EventArgs e)
        {
            
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/yyyy";
            dateTimePicker1.ShowUpDown = true;

            //DataGridView.AutoGenerateColumns = false;
        }

        private void GetRevenue_Click(object sender, EventArgs e)
        {
            dataGridView1.BringToFront();

            GetSubRevenue();
        }

        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("SELECT * from Movie", con);
            adapt.Fill(dt);
            dataGridView2.DataSource = dt;
            //dataGridView2.Columns["MID"].Visible = false;
            con.Close();
            /*foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                row.Cells[5].Value = DateTime.Now.ToShortDateString();
                row.Cells[6].Value = DateTime.Now.ToShortDateString();
            }*/
            
        }

        private void GetSubRevenue()
        {
            Console.WriteLine(dateTimePicker1.Text);
            char[] delimiterChars = { '/' };
            string[] dateStrings = dateTimePicker1.Text.Split(delimiterChars);
            Console.WriteLine(dateStrings[0] + " " + dateStrings[1]);
            string queryDate = dateStrings[1] + "-01-" + dateStrings[0];
            Console.WriteLine(queryDate);
            SqlConnection connection = new SqlConnection(Form4.connectionString);
            connection.Open();
            SqlDataAdapter a = new SqlDataAdapter("SELECT sum(MonthlyFee) as Revenue from (select C.AccountType, R.MonthlyFee from Customer as C, " +
                "RentalPlan as R where AccountCreationDate <='" + queryDate + "' and C.AccountType = R.AccountType) as Fees", connection);
            DataTable t = new DataTable();
            a.Fill(t);
            dataGridView1.DataSource = t;

            connection.Close();
        }

        private void CompareDates()
        {
            DateTime localDate = DateTime.Now;
            String[] cultureNames = { "en-US", "en-GB", "fr-FR",
                                "de-DE", "ru-RU" };

            /*foreach (var cultureName in cultureNames)
            {
                var culture = new CultureInfo(cultureName);
                Console.WriteLine("{0}: {1}", cultureName,
                                  localDate.ToString(culture));
            }*/
            var culture = new CultureInfo("en-US");
            //Console.WriteLine("Local date/time: " + localDate.ToString(culture));

            SqlConnection connection = new SqlConnection(Form4.connectionString);
            connection.Open();
            SqlCommand a = new SqlCommand("SELECT AccountCreationDate FROM Customer WHERE AccountNumber = '748792'", connection);
            string joinDate = a.ExecuteScalar().ToString();
            string currentDate = localDate.ToString(culture);
            Console.WriteLine("date from DB: " + joinDate + " current date: " + currentDate);

            char[] delimiterChars = { ' ', '/' };
            string[] joinDateStrings = joinDate.Split(delimiterChars);
            string[] currentDateStrings = currentDate.Split(delimiterChars);
            if (currentDate[0] - joinDate[0] == 1)
                Console.WriteLine("TIME TO PAY UP");

            connection.Close();
        }

        private void ClearData()
        {
            name_txt.Clear();
            type_txt.Clear();
            MID = "";
        }

        /*private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            MID = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            name_txt.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            movieName = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            type_txt.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            movieType = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            //Console.WriteLine(dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString().Length);
        }*/

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MID = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            name_txt.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            movieName = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            type_txt.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            movieType = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            //Console.WriteLine(dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString().Length);
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (name_txt.Text != "" && type_txt.Text != "")
            {
                Console.WriteLine(MID.Length + " " + movieName.Length + " " + movieType.Length);
                //using (SqlConnection con = new SqlConnection(Form4.connectionString))
                cmd = new SqlCommand("update Movie set MovieName=@name,MovieType=@type where MID=@id", con);
                con.Open();
                
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", MID.Trim());
                cmd.Parameters.AddWithValue("@name", name_txt.Text);
                cmd.Parameters.AddWithValue("@type", type_txt.Text.Trim());
                cmd.ExecuteNonQuery();
                con.Close();
                DisplayData();
                //ClearData();
            } else
            {
                Console.WriteLine("Please Try Again");
            }
        }



        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
            //dtp.Visible = false;
            //Console.WriteLine(dataGridView2.Rows[e.RowIndex].Cells["MID"].Value.ToString());
            if (dataGridView2.CurrentRow != null)
            {
                using (SqlConnection sqlCon = new SqlConnection(Form4.connectionString))
                {
                    sqlCon.Open();
                    //if (dataGridView2.CurrentRow == null)
                        //Console.WriteLine("NULL ROW");
                    DataGridViewRow dgvRow = dataGridView2.CurrentRow;
                    //Console.WriteLine(dgvRow.Cells["MovieName"].Value.ToString());
                    //SqlCommand sqlCmd = new SqlCommand("update Movie set MovieName=@name,MovieType=@type where MID=@id", con);
                    SqlCommand sqlCmd = new SqlCommand("MovieAddOrEdit", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    if (dgvRow.Cells["MID"].Value == DBNull.Value)
                        sqlCmd.Parameters.AddWithValue("@MID", 0);
                    else
                        sqlCmd.Parameters.AddWithValue("@MID", Convert.ToInt32(dgvRow.Cells["MID"].Value));
                    Console.WriteLine(dgvRow.Cells["ReleaseDate"].Value.ToString());
                    
                    sqlCmd.Parameters.AddWithValue("@MovieName", dgvRow.Cells["MovieName"].Value == DBNull.Value ? "" : dgvRow.Cells["MovieName"].Value.ToString());
                    sqlCmd.Parameters.AddWithValue("@MovieType", dgvRow.Cells["MovieType"].Value == DBNull.Value ? "" : dgvRow.Cells["MovieType"].Value.ToString());
                    sqlCmd.Parameters.AddWithValue("@DistributionFee", Convert.ToSingle(dgvRow.Cells["DistribututionFee"].Value == DBNull.Value ? "0" : dgvRow.Cells["DistribututionFee"].Value.ToString()));
                    sqlCmd.Parameters.AddWithValue("@NumberOfCopies", Convert.ToInt32(dgvRow.Cells["NumberOfCopies"].Value == DBNull.Value ? "0" : dgvRow.Cells["NumberOfCopies"].Value.ToString()));
                    sqlCmd.Parameters.AddWithValue("@ReleaseDate", Convert.ToDateTime(dgvRow.Cells["ReleaseDate"].Value == DBNull.Value ? "2018-01-01" : dgvRow.Cells["ReleaseDate"].Value.ToString()));
                    sqlCmd.Parameters.AddWithValue("@AddDate", Convert.ToDateTime(dgvRow.Cells["AddDate"].Value == DBNull.Value ? "2018-01-01" : dgvRow.Cells["AddDate"].Value.ToString()));
                    sqlCmd.Parameters.AddWithValue("@Director", dgvRow.Cells["Director"].Value == DBNull.Value ? "" : dgvRow.Cells["Director"].Value.ToString());
                    sqlCmd.Parameters.AddWithValue("@CurrentNum", Convert.ToInt32(dgvRow.Cells["CurrentNum"].Value == DBNull.Value ? "0" : dgvRow.Cells["CurrentNum"].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    DisplayData();
                }
                    //Console.WriteLine(dataGridView2.CurrentRow.Cells["MID"].Value.ToString());
                
            }


            /*SqlConnection connection = new SqlConnection(Form4.connectionString);
            connection.Open();
            SqlDataAdapter a = new SqlDataAdapter("SELECT * from Movie", connection);
            DataTable t = new DataTable();
            a.Fill(t);
            DataGridView.DataSource = t;

            connection.Close();*/


            /*private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
                //Console.WriteLine("HELLO");
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = DataGridView.Rows[e.RowIndex];
                    Console.WriteLine(row.Cells["MovieName"].Value.ToString());
                    //Name_txt.Text = row.Cells["First Name"].Value.ToString();
                    //Surname_txt.Text = row.Cells["Last Name"].Value.ToString();
                }
                }*/
        }

        private void dataGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= AllowNumbersOnly;
            if (dataGridView2.CurrentCell.ColumnIndex == 3 || dataGridView2.CurrentCell.ColumnIndex == 4 || dataGridView2.CurrentCell.ColumnIndex == 8)
            {
                Console.WriteLine("number col");
                //e.Control.KeyPress -= AllowNumbersOnly;
                e.Control.KeyPress += AllowNumbersOnly;
            }

            if (dataGridView2.CurrentCell.ColumnIndex == 5 || dataGridView2.CurrentCell.ColumnIndex == 6)
            {
                Console.WriteLine("date time");
            }
        }

        private void AllowNumbersOnly(Object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dataGridView2_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (dataGridView2.CurrentRow.Cells["MID"].Value != DBNull.Value)
            {
                if (MessageBox.Show("Delete this Record?","DataGridView",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (SqlConnection sqlCon = new SqlConnection(Form4.connectionString))
                    {
                        sqlCon.Open();
                        SqlCommand sqlCmd = new SqlCommand("MovieDeleteByID", sqlCon);
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.AddWithValue("@MID", Convert.ToInt32(dataGridView2.CurrentRow.Cells["MID"].Value));
                        sqlCmd.ExecuteNonQuery();
                    }
                } else
                {
                    e.Cancel = true;
                }
            } else
            {
                e.Cancel = true;
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            /*if (e.ColumnIndex == 6)
            {
                Rectangle cellRectangle = dataGridView2.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                dtp.Location = cellRectangle.Location;
                dtp.Width = cellRectangle.Width;
                try
                {
                    dtp.Value = DateTime.Parse(dataGridView2.CurrentCell.Value.ToString());
                }
                catch
                {

                }
                dtp.Visible = true;
            }
            else
            {
                dtp.Visible = false;
            }*/




            /* switch (dataGridView2.Columns[e.ColumnIndex].Name)
            {
                case "ReleaseDate":

                    //Console.WriteLine("HELLO");
                    //Console.WriteLine(dataGridView2.CurrentRow.Cells["ReleaseDate"].Value.ToString());
                    //dtp.Value = Convert.ToDateTime(dataGridView2.CurrentRow.Cells["ReleaseDate"].Value);
                    _Rectangle = dataGridView2.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    dtp.Size = new Size(_Rectangle.Width, _Rectangle.Height);
                    dtp.Location = new Point(_Rectangle.X, _Rectangle.Y);
                    dtp.Visible = true;
                    break;

                case "AddDate":
                    _Rectangle = dataGridView2.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    dtp.Size = new Size(_Rectangle.Width, _Rectangle.Height);
                    dtp.Location = new Point(_Rectangle.X, _Rectangle.Y);
                    dtp.Visible = true;
                    break;
            }*/

        }

        private void dataGridView2_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {
            //MessageBox.Show("Error happened " + anError.Context.ToString());
            MessageBox.Show("Incorrect Date format, please try again.");


            if (anError.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show("Commit error");
            }
            if (anError.Context == DataGridViewDataErrorContexts.CurrentCellChange)
            {
                MessageBox.Show("Cell change");
            }
            if (anError.Context == DataGridViewDataErrorContexts.Parsing)
            {
                MessageBox.Show("parsing error");
            }
            if (anError.Context == DataGridViewDataErrorContexts.LeaveControl)
            {
                MessageBox.Show("leave control error");
            }

            if ((anError.Exception) is ConstraintException)
            {
                DataGridView view = (DataGridView)sender;
                view.Rows[anError.RowIndex].ErrorText = "an error";
                view.Rows[anError.RowIndex].Cells[anError.ColumnIndex].ErrorText = "an error";

                anError.ThrowException = false;
            }
        }

       
    }
    
}
