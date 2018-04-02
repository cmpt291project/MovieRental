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
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
        }

        private void HelpForm_Load(object sender, EventArgs e)
        {
            infotext.Text = "For New Customer: \nPlease choose 'Create account' to create a new user account." +
                "\nYou must enter your name, address, telephone number, email address and payment information to create a new account." +
                "\nEach email address can only used once to create new account.";
        }
    }
}
