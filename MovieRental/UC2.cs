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
    public partial class UC2 : UserControl
    {
        private static UC2 _instance;
        public static UC2 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UC2();
                return _instance;
            }
        }
        public UC2()
        {
            InitializeComponent();
        }

        private void UC2_Load(object sender, EventArgs e)
        {
            MessageBox.Show(UC1.info);
        }

        

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            

        }

        private void button5_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] filename = { "", "god father", "mad max", "mary and max", "The love witch" };
            for (int i = 1; i < 5; i++)
            {
                MovieGroupBox newGroupBox = new MovieGroupBox();
                newGroupBox.setGroupBox(YourMovie, i);
                newGroupBox.setImage(newGroupBox.groupBox, filename[i]);
                newGroupBox.setMovieInfo(newGroupBox.groupBox, "God", "Nick", "Bento Box", "2018-02-11", "2018-05-03");
            }
            
        }
    }
}
