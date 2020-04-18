using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;
using System.Threading.Tasks;

namespace SoftDAQ_Application
{
    public partial class OnlineDisplay : Form
    {
        
        public OnlineDisplay(bool a)
        {
            InitializeComponent();           
            Record_bt.Enabled = false;
            a =true;
        }

        private void chart2_Click(object sender, EventArgs e)
        {
           
        }
        //Importing Alphi C++ Dll.........
        //[DllImport("IP8100 test.dll")]
        [DllImport("IP8100 test.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double SingleDll(int a, int b, int c, double[] g);


        private void Start_bt_Click(object sender, EventArgs e)
        {
            AcquireData();
            //SetGraphs();       
            Parallel.Invoke(new Action(UpdateData),new Action (SetGraphs));
        }

        double[] myArray = new double[10000];            //Declaring Buffer's (Array).....
        double[] myArray1 = new double[10000];
        int maximumX = 0;
        int maximumX1 = 1;
        int Max1 = 10;
        int Max22 = 10;
        int Max21 = 10;
        int Dlength = 1000;                              //No.of Samples to plot at one loop (Data Length).....
        private object backgroundWorker1;

        private void AcquireData()
        {
            SingleDll(0, 10000, 20000, myArray);            
        }

        private void UpdateData()
        {
            SetMinMax();

            for (int j = 0; j <= myArray.Length / Dlength; j++)
            {
                chart11.Series[0].Points.Clear();

                chart21.Series["Data 1"].Points.Clear();
                chart22.Series["Data 1"].Points.Clear();
                chart31.Series["Data 1"].Points.Clear();
                chart32.Series["Data 1"].Points.Clear();
                chart33.Series["Data 1"].Points.Clear();
                chart34.Series["Data 1"].Points.Clear();

                for (Int32 i = 0; i <= Dlength; i++)
                {
                    myArray1[i] = (myArray[i] * 10) / 32767 * 1;

                    chart11.Series[0].Points.AddY(myArray1[i]);

                    chart21.Series["Data 1"].Points.AddY(myArray1[i]);
                    chart22.Series["Data 1"].Points.AddY(myArray1[i]);
                    chart31.Series["Data 1"].Points.AddY(myArray1[i]);
                    chart32.Series["Data 1"].Points.AddY(myArray1[i]);
                    chart33.Series["Data 1"].Points.AddY(myArray1[i]);
                    chart34.Series["Data 1"].Points.AddY(myArray1[i]);

                    if (i % 10 == 0)
                    {
                        chart11.Refresh();

                        chart21.Refresh();
                        chart22.Refresh();

                        chart31.Refresh();
                        chart32.Refresh();
                        chart33.Refresh();
                        chart34.Refresh();
                    }
                    maximumX = i;
                    Max22 = i;
                    Max21 = i;
                }

            }
            maximumX1 = maximumX / 10;
            maximumX = maximumX - maximumX1;
            Record_bt.Enabled = true;
        }

        private void Scale_Click(object sender, EventArgs e)
        {
            chart11.ChartAreas[0].AxisX.Minimum = 0;
            chart11.ChartAreas[0].AxisX.Maximum = 100;
            chart21.ChartAreas[0].AxisX.Minimum = 0;
            chart21.ChartAreas[0].AxisX.Maximum = 100;
            chart22.ChartAreas[0].AxisX.Minimum = 0;
            chart22.ChartAreas[0].AxisX.Maximum = 100;
            chart31.ChartAreas[0].AxisX.Minimum = 0;
            chart31.ChartAreas[0].AxisX.Maximum = 100;
            chart32.ChartAreas[0].AxisX.Minimum = 0;
            chart32.ChartAreas[0].AxisX.Maximum = 100;
            chart33.ChartAreas[0].AxisX.Minimum = 0;
            chart33.ChartAreas[0].AxisX.Maximum = 100;
            chart34.ChartAreas[0].AxisX.Minimum = 0;
            chart34.ChartAreas[0].AxisX.Maximum = 100;
        }


        private void displayToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void chart31_Click(object sender, EventArgs e)
        {

        }

        private void singleGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void doubleGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void quadGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void chart11_Click(object sender, EventArgs e)
        {

        }
        private void SetGraphs()                                    //Setting Graph Properties....
        {
            //chart11.ChartAreas[0].AxisX.Title = "Time (s)";
            //chart11.ChartAreas[0].AxisY.Title = "Voltage (V)";

            chart11.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            //chart11.ChartAreas[0].AxisY.MinorGrid.Interval = 0.01;
            chart11.ChartAreas[0].AxisX.MinorGrid.Enabled = true;
            //chart11.ChartAreas[0].AxisX.MinorGrid.Interval = 0.1;
            chart11.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.LightGray;
            chart11.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.LightGray;
            chart11.ChartAreas[0].AxisX.ScaleView.Zoomable = true;

            chart31.ChartAreas[0].AxisX.MinorGrid.Enabled = true;
            chart32.ChartAreas[0].AxisX.MinorGrid.Enabled = true;
            chart33.ChartAreas[0].AxisX.MinorGrid.Enabled = true;
            chart34.ChartAreas[0].AxisX.MinorGrid.Enabled = true;

            chart31.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.LightGray;
            chart31.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.LightGray;
            chart32.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.LightGray;
            chart32.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.LightGray;
            chart33.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.LightGray;
            chart33.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.LightGray;
            chart34.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.LightGray;
            chart34.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.LightGray;

            chart31.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            chart32.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            chart33.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            chart34.ChartAreas[0].AxisY.MinorGrid.Enabled = true;

            chart21.ChartAreas[0].AxisX.MinorGrid.Enabled = true;
            chart22.ChartAreas[0].AxisX.MinorGrid.Enabled = true;

            chart21.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            chart22.ChartAreas[0].AxisY.MinorGrid.Enabled = true;

            chart21.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.LightGray;
            chart21.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.LightGray;
            chart22.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.LightGray;
            chart22.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.LightGray;

        }
        public void SetMinMax()                                    //Setting Graphs Minimum & Maximum Scale Values...
        {
            chart11.Series[0].ChartType = SeriesChartType.Spline;
            //chart11.Series[0].Color = Color.DarkGreen;

            chart11.ChartAreas[0].AxisX.Minimum = 0;
            chart11.ChartAreas[0].AxisX.Maximum = Dlength;

            chart21.ChartAreas[0].AxisX.Minimum = 0;
            chart21.ChartAreas[0].AxisX.Maximum = Dlength;
            chart22.ChartAreas[0].AxisX.Minimum = 0;
            chart22.ChartAreas[0].AxisX.Maximum = Dlength;

            chart31.ChartAreas[0].AxisX.Minimum = 0;
            chart31.ChartAreas[0].AxisX.Maximum = Dlength;
            chart32.ChartAreas[0].AxisX.Minimum = 0;
            chart32.ChartAreas[0].AxisX.Maximum = Dlength;
            chart33.ChartAreas[0].AxisX.Minimum = 0;
            chart33.ChartAreas[0].AxisX.Maximum = Dlength;
            chart34.ChartAreas[0].AxisX.Minimum = 0;
            chart34.ChartAreas[0].AxisX.Maximum = Dlength;


        }

        private void chart11_Click_1(object sender, EventArgs e)
        {
            //chart11.ChartAreas[0].AxisX.Minimum = 0;
            //chart11.ChartAreas[0].AxisX.Maximum = 100;
        }

        private void chart21_Click(object sender, EventArgs e)
        {

        }

        private void chart22_Click(object sender, EventArgs e)
        {

        }

        private void chart22_Click_1(object sender, EventArgs e)
        {
            Max22 = Max22 - maximumX1;
            if (Max22 >= 100)
            {
                chart22.ChartAreas[0].AxisX.Minimum = 0;
                chart22.ChartAreas[0].AxisX.Maximum = Max22;
            }
            else if (Max22 < 100)
            {
                Max22 = maximumX / 10;

                chart22.ChartAreas[0].AxisX.Minimum = 0;
                chart22.ChartAreas[0].AxisX.Maximum = Max22;

                if (Max22 <= 10)
                {
                    MessageBox.Show("Zoom in Limit Reached...!!", "Info");
                }
            }
        }

        private void chart21_Click_1(object sender, EventArgs e)
        {
            Max21 = Max21 - maximumX1;
            if (Max21 >= 100)
            {
                chart21.ChartAreas[0].AxisX.Minimum = 0;
                chart21.ChartAreas[0].AxisX.Maximum = Max21;
            }
            else if (Max21 < 100)
            {
                Max21 = maximumX / 10;
                chart21.ChartAreas[0].AxisX.Minimum = 0;
                chart21.ChartAreas[0].AxisX.Maximum = Max21;

                if (Max21 <= 10)
                {
                    MessageBox.Show("Zoom in Limit Reached...!!", "Info");
                }
            }
        }

        private void chart11_MouseUp(object sender, MouseEventArgs e)
        {
            //chart11.ChartAreas[0].AxisX.Minimum = 0;
            //chart11.ChartAreas[0].AxisX.Maximum = Max1;
            //Max1++;
        }

        private void chart11_MouseDoubleClick(object sender, MouseEventArgs e)      //Chart 11: X-Axis Zooming....
        {
            Max1 = maximumX - maximumX1;
            if (Max1 >= 100)
            {
                chart11.ChartAreas[0].AxisX.Minimum = 0;
                chart11.ChartAreas[0].AxisX.Maximum = Max1;
                maximumX = maximumX - maximumX1;
            }
            else if (Max1 < 100)
            {
                Max1 = maximumX / 10;
                chart11.ChartAreas[0].AxisX.Minimum = 0;
                chart11.ChartAreas[0].AxisX.Maximum = Max1;

                if (Max1 <= 10)
                {
                    MessageBox.Show("Zoom in Limit Reached...!!", "Info");
                }
            }
            else
            {
                MessageBox.Show("Zoom in Limit Reached...!!", "Info");
            }
        }

        private void Record_bt_Click(object sender, EventArgs e)                            //Recording Data (myArray)......
        {
            String path = @"E:\Data1Zz.txt";
            String[] DataArray = new string[10000];

            for (int i = 0; i < myArray.Length; i++)
            {
                // myArray1[i] = (myArray[i] * 10) / 32767 * 1;
                DataArray[i] = myArray[i].ToString();
            }

            File.WriteAllLines(path, DataArray);
        }

        private void OnlineDisplay_FormClosed(object sender, FormClosedEventArgs e)
        {   
           
            //Main_Window m1 =new Main_Window();
            //m1.Show();
            //m1.Refresh();
        }
    }
   
}
