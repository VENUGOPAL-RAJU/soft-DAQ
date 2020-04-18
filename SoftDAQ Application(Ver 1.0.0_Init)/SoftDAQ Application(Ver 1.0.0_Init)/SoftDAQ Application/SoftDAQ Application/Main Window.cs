using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Web;

namespace SoftDAQ_Application
{
    public partial class Main_Window : Form
    {
        string FilePath;      
         
        public Main_Window()
        {
            InitializeComponent();
            HideButtons();
            HideBoxes();
            ReadDefaults();            
        }              

        private void HideButtons()  //Hide the Menue buttons Before Login....
        {
            Setup_bt.Hide();
            label1.Hide();
            Measure_bt.Hide();
            label4.Hide();
            Cal_bt.Hide();
            label5.Hide();
            Online_bt.Hide();
            label6.Hide();
            Analysis_bt.Hide();
            label7.Hide();
            Offline_bt.Hide();
            label9.Hide();
            Accounts_bt.Hide();
            label8.Hide();
            Export_bt.Hide();
            label11.Hide();
            Report_bt.Hide();
            label10.Hide();

        }
        private void HideBoxes()  //Hide the List Boxes Before Login....
        {
            label12.Hide();
            treeView1.Hide();
            tabControl1.SelectedIndex = 1;
            //listView1.Hide();
            //listView2.Hide();
            //listView3.Hide();
            //listView4.Hide();
            //listView5.Hide();
        }

        public void ShowButtons()  //Show the Menue buttons After Login....
        {
            button1.Hide();
            Setup_bt.Show();
            label1.Show();
            Measure_bt.Show();
            label4.Show();
            Cal_bt.Show();
            label5.Show();
            Online_bt.Show();
            label6.Show();
            Analysis_bt.Show();
            label7.Show();
            Offline_bt.Show();
            label9.Show();
            Accounts_bt.Show();
            label8.Show();
            Export_bt.Show();
            label11.Show();
            Report_bt.Show();
            label10.Show();
        }
        private void EnableDisable_bt(bool st)
        {
            Measure_bt.Enabled = st;
            label4.Enabled = st;
            Cal_bt.Enabled = st;
            label5.Enabled = st;
            Online_bt.Enabled = st;
            label6.Enabled = st;
            Analysis_bt.Enabled = st;
            label7.Enabled = st;
            Offline_bt.Enabled = st;
            label9.Enabled = st;            
            Export_bt.Enabled = st;
            label11.Enabled = st;
            Report_bt.Enabled = st;
            label10.Enabled = st;
        }
        private void ShowBoxes()  //Show the List Box's After Login....
        {
            label12.Show();
            treeView1.Show();
            listView1.Show();
            listView2.Show();
            listView3.Show();
            listView4.Show();
            listView5.Show();
        }

        private void Main_Window_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {            
            Login l1 = new Login();            
            l1.ShowDialog(this);
            
            //l1.BringToFront();            
            //this.Close();
            //ShowButtons();  
            //this.WindowState = FormWindowState.Minimized;
        }
        public void NotifyMe(bool a)
        {
            // Do whatever you need to do with the string
            ShowButtons();
            EnableDisable_bt(false);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.Close();
            Application.Exit();
        }

        private void Offline_bt_Click(object sender, EventArgs e)
        {
            OfflineWindow of1 = new OfflineWindow();
            of1.ShowDialog();
        }

        private void Online_bt_Click(object sender, EventArgs e)
        {
            bool st = false;
            OnlineDisplay a1 = new OnlineDisplay(st);
            a1.ShowDialog();
            //this.Hide();

            if(st)
            NotifyMe1(st);
        }
        public void NotifyMe1(bool a)
        {
            this.Show();
            //this.WindowState = FormWindowState.Normal;
        }

        string[,] myArray1=new string[100,100];                                       //Creating Array....       
        private void Setup_bt_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            string openPath;

            string message = "Do you want to Create New Project -> Click on 'Yes' (or) Open Existing Project -> Click on 'No' ...??";
            string title = "Open/Create";
            MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                CreatePrj c1 = new CreatePrj();
                c1.ShowDialog(this);
                //this.Close();
            }            
            else if(result == DialogResult.No)
            {
                //Open Existing Project....
                ofd.Filter = "Definition|*.def";
                if (ofd.ShowDialog() == DialogResult.OK)
                {                   
                    openPath = ofd.FileName;
                    CreatePrj.Global.TestPath = String.Join(@"\", openPath.Split('\\').Reverse().Skip(1).Reverse());
                    CreatePrj.Global.TestName = String.Join(@"\", CreatePrj.Global.TestPath.Split('\\').Skip(3));                    
                }
            }  
            else {
                // Do something
                //this.Close();
            }

            tabControl1.SelectedIndex = 0;
            ShowBoxes();
            //SetupConfiguration s1 = new SetupConfiguration();
            //s1.Show();
            //this.Hide();
            waitLable.Text = "Please Wait Scan to Complete...";
            waitLable.Refresh();
            for (int i=0; i<=100; i++)
            {
                scaningBar1.Value = i;
                ScanLable.Text = "Scaning the Modules..." + i + "%";
                scaningBar1.Refresh();
                ScanLable.Refresh();
                Thread.Sleep(50);
            }
            ScanLable.Text = "Scan Completed...100%";
            waitLable.Text = " ";

            //Assigning Values to Array...

            //myArray1[0,0] ="Module Name"; myArray1[0, 1] = "Channel Number";
            //myArray1[0,2] = "Channel Name"; myArray1[0, 3] = "Sampling Rate";

            EnableDisable_bt(true);
        }
        
        private void ReadDefaults()
        { 
            string[][] Data= File.ReadAllLines(@"D:\ConfigFile1.txt").Select(line => line.Split('\t')).ToArray();

            File.WriteAllText(@"F:\ConfigFile11112.txt",Data[0][1]);

            int n = 0;
            for (int j = 0; j < 26; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    myArray1[j, i] = Data[j][i];
                    n++;
                }
            }

        }

        private void Report_bt_Click(object sender, EventArgs e)
        {
            TestRun t1 = new TestRun();
            t1.Show();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void Export_bt_Click(object sender, EventArgs e)
        {
            ExportWindow ex1 = new ExportWindow();
            ex1.ShowDialog();
        }

        private void Analysis_bt_Click(object sender, EventArgs e)
        {
            AnalysisWindow a1 = new AnalysisWindow();
            a1.ShowDialog();
        }

        private void Report_bt_Click_1(object sender, EventArgs e)
        {
            ReportGeneration rp1 = new ReportGeneration();
            rp1.ShowDialog();
        }

        private void Cal_bt_Click(object sender, EventArgs e)
        {
            CalibrationWindow cal1 = new CalibrationWindow();
            cal1.ShowDialog();
        }

        private void Measure_bt_Click(object sender, EventArgs e)
        {
            Measurement ms1 = new Measurement();
            ms1.ShowDialog();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            try
            {
                FilePath = CreatePrj.Global.TestPath + @"\ChanneList.txt";
                SaveTreeViewIntoFile(FilePath, treeView1);
                //Channel = treeView1.SelectedNode.Parent.Text;
                treeView1.Select();
                // File.WriteAllText(CreatePrj.Global.TestPath + @"\ConfigFile0.txt", Channel);

                using (var sw = new StreamWriter(CreatePrj.Global.TestPath + @"\ConfigFile1.txt"))
                {
                    for (int i = 0; i < 26; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            sw.Write(myArray1[i, j] + "\t");
                        }
                        sw.Write("\n");
                    }
                    sw.Flush();
                    sw.Close();
                }
            }
            catch (Exception a)
            {
                Console.Write("Exception: " + a.Message);
            }           

        }
        private void SaveTreeViewIntoFile(string file_name, TreeView trv)       //Write Tree View Value in to File....
        {
            // Build a string containing the TreeView's contents.
            StringBuilder sb = new StringBuilder();
            foreach (TreeNode node in trv.Nodes)
                WriteNodeIntoString(0, node, sb);           
            // Write the result into the file.
            File.WriteAllText(file_name, sb.ToString());
        }
        private void WriteNodeIntoString(int level, TreeNode node, StringBuilder sb)
        {
            // Append the correct number of tabs and the node's text.
            sb.AppendLine(new string('\t', level) + node.Text);

            // Recursively add children with one greater level of tabs.
            foreach (TreeNode child in node.Nodes)
                WriteNodeIntoString(level + 1, child, sb);
        }

        int i= 2;
        int j = 0;
        int CurrentIndex = 0;
        int ChCount = 2;

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            j = 0;
            ChCount += 1;
                      
            try
            {
                if (treeView1.SelectedNode.Parent.Index == 0)
                {
                    CurrentIndex = treeView1.SelectedNode.Index + 2;

                    myArray1[CurrentIndex, 0] = treeView1.SelectedNode.Parent.Text;
                    j += 1;
                    myArray1[CurrentIndex, 1] = treeView1.SelectedNode.Text;
                    i += 1;

                    ChannelName.Text = myArray1[CurrentIndex, 2];
                    comboBox1.SelectedItem= myArray1[CurrentIndex, 3];
                }

                else if (treeView1.SelectedNode.Parent.Index == 1)
                {
                    CurrentIndex = treeView1.SelectedNode.Index + 10;

                    myArray1[CurrentIndex, 0] = treeView1.SelectedNode.Parent.Text;
                    j += 1;
                    myArray1[CurrentIndex, 1] = treeView1.SelectedNode.Text;
                    i += 1;

                    ChannelName.Text = myArray1[CurrentIndex, 2];
                    comboBox1.SelectedItem = myArray1[CurrentIndex, 3];
                }

                else
                {
                    CurrentIndex = treeView1.SelectedNode.Index + 18;

                    myArray1[CurrentIndex, j] = treeView1.SelectedNode.Parent.Text;
                    j += 1;
                    myArray1[CurrentIndex, j] = treeView1.SelectedNode.Text;
                    i += 1;

                    ChannelName.Text = myArray1[CurrentIndex, 2];
                    comboBox1.SelectedItem = myArray1[CurrentIndex, 3];
                }
            }

            catch (Exception a)
            {
                Console.Write("Exception: " + a.Message);
            }

        }

        private void TreeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            //myArray1[i, j] = treeView1.SelectedNode.Text;
            //i += 1;
        }

        private void TreeView1_MouseClick(object sender, MouseEventArgs e)
        {
            treeView1.SelectedNode = treeView1.Nodes[0].Nodes[0];
            tabControl1.SelectedIndex = 2;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            myArray1[CurrentIndex, 3] = comboBox1.SelectedItem.ToString();
        }

        private void ChannelName_TextChanged(object sender, EventArgs e)
        {
            myArray1[CurrentIndex, 2] = ChannelName.Text;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            treeView1.SelectedNode = treeView1.SelectedNode.NextVisibleNode;
        }
    }
}
