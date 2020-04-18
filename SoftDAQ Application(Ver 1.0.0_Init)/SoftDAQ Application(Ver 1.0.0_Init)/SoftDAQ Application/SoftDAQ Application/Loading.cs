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
    public partial class Loading : Form
    {
        Main_Window m1 = new Main_Window();
        public Loading()
        {
            InitializeComponent();
            Load1.Text = "Click to Start...";
            //Startup();
        }

        public void Startup()
        {           
            Load1.Text = "0%";
            for (int i = 0; i <= 100; i++)
            {            
               
                prgBar1.Value = i;                
                Load1.Text = "Loading..."+i.ToString() + "%";
                prgBar1.Refresh();
                Load1.Refresh();
                Thread.Sleep(50);
            }

            //Thread.Sleep(500);
            prgBar1.Refresh();

            if (prgBar1.Value == 100)
            {           

                //this.ParentForm.Hide();
                m1.Show();
                this.Hide();
            }

        }

        //Load1.Text = "1%";

        public void prgBar1_Click(object sender, EventArgs e)
        {

            Startup();
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
                      

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Loading_Load(object sender, EventArgs e)
        {
            //Startup();
            //this.Hide();
        }

        private void Loading_Click(object sender, EventArgs e)
        {
            Startup();
        }

        private void Loading_MouseEnter(object sender, EventArgs e)
        {
            Refresh();
            Startup();
        }
    }
}
