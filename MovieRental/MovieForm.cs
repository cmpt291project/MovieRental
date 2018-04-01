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
    public partial class MovieForm : Form
    {
        public string mid;

        public MovieForm()
        {
            InitializeComponent();
        }
        public MovieForm(string s) {
            InitializeComponent();
            mid = s;
        }

        private void MovieForm_Load(object sender, EventArgs e)
        {
            mName.Text = mid;
            panelInMovieForm.Controls.Add(mName);

            for (int i = 0; i < 3; i++)
            {
                ActorInfo ai = new ActorInfo();
                ai.createNewBox(actorPanel, i);
                ai.showName("name");
                ai.showDob(DateTime.Today);
                ai.showGender("M");
            }
        }
    }
}
