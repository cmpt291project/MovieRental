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
    public partial class Ranking : UserControl
    {
        private static Ranking _instance;
        public static Ranking Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Ranking();
                return _instance;
            }
        }
        public Ranking()
        {
            InitializeComponent();
        }

        private void Ranking_Load(object sender, EventArgs e)
        {

        }
    }
}
