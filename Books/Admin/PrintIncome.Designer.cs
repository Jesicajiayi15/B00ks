
namespace B00ks.Admin
{
    partial class PrintIncome
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
            this.reportincome = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportincome
            // 
            this.reportincome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportincome.LocalReport.ReportEmbeddedResource = "B00ks.Admin.IncomeReport.rdlc";
            this.reportincome.Location = new System.Drawing.Point(0, 0);
            this.reportincome.Name = "reportincome";
            this.reportincome.ServerReport.BearerToken = null;
            this.reportincome.Size = new System.Drawing.Size(803, 450);
            this.reportincome.TabIndex = 0;
            // 
            // PrintIncome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 450);
            this.Controls.Add(this.reportincome);
            this.Name = "PrintIncome";
            this.Text = "PrintIncome";
            this.Load += new System.EventHandler(this.PrintIncome_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportincome;
    }
}