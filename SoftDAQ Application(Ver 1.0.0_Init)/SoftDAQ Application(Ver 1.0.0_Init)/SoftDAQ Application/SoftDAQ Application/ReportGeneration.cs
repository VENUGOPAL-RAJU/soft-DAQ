using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Web.UI;
using System.Web.Services;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.IO;
//using iTextSharp.text;
//using iTextSharp.text.pdf;


namespace SoftDAQ_Application
{
    public partial class ReportGeneration : Form
    {
        public ReportGeneration()
        {
            InitializeComponent();
            button2.Hide();
            comboBox2.SelectedIndex = 0;
            //g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size, CopyPixelOperation.SourceCopy);
        }

        OpenFileDialog ofd = new OpenFileDialog();
        private void Button1_Click(object sender, EventArgs e)
        {
            ofd.Filter = "txt|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path.Text = ofd.FileName;
            }
            button2.Show();
        }

        string[] myArray = new string[10000];       
        private void Button2_Click(object sender, EventArgs e)
        {
            SeGraphs();

            myArray = myArray.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            chart1.Series[0].Points.Clear();

            myArray = File.ReadAllLines(path.Text);

            for (int j = 0; j < myArray.Length; j++)
            {
                chart1.Series[0].Points.AddY(myArray[j]);
            }
        }
        private void SeGraphs()
        {
            chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = true;
            chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            chart1.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.LightGray;
            chart1.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.LightGray;
        }

        private void Button5_Click(object sender, EventArgs e)
        {

            // Call your captureScreen() function
            captureScreen();

            // Create new pdf document and page
            PdfDocument doc = new PdfDocument();
            PdfPage oPage = new PdfPage();

            // Add the page to the pdf document and add the captured image to it
            doc.Pages.Add(oPage);
           oPage.Rotate = 90;

            XGraphics xgr = XGraphics.FromPdfPage(oPage);
            XImage img = XImage.FromFile(CreatePrj.Global.TestPath + @"\Report_IMG.png");
            xgr.DrawImage(img, 0, 0);

            doc.Save(CreatePrj.Global.TestPath + @"\"+ CreatePrj.Global.TestName + "_Report.pdf");
            doc.Close();

            // I used the Dispose() function to be able to 
            // save the same form again, in case some values have changed.
            // When I didn't use the function, an GDI+ error occurred.
            img.Dispose();

        }

        private void captureScreen()
        {
            try
            {
                Rectangle bounds = this.Bounds;
                using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size, CopyPixelOperation.SourceCopy);
                    }
                    bitmap.Save(CreatePrj.Global.TestPath + @"\Report_IMG.png", ImageFormat.Png);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }

        }

        private void Print_Click(object sender, EventArgs e)
        {
            System.Drawing.Printing.PrintDocument doc = new System.Drawing.Printing.PrintDocument();              //Print....
            doc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(doc_PrintPage);
            doc.Print();
        }
        private void doc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Panel grd = new Panel();
            Bitmap bmp = new Bitmap(grd.Width, grd.Height, grd.CreateGraphics());
            grd.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, grd.Width, grd.Height));
            RectangleF bounds = e.PageSettings.PrintableArea;
            float factor = ((float)bmp.Height / (float)bmp.Width);
            e.Graphics.DrawImage(bmp, bounds.Left, bounds.Top, bounds.Width, factor * bounds.Width);
        }
    }
}
