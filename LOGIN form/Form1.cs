using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Falcon_X_Cheat;
using KeyAuth;

namespace LOGIN_form
{
    public partial class Form1 : Form
    {
        public static api KeyAuthApp = new api(
    name: "panel by salvators",
    ownerid: "0EWSko8tuo",
    secret: "f18b1766426d0d78f39edcecf8458b16c4835269ab8d8b1e73611c591b6ef613",
    version: "1.0" /*,
    path: @"Your_Path_Here" */ // see tutorial here https://www.youtube.com/watch?v=I9rxt821gMk&t=1s
);
        public Form1()
        {
            InitializeComponent();
            
            
        }
        public void Alert(string msg, FXMSG.enmType type)
        {
            FXMSG frm = new FXMSG();
            frm.showAlert(msg, type);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            KeyAuthApp.init();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void siticoneTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void siticoneTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void siticonePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void siticoneTextBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ControlBox2_Click(object sender, EventArgs e)
        {

        }

        private void siticoneTextBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LOGINBTN_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {

        }

       

        private void login_Click(object sender, EventArgs e)
        {
            KeyAuthApp.login(username.Text, password.Text);
            if (KeyAuthApp.response.success)

            {
                PPMAIN form = new PPMAIN();
                form.Show();
                this.Hide();

            }
            else
            
            {
                this.Alert((KeyAuthApp.response.message), FXMSG.enmType.Applied);//Error//Applying
            }








        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }

        private void Status_Click(object sender, EventArgs e)
        {

        }
    }
}
