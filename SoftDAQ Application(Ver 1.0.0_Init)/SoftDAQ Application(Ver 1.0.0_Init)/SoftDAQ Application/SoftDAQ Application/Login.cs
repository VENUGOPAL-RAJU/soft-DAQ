using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace SoftDAQ_Application
{
    public partial class Login : Form
    {     
        public Login()
        {
            InitializeComponent();
            radioButton1.Checked = true;
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
               
        private void button1_Click(object sender, EventArgs e)
        {
            string message = "\"Loged on Successfully As a Administrator....!!\"";
            string title = "Info";
            if (Name.Text=="Admin" && Password.Text=="admin")
            { 
                MessageBox.Show(message, title);
                
                Main_Window parent = (Main_Window)this.Owner;               //Sending Status back....!!
                parent.NotifyMe(true);              
                this.Close();                
            }
            else
            {
                message = "Please Check the User Credentials...!!";
                MessageBox.Show(message, title);
               
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                radioButton2.Checked = false;
            }
            else
            {
                radioButton2.Checked = true;
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void Password_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked==true)
            {
                radioButton1.Checked = false;
            }
            else
            {
                radioButton1.Checked = true;
            }
        }
    }
}
