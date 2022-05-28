
namespace B00ks.Customer
{
    partial class PrintRentReport
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
            this.reportViewerrent = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewerrent
            // 
            this.reportViewerrent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewerrent.LocalReport.ReportEmbeddedResource = "B00ks.Customer.RentReciept.rdlc";
            this.reportViewerrent.Location = new System.Drawing.Point(0, 0);
            this.reportViewerrent.Name = "reportViewerrent";
            this.reportViewerrent.ServerReport.BearerToken = null;
            this.reportViewerrent.Size = new System.Drawing.Size(800, 450);
            this.reportViewerrent.TabIndex = 0;
            // 
            // PrintRentReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewerrent);
            this.Name = "PrintRentReport";
            this.Text = "PrintRentReport";
            this.Load += new System.EventHandler(this.PrintRentReport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerrent;
    }
}