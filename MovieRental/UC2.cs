using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


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
            
            if (!rank.Controls.Contains(Ranking.Instance))
            {
                rank.Controls.Add(Ranking.Instance);
                Ranking.Instance.Dock = DockStyle.Fill;
                Ranking.Instance.BringToFront();
            }
            else
                Ranking.Instance.BringToFront();

            if (!YourMovie.Controls.Contains(YourMovieControl.Instance))
            {
                YourMovie.Controls.Add(YourMovieControl.Instance);
                YourMovieControl.Instance.Dock = DockStyle.Fill;
                YourMovieControl.Instance.BringToFront();
            }
            else
                YourMovieControl.Instance.BringToFront();
            //new release in feature
            if (!newRelease.Controls.Contains(FeatureControl.Instance))
            {
                newRelease.Controls.Add(FeatureControl.Instance);
                FeatureControl.Instance.Dock = DockStyle.Fill;
                FeatureControl.Instance.BringToFront();
            }
            else
                FeatureControl.Instance.BringToFront();
            
            //genre in feature
            if (!panelGenre.Controls.Contains(GenreControl.Instance))
            {
                panelGenre.Controls.Add(GenreControl.Instance);
                GenreControl.Instance.Dock = DockStyle.Fill;
                GenreControl.Instance.BringToFront();
            }
            else
                GenreControl.Instance.BringToFront();

            //like panel in suggest
            if (!like.Controls.Contains(Like.Instance))
            {
                like.Controls.Add(Like.Instance);
                Like.Instance.Dock = DockStyle.Fill;
                Like.Instance.BringToFront();
            }
            else
                Like.Instance.BringToFront();

        }

        private void Form2Tab1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(YourMovieTab.SelectedTab);
            if (YourMovieTab.SelectedTab == YourMovieTab.TabPages["Suggestion"])
            {
                MessageBox.Show("Suggestion");
            }
        }
            

        private void Suggestion_Click(object sender, EventArgs e)
        {
            MessageBox.Show("SUGGESTIONS");
        }

        private void YourMovie_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Your Movie");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("user info");
            UserForm userForm = new UserForm();
            userForm.Show();
        }




        
        private void YourMovieTab_TabIndexChanged(object sender, EventArgs e)
        {
           // Console.WriteLine(YourMovieTab.SelectedTab);
        }

        private void YourMovieTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(YourMovieTab.SelectedIndex);
            if (YourMovieTab.SelectedIndex == 0)
            {
                Console.WriteLine("Features");
                FeatureControl.Instance.update();
                GenreControl.Instance.initialDisplay();
            }
            else if ((YourMovieTab.SelectedIndex == 1))
            {
                Console.WriteLine("Suggestions");
                Ranking.Instance.update();
                Like.Instance.update();
            }

            else
                Console.WriteLine("Your Movies");
            //if (YourMovieTab.SelectedTab == )

        }
    }
}
