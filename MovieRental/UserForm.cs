using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieRental
{
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            if (!userPanel.Controls.Contains(UserInfo.Instance))
            {
                
                userPanel.Controls.Add(UserInfo.Instance);
                UserInfo.Instance.Dock = DockStyle.Fill;
                UserInfo.Instance.BringToFront();
            }
            else
                UserInfo.Instance.BringToFront();
        }

        



    }
}
