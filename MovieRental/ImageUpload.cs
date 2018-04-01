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
    public partial class ImageUpload : Form
    {
        Image File;

        public ImageUpload()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            try
            {
                OpenFileDialog of = new OpenFileDialog();
                
                of.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png";

                if (of.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    
                    File = Image.FromFile(of.FileName);
                    pictureBox1.Image = File;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png";

            if (sf.ShowDialog() == DialogResult.OK)
            {
                File.Save(sf.FileName);
                
            }
        }
    }
}
