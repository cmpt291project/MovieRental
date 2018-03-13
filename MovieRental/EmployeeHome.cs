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
    public partial class EmployeeHome : Form
    {
        public EmployeeHome()
        {
            InitializeComponent();
            
        }

        private void EmployeeHome_Load(object sender, EventArgs e)
        {
            Console.WriteLine(Form3.info);
        }

        
    }
}
