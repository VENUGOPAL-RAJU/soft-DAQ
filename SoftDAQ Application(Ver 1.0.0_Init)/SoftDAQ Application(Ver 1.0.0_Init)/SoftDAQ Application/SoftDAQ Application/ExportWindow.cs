using System;
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
using System.Windows.Forms.DataVisualization.Charting;


namespace SoftDAQ_Application
{
    public partial class ExportWindow : Form
    {
        private const float CZoomScale = 4f;
        private int FZoomLevel = 0;
        public ExportWindow()
        {
            InitializeComponent();
            button2.Hide();           
            chart1.MouseWheel += new System.Windows.Forms.MouseEventHandler(chart1_MouseWheel);
            //this.MouseWheel += new MouseEventHandler(ExportWindow_MouseWheel);
        }

        OpenFileDialog ofd = new OpenFileDialog();
        private void Button1_Click(object sender, EventArgs e)
        {
            ofd.Filter = "txt|*.txt";
            ofd.InitialDirectory = CreatePrj.Global.TestPath;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path.Text = ofd.FileName;
            }
            button2.Show();
        }

        string[] myArray = new string[10000];
        //double[] myArray1 = new double[10000];
        string path1;

        private void Button2_Click(object sender, EventArgs e)
        {
            SetGraphs();
            myArray = File.ReadAllLines(path.Text);

            //for (int i = 0; i < myArray.Length; i++)
            //{
            //    myArray1[i] = double.Parse(myArray[i]);
            //}

            chart1.Series[0].Points.Clear();

            for (int j = 0; j < myArray.Length; j++)
            {
                chart1.Series[0].Points.AddY(myArray[j]);

                progressBar1.Value = j;
                progressBar1.Refresh();
            }
            chart1.Refresh();           

            Thread.Sleep(500);
            progressBar1.Hide();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            path1 = CreatePrj.Global.TestPath + @"\Exported Data";
            if (!Directory.Exists(path1))
                Directory.CreateDirectory(path1);

            File.WriteAllLines(path1 + @"\" + CreatePrj.Global.TestName +"_Data.txt", myArray);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
           
        }

        public void SetGraphs()
        {
            chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = true;
            chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            chart1.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.LightGray;
            chart1.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.LightGray;

            // Set automatic zooming
            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = false;
            chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = false;

            // Set automatic scrolling
            chart1.ChartAreas[0].CursorX.AutoScroll = false;
            chart1.ChartAreas[0].CursorY.AutoScroll = false;

            // Allow user selection for Zoom
            chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = false;
            chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled =false;

            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = false;
            chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = false;

            chart1.MouseWheel += new MouseEventHandler(chart1_MouseWheel);

           //chart1.ChartAreas[0].CursorX.IsUserEnabled = true;
            chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            //chart1.ChartAreas[0].CursorY.IsUserEnabled = true;
            chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;          

        }
       
        private void chart1_MouseWheel(object sender, MouseEventArgs e)
        {
            // Code implement chart1 zoom
            try
            {
                Axis xAxis = chart1.ChartAreas[0].AxisX;
                double xMin = xAxis.ScaleView.ViewMinimum;
                double xMax = xAxis.ScaleView.ViewMaximum;
                double xPixelPos = xAxis.PixelPositionToValue(e.Location.X);

                if (e.Delta < 0 && FZoomLevel > 0)
                {
                    // Scrolled down, meaning zoom out
                    if (--FZoomLevel <= 0)
                    {
                        FZoomLevel = 0;
                        xAxis.ScaleView.ZoomReset();
                    }
                    else
                    {
                        double xStartPos = Math.Max(xPixelPos - (xPixelPos - xMin) * CZoomScale, 0);
                        double xEndPos = Math.Min(xStartPos + (xMax - xMin) * CZoomScale, xAxis.Maximum);
                        xAxis.ScaleView.Zoom(xStartPos, xEndPos);
                    }
                }
                else if (e.Delta > 0)
                {
                    // Scrolled up, meaning zoom in
                    double xStartPos = Math.Max(xPixelPos - (xPixelPos - xMin) / CZoomScale, 0);
                    double xEndPos = Math.Min(xStartPos + (xMax - xMin) / CZoomScale, xAxis.Maximum);
                    xAxis.ScaleView.Zoom(xStartPos, xEndPos);
                    FZoomLevel++;
                }
            }
            catch { }
        }
    


        private void Chart1_DoubleClick(object sender, EventArgs e)
        {            
            chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);
            chart1.ChartAreas[0].AxisY.ScaleView.ZoomReset(0);
        }

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePoint = new Point(e.X, e.Y);

            chart1.ChartAreas[0].CursorX.SetCursorPixelPosition(mousePoint, true);
            chart1.ChartAreas[0].CursorY.SetCursorPixelPosition(mousePoint, true);

            // ...
        }

        private void NumericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].CursorX.SetSelectionPosition((double) numericUpDown3.Value, (double) numericUpDown4.Value);
            //chart1.ChartAreas[0].CursorY.SetCursorPosition((double) 0);
        }

        private void Chart1_CursorPositionChanged(object sender, CursorEventArgs e)
        {
            
        }

        private void Chart1_CursorPositionChanging(object sender, CursorEventArgs e)
        {

        }
        int a = 0;
        int b = 100;
        int c = 0;
        private void Chart1_SelectionRangeChanging(object sender, CursorEventArgs e)
        {            

            numericUpDown3.Maximum = int.MaxValue;
            numericUpDown3.Minimum = int.MinValue;
            numericUpDown4.Maximum = int.MaxValue;
            numericUpDown4.Minimum = int.MinValue;

            double pX = chart1.ChartAreas[0].CursorX.SelectionStart; //X Axis Coordinate of your mouse cursor
            double pX1 = chart1.ChartAreas[0].CursorX.SelectionEnd;
            double pY = chart1.ChartAreas[0].CursorY.SelectionStart; //Y Axis Coordinate of your mouse cursor
            double pY1 = chart1.ChartAreas[0].CursorY.SelectionEnd;

            a = (int)pX;
            b = (int)pX1;
            c = b - a;

            numericUpDown3.Value = a;
            numericUpDown4.Value = b;            
        }

        private void NumericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].CursorX.SetSelectionPosition((double)numericUpDown3.Value, (double)numericUpDown4.Value);
        }


        string[] myArray2 = new string[10000];
        private void Button4_Click(object sender, EventArgs e)
        {
            Array.Clear(myArray2, 0, myArray2.Length);

            path1 = CreatePrj.Global.TestPath + @"\Exported Data";
            if (!Directory.Exists(path1))
                Directory.CreateDirectory(path1);           

                Array.Copy(myArray, a,myArray2, 0, c);

            myArray2 = myArray2.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            File.WriteAllLines(path1 + @"\" + CreatePrj.Global.TestName + "_Data.txt", myArray2);
          
        }
    }
}
