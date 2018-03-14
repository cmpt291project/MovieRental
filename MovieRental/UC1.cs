﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace MovieRental
{
    public partial class UC1 : UserControl
    {
        public static string info;
        private static UC1 _instance;
        public static UC1 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UC1();
                return _instance;
            }
        }
        public UC1()
        {
            InitializeComponent();
        }

        private void UC1_Load(object sender, EventArgs e)
        {
            Console.WriteLine(Form4.connectionString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            validate_User();
        }
       

        private void validate_User()
        {
            Panel pnl = Parent as Panel;
            if (pnl == null)
            {
                Console.WriteLine("PNL IS NULL");
                return;
            }

            SqlConnection scn = new SqlConnection();
            scn.ConnectionString = Form4.connectionString;
            scn.Open();

            SqlCommand scmd = new SqlCommand("select count (*) as cnt from Password where EmailAddress=@email and Password=@pwd", scn);
            scmd.Parameters.Clear();
            scmd.Parameters.AddWithValue("@email", textBox1.Text);
            scmd.Parameters.AddWithValue("@pwd", textBox2.Text);


            if (scmd.ExecuteScalar().ToString() == "1")
            {
                //pictureBox1.Image = new Bitmap(@"C:\Users\Mic 18\Documents\Visual Studio 2015\Projects\mylogin\granted.png");
                MessageBox.Show("YOU ARE GRANTED WITH ACCESS");
                SqlCommand scmd2 = new SqlCommand("select UserType from Password where EmailAddress=@email and Password=@pwd", scn);
                scmd.Parameters.Clear();
                
                scmd2.Parameters.AddWithValue("@email", textBox1.Text);
                scmd2.Parameters.AddWithValue("@pwd", textBox2.Text);
                //Console.WriteLine(scmd2.ExecuteScalar().ToString().Length);
                bool result = scmd2.ExecuteScalar().ToString().Trim().Equals("c");
                //Console.WriteLine(result);
                if (result)
                {
                    info = textBox1.Text;
                    if (!pnl.Controls.Contains(UC2.Instance))
                    {
                        pnl.Controls.Add(UC2.Instance);
                        UC2.Instance.Dock = DockStyle.Fill;
                        UC2.Instance.BringToFront();
                    }
                    else
                        UC2.Instance.BringToFront();
                }
                else
                {
                    info = textBox1.Text;
                    if (!pnl.Controls.Contains(UC3.Instance))
                    {
                        pnl.Controls.Add(UC3.Instance);
                        UC3.Instance.Dock = DockStyle.Fill;
                        UC3.Instance.BringToFront();
                    }
                    else
                        UC3.Instance.BringToFront();
                }

            }
            else
            {
                //pictureBox1.Image = new Bitmap(@"C:\Users\Mic 18\Documents\Visual Studio 2015\Projects\mylogin\denied.jpg");
                MessageBox.Show("YOU ARE NOT GRANTED WITH ACCESS");
                //lbl_Msg.Text = ("You Have Only " + Convert.ToString(attempt) + " Attempt Left To Try");
                // --attempt;
                textBox1.Clear();
                textBox2.Clear();
            }
            scn.Close();
        }
    }
}