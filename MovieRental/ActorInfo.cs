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
    
    class ActorInfo
    {
        private GroupBox gb;
        private Label fullName;
        private Label dob;
        private Label gender;
        public ActorInfo() {
            fullName = new Label();
            gb = new GroupBox();
            dob = new Label();
            gender = new Label();
        }

        public void createNewBox(Panel p, int i)
        {
            gb.Name = "actorBox";
            gb.Location = new Point(3, 3);
            gb.Size = new Size(500, 60);
            gb.Top = 3 + i* 60;
            gb.Left = 3;
            gb.Text = "Star";
            gb.FlatStyle = FlatStyle.Standard;

            p.Controls.Add(gb);

        }

        public void showName(string name) {
            fullName.Name = "actorName";
            fullName.Text = name;
            fullName.Location = new Point(10, 10);
            fullName.Font = new Font("Serif", 10,FontStyle.Bold);
            fullName.Top = 15;
            fullName.Left = 5;
            //fullName.MaximumSize = new Size(150, 40);
            fullName.AutoSize = true;

            //fullName.Click += new EventHandler(moviePage);

            gb.Controls.Add(fullName);
        }

        public void showDob(DateTime dt) {
            
            dob.Name = "dateOfBirth";
            string s = "Date of Birth: " + dt.ToString("d");
            dob.Text = s;
            dob.Top = 40;
            dob.Left = 5;
            dob.AutoSize = true;
            
            gb.Controls.Add(dob);
        }

        public void showGender(string g) {
            gender.Name = "g";
            gender.Text = "Gender: " + g;
            gender.Top = 40;
            gender.Left = 150;
            gender.AutoSize = true;

            gb.Controls.Add(gender);
        }
    }
}
