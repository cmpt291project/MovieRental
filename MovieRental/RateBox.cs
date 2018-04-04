using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MovieRental
{
    class RateBox
    {
        private GroupBox gb;
        private Label label;
        private RadioButton one;
        private RadioButton two;
        private RadioButton three;
        private RadioButton four;
        private RadioButton five;


        public RateBox() {
            gb = new GroupBox();

            label = new Label();
            one = new RadioButton();
            two = new RadioButton();
            three = new RadioButton();
            four = new RadioButton();
            five = new RadioButton();

        }

        public void NewGroupBox(Panel p, int i) {
            
            gb.Location = new Point(3, 3);
            gb.Size = new Size(500, 70);
            gb.Top = 3 + i * 60;
            gb.Left = 3;
            gb.Text = "Rate";
            gb.FlatStyle = FlatStyle.Standard;

            p.Controls.Add(gb);
        }

        public void NewLabel(string s) {
            label.Text = s;
            label.Font = new Font("Serif", 10);
            label.Top = 15;
            label.Left = 5;
            label.AutoSize = true;
            gb.Controls.Add(label);
        }

        public void NewScore() {
            int i = 0;
            for (int j = 5; j > 0; j--)
            {
                RadioButton rb = new RadioButton();
                int x = j;
                rb.Text = x.ToString();
                rb.Top = 40;
                rb.Left = 8 + 50 * i;
                rb.MaximumSize = new Size(50, 20);
                if (j == 5)
                {
                    rb.Checked = true;
                }
                gb.Controls.Add(rb);
                i++;

            }

   /*         five.Text = "5";
            five.Top = 32;
            five.Left = 5;
            five.MaximumSize = new Size(50,20);
            gb.Controls.Add(five);

            four.Text = "4";
            four.Top = 50;
            four.Left = 100;
            gb.Controls.Add(four);*/

        }
    }
}
