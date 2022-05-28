using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using B00ks.Admin.Classes;
using Microsoft.Reporting.WinForms;

namespace B00ks.Admin
{
    public partial class PrintIncome : Form
    {
        List<IncomeReport> _list;
        string _total, _pprintdate;
        public PrintIncome(List<IncomeReport> datasource, string total, string pprintdate)
        {
            InitializeComponent();

            _list = datasource;
            _total = total;
            _pprintdate = pprintdate;
        }

        private void PrintIncome_Load(object sender, EventArgs e)
        {
            ReportDataSource source1 = new ReportDataSource("DataSetIncome", _list);
            reportincome.LocalReport.DataSources.Clear();
            reportincome.LocalReport.DataSources.Add(source1);

            Microsoft.Reporting.WinForms.ReportParameter[] para1 = new Microsoft.Reporting.WinForms.ReportParameter[]
            {
                new Microsoft.Reporting.WinForms.ReportParameter("ptotal", _total),
                new Microsoft.Reporting.WinForms.ReportParameter("pprintdate", _pprintdate)
            };


            this.reportincome.LocalReport.SetParameters(para1);

            using (StreamReader rdlcSR = new StreamReader(@"C:\Users\Asus\source\repos\B00ks\B00ks\bin\Debug\Admin\IncomeReport.rdlc"))
            {
                reportincome.LocalReport.LoadReportDefinition(rdlcSR);

                reportincome.LocalReport.Refresh();
            }
            this.reportincome.RefreshReport();




            //ReportDataSource source = new ReportDataSource("DataSet1", _list);
            //reportViewer1.LocalReport.DataSources.Clear();
            //reportViewer1.LocalReport.DataSources.Add(source);

            //Microsoft.Reporting.WinForms.ReportParameter[] para = new Microsoft.Reporting.WinForms.ReportParameter[]
            //{
            //    new Microsoft.Reporting.WinForms.ReportParameter("pTotal", _total),
            //    new Microsoft.Reporting.WinForms.ReportParameter("pChange", _change),
            //    new Microsoft.Reporting.WinForms.ReportParameter("pCash", _cash),
            //    new Microsoft.Reporting.WinForms.ReportParameter("pDate", _date),
            //    new Microsoft.Reporting.WinForms.ReportParameter("pFName", _fName),
            //    new Microsoft.Reporting.WinForms.ReportParameter("pLName", _lName),
            //    new Microsoft.Reporting.WinForms.ReportParameter("pPhoneNum", _phNum)
            //};


            //this.reportViewer1.LocalReport.SetParameters(para);

            //using (StreamReader rdlcSR = new StreamReader(@"C:\Users\Asus\source\repos\B00ks\B00ks\bin\Debug\Customer\PurchaseReport1.rdlc"))
            //{
            //    reportViewer1.LocalReport.LoadReportDefinition(rdlcSR);

            //    reportViewer1.LocalReport.Refresh();
            //}
            ////reportViewer1.LocalReport.ReportEmbeddedResource = "Customer.PurchaseReport1.rdlc";

            //this.reportViewer1.RefreshReport();



        }
    }
}
