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
    public partial class RateForm : Form
    {
        private string mid;
        public RateForm()
        {
            InitializeComponent();
        }

        public RateForm(string mid) {
            InitializeComponent();
            this.mid = mid;
        }


        private void RateForm_Load(object sender, EventArgs e)
        {
            RateBox rateBox = new RateBox();
            rateBox.NewGroupBox(panel1, 0);
            rateBox.NewLabel("ss");
            rateBox.NewScore();
        }

        
    }
}
