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
    public partial class SearchUC : UserControl
    {
        private static SearchUC _instance;
        public static SearchUC Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SearchUC();
                return _instance;
            }
        }

        public SearchUC()
        {
            InitializeComponent();
        }

        public void GetSearchParameter(string search)
        {
            Console.WriteLine(search);
        }
    }
}
