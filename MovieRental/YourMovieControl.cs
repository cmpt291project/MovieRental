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
    public partial class YourMovieControl : UserControl
    {
        private static YourMovieControl _instance;
        public static YourMovieControl Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new YourMovieControl();
                return _instance;
            }
        }
        public YourMovieControl()
        {
            InitializeComponent();
        }

        private void YourMovieControl_Load(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] filename = { "", "god father", "mad max", "mary and max", "The love witch" };
            for (int i = 1; i < 5; i++)
            {
                MovieGroupBox newGroupBox = new MovieGroupBox();
                newGroupBox.setGroupBox(YourMoviePanel2, i);
                newGroupBox.setImage(newGroupBox.groupBox, filename[i]);
                newGroupBox.setMovieInfo(newGroupBox.groupBox, "God", "Nick", "Bento Box", "2018-02-11", "2018-05-03");
            }
        }
    }
}
