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
using System.Windows.Forms.DataVisualization.Charting;

namespace SoftDAQ_Application
{
    public partial class OfflineWindow : Form
    {
        private const float CZoomScale = 4f;
        private int FZoomLevel = 0;

        private const float CZoomScale21 = 4f;
        private int FZoomLevel21 = 0;

        private const float CZoomScale22 = 4f;
        private int FZoomLevel22 = 0;
        public OfflineWindow()
        {
            InitializeComponent();
            button2.Hide();
        }

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void OfflineWindow_Load(object sender, EventArgs e)
        {

        }

        private void OpenFileDialog1_FileOk_1(object sender, CancelEventArgs e)
        {

        }

        OpenFileDialog ofd = new OpenFileDialog();
        private void Button1_Click(object sender, EventArgs e)
        {
            ofd.Filter="txt|*.txt";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                path.Text = ofd.FileName;
            }
            button2.Show();
        }

        string[] myArray = new string[10000];
        //double[] myArray1 = new double[10000];

        private void Button2_Click(object sender, EventArgs e)
        {
            SetGraphs();

            myArray = File.ReadAllLines(path.Text);

            //for(int i=0; i<myArray.Length; i++)
            //{
            //    myArray1[i] = double.Parse( myArray[i]);
            //}

            chart11.Series[0].Points.Clear();
            chart21.Series[0].Points.Clear();
            chart22.Series[0].Points.Clear();

            chart31.Series[0].Points.Clear();
            chart32.Series[0].Points.Clear();
            chart33.Series[0].Points.Clear();
            chart34.Series[0].Points.Clear();

            for (int j=0; j<myArray.Length; j++)
            {
                chart11.Series[0].Points.AddY(myArray[j]);

                chart21.Series[0].Points.AddY(myArray[j]);
                chart22.Series[0].Points.AddY(myArray[j]);

                chart31.Series[0].Points.AddY(myArray[j]);
                chart32.Series[0].Points.AddY(myArray[j]);
                chart33.Series[0].Points.AddY(myArray[j]);
                chart34.Series[0].Points.AddY(myArray[j]);

                //if(j%10 ==0)
                //chart11.Refresh();

                prgBar1.Value = j;
                prgBar1.Refresh();
                
            }
            Thread.Sleep(500);
            prgBar1.Hide();

        }
        public void SetGraphs()
        {
            chart11.ChartAreas[0].AxisX.MinorGrid.Enabled = true;
            chart11.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            chart11.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.LightGray;
            chart11.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.LightGray;

            chart21.ChartAreas[0].AxisX.MinorGrid.Enabled = true;
            chart21.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            chart21.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.LightGray;
            chart21.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.LightGray;

            chart22.ChartAreas[0].AxisX.MinorGrid.Enabled = true;
            chart22.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            chart22.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.LightGray;
            chart22.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.LightGray;

            chart31.ChartAreas[0].AxisX.MinorGrid.Enabled = true;
            chart31.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            chart31.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.LightGray;
            chart31.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.LightGray;

            chart32.ChartAreas[0].AxisX.MinorGrid.Enabled = true;
            chart32.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            chart32.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.LightGray;
            chart32.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.LightGray;

            chart33.ChartAreas[0].AxisX.MinorGrid.Enabled = true;
            chart33.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            chart33.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.LightGray;
            chart33.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.LightGray;

            chart34.ChartAreas[0].AxisX.MinorGrid.Enabled = true;
            chart34.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            chart34.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.LightGray;
            chart34.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.LightGray;

            // Set automatic zooming
            chart11.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart11.ChartAreas[0].AxisY.ScaleView.Zoomable = true;

            // Set automatic scrolling
            chart11.ChartAreas[0].CursorX.AutoScroll = true;
            chart11.ChartAreas[0].CursorY.AutoScroll = true;

            // Allow user selection for Zoom
            chart11.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart11.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;

            chart11.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart11.ChartAreas[0].AxisY.ScaleView.Zoomable = true;            

            //chart1.ChartAreas[0].CursorX.IsUserEnabled = true;
            chart11.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            //chart1.ChartAreas[0].CursorY.IsUserEnabled = true;
            chart11.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;

            chart21.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart21.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;

            chart22.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart22.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;

            chart31.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart31.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;

            chart32.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart32.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;

            chart33.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart33.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;

            chart34.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart34.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;

            
        }

        private void chart11_MouseWheel(object sender, MouseEventArgs e)
        {
            //// Code implement chart1 zoom
            //try
            //{
            //    Axis xAxis = chart11.ChartAreas[0].AxisX;
            //    double xMin = xAxis.ScaleView.ViewMinimum;
            //    double xMax = xAxis.ScaleView.ViewMaximum;
            //    double xPixelPos = xAxis.PixelPositionToValue(e.Location.X);

            //    if (e.Delta < 0 && FZoomLevel > 0)
            //    {
            //        // Scrolled down, meaning zoom out
            //        if (--FZoomLevel <= 0)
            //        {
            //            FZoomLevel = 0;
            //            xAxis.ScaleView.ZoomReset();
            //        }
            //        else
            //        {
            //            double xStartPos = Math.Max(xPixelPos - (xPixelPos - xMin) * CZoomScale, 0);
            //            double xEndPos = Math.Min(xStartPos + (xMax - xMin) * CZoomScale, xAxis.Maximum);
            //            xAxis.ScaleView.Zoom(xStartPos, xEndPos);
            //        }
            //    }
            //    else if (e.Delta > 0)
            //    {
            //        // Scrolled up, meaning zoom in
            //        double xStartPos = Math.Max(xPixelPos - (xPixelPos - xMin) / CZoomScale, 0);
            //        double xEndPos = Math.Min(xStartPos + (xMax - xMin) / CZoomScale, xAxis.Maximum);
            //        xAxis.ScaleView.Zoom(xStartPos, xEndPos);
            //        FZoomLevel++;
            //    }
            //}
            //catch { }
        }

        private void chart21_MouseWheel(object sender, MouseEventArgs e)
        {

        }

        private void chart22_MouseWheel(object sender, MouseEventArgs e)
        {            
            
        }
        private void SingleDisplayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void DualDisplayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void QuadDisplayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Path_TextChanged(object sender, EventArgs e)
        {

        } 
        private void Chart11_DoubleClick_1(object sender, EventArgs e)
        {
            chart11.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);
            chart11.ChartAreas[0].AxisY.ScaleView.ZoomReset(0);
        }

        private void Chart21_DoubleClick_1(object sender, EventArgs e)
        {
            chart21.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);
            chart21.ChartAreas[0].AxisY.ScaleView.ZoomReset(0);
        }

        private void Chart22_DoubleClick_1(object sender, EventArgs e)
        {
            chart22.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);
            chart22.ChartAreas[0].AxisY.ScaleView.ZoomReset(0);
        }

        private void Chart31_DoubleClick(object sender, EventArgs e)
        {
            chart31.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);
            chart31.ChartAreas[0].AxisY.ScaleView.ZoomReset(0);
        }

        private void Chart32_DoubleClick(object sender, EventArgs e)
        {
            chart32.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);
            chart32.ChartAreas[0].AxisY.ScaleView.ZoomReset(0);
        }

        private void Chart33_DoubleClick(object sender, EventArgs e)
        {
            chart33.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);
            chart33.ChartAreas[0].AxisY.ScaleView.ZoomReset(0);
        }

        private void Chart34_DoubleClick(object sender, EventArgs e)
        {
            chart34.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);
            chart34.ChartAreas[0].AxisY.ScaleView.ZoomReset(0);
        }
    }
}
