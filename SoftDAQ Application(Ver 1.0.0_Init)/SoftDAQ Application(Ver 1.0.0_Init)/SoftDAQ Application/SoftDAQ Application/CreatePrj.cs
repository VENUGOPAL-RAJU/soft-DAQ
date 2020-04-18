using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;


namespace SoftDAQ_Application
{
    public partial class CreatePrj : Form
    {
        public CreatePrj()
        {
            InitializeComponent();
            //DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz");
            //DateTime.Text = DateTime.Now.ToString();  
            DateTime.Text = dateTimePicker1.Value.ToString();
            path1.Text= @"D:\Chandrakanth\Backup";
        }
        public class Global
        {
            public static string TestPath;
            public static string TestName;

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        String path2;
        private void Button1_Click(object sender, EventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                dialog.SelectedPath = @"D:\Chandrakanth\Backup";
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    path1.Text = dialog.SelectedPath;
                }

            }           
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            if(Name.Text != " ")
            {
                path2 = path1.Text + @"\"+ Name.Text;

                if (!Directory.Exists(path2))
                    Directory.CreateDirectory(path2);

                //MessageBox.Show("Project Saved Successfully...!!", "Info"); 
                Status.Text = "Project Saved Successfully...!!@"+path2;
                Global.TestPath = path2;
                Global.TestName = Name.Text;

                //Creating Definition File....
                string DefPath = path2 + @"\" + Name.Text + "_Test Definition.def";
                string[] Data = new string[20];
                Data[0] ="Project Name  : " + Name.Text;
                Data[1] = "Project Created On  : " + DateTime.Text;

                File.WriteAllLines(DefPath, Data);

                Status.Refresh();
                Thread.Sleep(500);

                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Project Name...!!", "Info");
            }
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void DateTime_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
