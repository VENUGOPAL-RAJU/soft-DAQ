qqusing System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace SoftDAQ_Application
{
    public partial class AnalysisWindow : Form
    {
        public AnalysisWindow()
        {
            InitializeComponent();
            button3.Hide();
            button2.Enabled = false;
            comboBox1.SelectedIndex = 0;
            EnableDisable();
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        string[] myFiles = new string[10];
        string[] row = new string[10];
        string[] Data1 = new string[10];
        string TestName;
        string TestDate;

        private void Button1_Click(object sender, EventArgs e)
        {
            DateTimeComp();

            dataGridView1.Columns.Clear();
            dataGridView1.ColumnCount = 5; 
            dataGridView1.Columns[0].Name = "S.No";            
            dataGridView1.Columns[1].Name = "Test Name";
            dataGridView1.Columns[2].Name = "Held on";
            dataGridView1.Columns[3].Name = "Test Path";
            dataGridView1.Columns[4].Name = "Test Result";
           
            string path1 = String.Join(@"\", CreatePrj.Global.TestPath.Split('\\').Reverse().Skip(1).Reverse());
            myFiles = Directory.GetFiles(path1, "*.def", SearchOption.AllDirectories);

            int SN = 1;
            for (int i=0; i<myFiles.Length;i++)
            {
                Data1= File.ReadAllLines(myFiles[i]);
                TestDate = Data1[1];
                TestDate = TestDate.Substring(21);
                
                TestName= String.Join(@"\", myFiles[i].Split('\\').Skip(3));
                TestName= String.Join(@"\", TestName.Split('\\').Reverse().Skip(1).Reverse());

                if (comboBox1.SelectedIndex == 0)                                                                   //Option 1....
                {
                    //Using Date and Time....
                    int res2 = DateTime.Compare(DateTime.Parse(TestDate), dateTimePicker1.Value);                   //Comparing Dates....
                    int res3 = DateTime.Compare(DateTime.Parse(TestDate), dateTimePicker2.Value);

                    if (res2 >= 0 && res3 <= 0)
                    {
                        row = new string[] { SN.ToString(), TestName, TestDate, myFiles[i] };                       //To the Tab....
                        dataGridView1.Rows.Add(row);
                        SN += 1;
                    }
                }                
                else if(comboBox1.SelectedIndex == 1)                                                                //Option 2....
                {
                    //Using Reference Number...                    
                    if (TestName==textBox1.Text)
                    {
                        row = new string[] { SN.ToString(), TestName, TestDate, myFiles[i] };                        //To the Tab....
                        dataGridView1.Rows.Add(row);
                        SN += 1;
                    }
                    //else
                    //{
                    //    string message = "Sorry the Entered Test Folder/File Doesn't Exist, Please re-verify Entered Reference Number...!! ";
                    //    string title = "Info";
                    //    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    //    DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                    //}

                }
                else                                                                                                 //Option 3.....
                {
                    string message = "Sorry the selected Search By Feature is Not Available, Please re-select option...!! ";
                    string title = "Info";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);

                    comboBox1.SelectedIndex = 0;
                }

            }
            dataGridView1.AutoResizeColumns();
            dataGridView1.Columns[3].Width = 500;
            dataGridView1.Columns[4].Width = 200;
            button2.Enabled = true;

        }
        string selectedPath;
        string selectedTest;
        string[] myArray1 = new string[10000];
        private void Button2_Click(object sender, EventArgs e)
        {  
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    SetGraphs();

                    //int a = dataGridView1.SelectedRows[0].Index;

                    selectedPath = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                    selectedPath = String.Join(@"\", selectedPath.Split('\\').Reverse().Skip(1).Reverse());
                    selectedTest = String.Join(@"\", selectedPath.Split('\\').Skip(3));
                    selectedPath = selectedPath + @"\Exported Data" + @"\" + selectedTest + "_Data.txt";
                    //textBox3.Text = selectedPath;
                    //textBox3.Enabled = true;

                    if (File.Exists(selectedPath))
                    {
                        myArray1 = File.ReadAllLines(selectedPath);

                        myArray1 = myArray1.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                        chart1.Series[0].Points.Clear();

                        for (int i = 0; i < myArray1.Length; i++)
                        {
                            chart1.Series[0].Points.AddY(myArray1[i]);
                        }
                        Thread.Sleep(500);
                        tabControl1.SelectedIndex = 1;
                        button3.Show();
                    }
                    else
                    {
                        string message = "Sorry Exported Data File Doesn't Exist in the Selected Test Folder, Please re-verify your selected test file...!! ";
                        string title = "Info";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                    }
                }
               
            }
            catch { }

        }
        private void DateTimeComp()
        {
            DateTime d1 = dateTimePicker1.Value;
            DateTime d2 = dateTimePicker2.Value;
            int res = DateTime.Compare(dateTimePicker1.Value, dateTimePicker2.Value);                    
          
        }
        private void EnableDisable()
        {
            if(comboBox1.SelectedIndex==0)
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
            }
            else if(comboBox1.SelectedIndex == 1)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
            }
            else
            {
                textBox1.Enabled = false;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            button3.Hide();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableDisable();
        }

        private void SetGraphs()
        {
            chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = true;
            chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            chart1.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.LightGray;
            chart1.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.LightGray;

            // Set automatic zooming
            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = true;

            // Set automatic scrolling
            chart1.ChartAreas[0].CursorX.AutoScroll = true;
            chart1.ChartAreas[0].CursorY.AutoScroll = true;

            // Allow user selection for Zoom
            chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
        }

        private void Chart1_DoubleClick(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);
            chart1.ChartAreas[0].AxisY.ScaleView.ZoomReset(0);
        }
    }
    
}
