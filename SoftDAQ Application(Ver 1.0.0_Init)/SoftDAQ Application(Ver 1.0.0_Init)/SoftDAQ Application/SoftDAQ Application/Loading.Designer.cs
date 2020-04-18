namespace SoftDAQ_Application
{
    partial class Loading
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.prgBar1 = new System.Windows.Forms.ProgressBar();
            this.Load1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // prgBar1
            // 
            this.prgBar1.BackColor = System.Drawing.SystemColors.Control;
            this.prgBar1.Location = new System.Drawing.Point(8, 185);
            this.prgBar1.Name = "prgBar1";
            this.prgBar1.Size = new System.Drawing.Size(537, 15);
            this.prgBar1.Step = 1;
            this.prgBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.prgBar1.TabIndex = 0;
            this.prgBar1.Click += new System.EventHandler(this.prgBar1_Click);
            // 
            // Load1
            // 
            this.Load1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Load1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Load1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Load1.HideSelection = false;
            this.Load1.Location = new System.Drawing.Point(219, 165);
            this.Load1.Name = "Load1";
            this.Load1.Size = new System.Drawing.Size(113, 18);
            this.Load1.TabIndex = 2;
            this.Load1.TabStop = false;
            this.Load1.Text = "Loading... 0%";
            this.Load1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Load1.UseWaitCursor = true;
            this.Load1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Loading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SoftDAQ_Application.Properties.Resources.Logo7;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(553, 207);
            this.ControlBox = false;
            this.Controls.Add(this.Load1);
            this.Controls.Add(this.prgBar1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Loading";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loading Bar";
            this.Load += new System.EventHandler(this.Loading_Load);
            this.Click += new System.EventHandler(this.Loading_Click);
            this.MouseEnter += new System.EventHandler(this.Loading_MouseEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar prgBar1;
        private System.Windows.Forms.TextBox Load1;
    }
}