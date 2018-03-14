using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace MovieRental
{
    class MovieGroupBox
    {
        public GroupBox groupBox;
        public PictureBox pictureBox;
        public TextBox textBox;
        public string[] defaultString = { "Name:", "Director:", "Actor:", "Rent Date:", "Return Date:" };
        public MovieGroupBox()
        {
            groupBox = new GroupBox();
            pictureBox = new PictureBox();
            textBox = new TextBox();
        }
        
        public void setGroupBox(Panel tabpage, int index)
        {
            groupBox.Name = "Movie Name";
            groupBox.Location = new Point(150, 200);
            groupBox.Size = new Size(400, 200);
            groupBox.Top = index * 220 - 195;
            groupBox.Left = 65;
            groupBox.BackColor = Color.FromArgb(222, 222, 255);
            //groupBox.Text = "Movie Title";
            groupBox.Font = new Font("Segoe UI", 15);
            groupBox.FlatStyle = FlatStyle.Standard;
            tabpage.Controls.Add(groupBox);
        }

        public void setImage(GroupBox groupBox, string filename)
        {
            PictureBox image = new PictureBox();
            image.Location = new Point(0, 0);
            image.Size = new Size(180, 180);
            image.Top = 10;
            image.Left = -20;
            image.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(filename);
            image.SizeMode = PictureBoxSizeMode.Zoom;
            groupBox.Controls.Add(image);
        }
        
        public void setMovieInfo(GroupBox groupBox, string name, string director, string actor, string date, string returndate)
        {
            for (int i = 0; i < 5; i++)
            {
                Label label = new Label();
                label.Text = defaultString[i];
                label.Font = new Font("Segoe UI", 11);
                label.ForeColor = System.Drawing.Color.FromArgb(0, 128, 255);
                label.Location = new Point(155, 0);
                label.Size = new Size(91, 30);
                label.Top =  i * 30 + 30;
                groupBox.Controls.Add(label);

                TextBox text = new TextBox();
                switch (i)
                {
                    case 0:
                        text.Text = name;
                        break;
                    case 1:
                        text.Text = director;
                        break;
                    case 2:
                        text.Text = actor;
                        break;
                    case 3:
                        text.Text = date;
                        break;
                    case 4:
                        text.Text = returndate;
                        break;
                    default:
                        break;
                }
                text.Font = new Font("Segoe UI", 11);
                text.Location = new Point(260, 0);
                text.Size = new Size(135, 21);
                text.Top = i * 30 + 25;
                groupBox.Controls.Add(text);

            }

            
        }
    }
}
