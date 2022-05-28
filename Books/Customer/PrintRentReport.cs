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
    public partial class PrintRentReport : Form
    {
        List<RentReciept_Data> _list;
        string _fName, _lName, _phNum, _pdate;
        public PrintRentReport(List<RentReciept_Data> datasource, string fname, string lname, string pnum, string pdate)
        {
            InitializeComponent();
            _list = datasource;
            _fName = fname;
            _lName = lname;
            _phNum = pnum;
            _pdate = pdate;
        }

        private void PrintRentReport_Load(object sender, EventArgs e)
        {
            ReportDataSource source = new ReportDataSource("DataSet1", _list);
            reportViewerrent.LocalReport.DataSources.Clear();
            reportViewerrent.LocalReport.DataSources.Add(source);

            Microsoft.Reporting.WinForms.ReportParameter[] para = new Microsoft.Reporting.WinForms.ReportParameter[]
            {
                new Microsoft.Reporting.WinForms.ReportParameter("pfname", _fName),
                new Microsoft.Reporting.WinForms.ReportParameter("plname", _lName),
                new Microsoft.Reporting.WinForms.ReportParameter("pdate", _pdate),
                new Microsoft.Reporting.WinForms.ReportParameter("pphone", _phNum)
            };


            this.reportViewerrent.LocalReport.SetParameters(para);

            using (StreamReader rdlcSR = new StreamReader(@"C:\Users\Asus\source\repos\B00ks\B00ks\bin\Debug\Customer\RentReciept.rdlc"))
            {
                reportViewerrent.LocalReport.LoadReportDefinition(rdlcSR);

                reportViewerrent.LocalReport.Refresh();
            }
            
            this.reportViewerrent.RefreshReport();
        }
    }
}
