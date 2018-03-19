using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieRental
{
    public partial class UserInfo : UserControl
    {
        private static UserInfo _instance;
        public static UserInfo Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserInfo();
                return _instance;
            }
        }
        public UserInfo()
        {
            InitializeComponent();
        }

        private void UserInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
