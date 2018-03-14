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
    public partial class FeatureControl : UserControl
    {
        private static FeatureControl _instance;
        public static FeatureControl Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new FeatureControl();
                return _instance;
            }
        }
        public FeatureControl()
        {
            InitializeComponent();
        }

        private void FeatureControl_Load(object sender, EventArgs e)
        {

        }
    }
}
