using System;
using System.Windows.Forms;

namespace BakeryManagment
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        public static login Obj { get; internal set; }

        private void Login_Load(object sender, EventArgs e)
        {

        }




        private void SaveBtn_Click_1(object sender, EventArgs e)
        {
            if (UNameTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Missing Information!!");
            }
            else
            {
                if (UNameTb.Text == "admin" && PasswordTb.Text == "1234")
                {
                    Bakery obj = new Bakery();

                    obj.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid User Name And Password!!");
                    UNameTb.Text = "";
                    PasswordTb.Text = "";
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void PasswordTb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
