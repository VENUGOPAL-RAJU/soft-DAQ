using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;


namespace GraficDisplay
{
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Thread.Sleep(2000);
            textBox1.Text = ("Name : Chandrakanth M \n Age : 24 Yrs \n Designation :  Integration System Engineer \n Dude...!!");
        }
        public void ChangeText(string Text)
        {
            textBox1.Text = Text;

            //textBox1.Text = "Name : Chandrakanth M \n Age : 24 Yrs \n Designation :  Integration System Engineer \n Dude...!!";

        }
    }
}
