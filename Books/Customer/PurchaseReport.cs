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
using B00ks.Customer.Classes;
using Microsoft.Reporting.WinForms;

namespace B00ks.Customer
{
    public partial class PurchaseReport : Form
    {
        List<Reciept> _list;
        string _total, _cash, _change, _date, _fName, _lName, _phNum;
        public PurchaseReport(List<Reciept> dataSource, string total, string cash, string change, string date, string fname, string lname, string phNum)
        {
            InitializeComponent();

            _list = dataSource;
            _total = total;
            _cash = cash;
            _change = change;
            _date = date;
            _fName = fname;
            _lName = lname;
            _phNum = phNum;
        }

        private void PurchaseReport_Load(object sender, EventArgs e)
        {
            ReportDataSource source = new ReportDataSource("DataSet1", _list);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(source);

            Microsoft.Reporting.WinForms.ReportParameter[] para = new Microsoft.Reporting.WinForms.ReportParameter[]
            {
                new Microsoft.Reporting.WinForms.ReportParameter("pTotal", _total),
                new Microsoft.Reporting.WinForms.ReportParameter("pChange", _change),
                new Microsoft.Reporting.WinForms.ReportParameter("pCash", _cash),
                new Microsoft.Reporting.WinForms.ReportParameter("pDate", _date),
                new Microsoft.Reporting.WinForms.ReportParameter("pFName", _fName),
                new Microsoft.Reporting.WinForms.ReportParameter("pLName", _lName),
                new Microsoft.Reporting.WinForms.ReportParameter("pPhoneNum", _phNum)
            };


            this.reportViewer1.LocalReport.SetParameters(para);

            using (StreamReader rdlcSR = new StreamReader(@"C:\Users\Asus\source\repos\B00ks\B00ks\bin\Debug\Customer\PurchaseReport1.rdlc"))
            {
                reportViewer1.LocalReport.LoadReportDefinition(rdlcSR);

                reportViewer1.LocalReport.Refresh();
            }
            //reportViewer1.LocalReport.ReportEmbeddedResource = "Customer.PurchaseReport1.rdlc";

            this.reportViewer1.RefreshReport();


            
        }
    }
}
