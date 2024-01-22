using System;
using System.Windows.Forms;

namespace BakeryManagment
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
            timer1.Start();
        }
        int starPos = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            starPos += 2;
            MyProgress.Value = starPos;
            Percentage.Text = starPos + "%";
            if (MyProgress.Value == 100)
            {
                MyProgress.Value = 0;

                login login = new login();
                login.Show();
                this.Hide();
                timer1.Stop();
            }
        }


    }
}
