using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using B00ks.Admin.Classes;
using System.Configuration;
using System.Globalization;
using System.Data.SqlClient;

namespace B00ks.Admin
{
    public partial class Income_page : Form
    {
        SqlConnection conn = new SqlConnection(Connection.Config());
        public Income_page()
        {
            InitializeComponent();
        }

        Income inc = new Income();

        public void READ_income()
        {
            dataGridViewincome.DataSource = null;
            inc.Read_Income();
            dataGridViewincome.DataSource = inc.dt;
        }

        public void SEARCH_income()
        {
            inc.Search_Income(searchbox.Text);
            dataGridViewincome.DataSource = inc.dt;
        }

        public void SEARCH_income_byType()
        {
            inc.Search_by_Combobx(Catg.Text);
            dataGridViewincome.DataSource = inc.dt;
        }
        public void SEARCH_income1()
        {
            inc.Search_Income1(searchbox.Text, Catg.Text);
            dataGridViewincome.DataSource = inc.dt;
        }

        public void SEARCH_ByDate()
        {
            inc.FromDate = Convert.ToDateTime(fromdate.Text);
            inc.ToDate = Convert.ToDateTime(todate.Text).Date;
            inc.SearchDate_Income(fromdate.Text,todate.Text);
            dataGridViewincome.DataSource = inc.dt;
        }

        public void CountTotal()
        {
            decimal totals = 0;
            foreach(DataGridViewRow dts in dataGridViewincome.Rows)
            {
                if (dts.Cells[9].Value.ToString() == "Customer Order" || dts.Cells[9].Value.ToString() == "Late Return")
                {
                    totals+= Convert.ToDecimal(dts.Cells[4].Value);
                }
                else
                {
                    totals-= Convert.ToDecimal(dts.Cells[4].Value);
                }
            }

            total_txt.Text = Convert.ToString(totals);
            total_txt.Text = (totals).ToString("N", CultureInfo.CreateSpecificCulture("id-ID"));
        }
        
        private void Income_page_Load(object sender, EventArgs e)
        {
            READ_income();
            CountTotal();
            incomeReportBindingSource.DataSource = new List<IncomeReport>();

            Catg.DisplayMember = "Customer Order";
            
        }

        private void searchbox_TextChanged(object sender, EventArgs e)
        {
            SEARCH_income();
            CountTotal();
        }

        private void pusb_SelectedValueChanged(object sender, EventArgs e)
        {
            
            
            if (searchbox.Text == "")
            {
                SEARCH_income_byType();
                CountTotal();
            }
            else
            {
                SEARCH_income1();
                CountTotal();
            }




        }
        private void todate_CloseUp(object sender, EventArgs e)
        {
            if (fromdate.Value > todate.Value)
            {
                MessageBox.Show("From Date most not bigger than To Date !");
            }
            else
            {
                //SqlCommand sda = new SqlCommand("SELECT * FROM Income_Data WHERE Date between '" + fromdate.Text + "' AND '" + todate.Text + "'", conn);
                //conn.Open();
                //DataTable dta = new DataTable();
                //dta.Load(sda.ExecuteReader());
                //dataGridViewincome.DataSource = dta;
                //conn.Close();

                SEARCH_ByDate();

                CountTotal();
            }
        }

        private void todate_ValueChanged(object sender, EventArgs e)
        {
           
        }

        //NEEED TO CHECK THE LOAD CODE (ADA COK, NGGAK AKU CEK DARI KMRN >:"")
        private void print_btn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dt in dataGridViewincome.Rows)
            {
                IncomeReport tempc = new IncomeReport()
                {
                    ID = Convert.ToInt32(dt.Cells[0].Value),
                    Title = dt.Cells[1].Value.ToString(),
                    ISBN = (int)Convert.ToInt32(dt.Cells[2].Value),
                    Qty = Convert.ToInt32(dt.Cells[3].Value),
                    Total = Convert.ToDecimal(dt.Cells[4].Value),
                    Cust_First_Name = dt.Cells[5].Value.ToString(),
                    Cust_Last_Name = dt.Cells[6].Value.ToString(),
                    Phone_Num = dt.Cells[7].Value.ToString(),
                    Date = Convert.ToDateTime(Convert.ToDateTime(dt.Cells[8].Value.ToString()).Date.ToString("dd/MM/yyyy")),
                    Type = dt.Cells[9].Value.ToString()
                };
                incomeReportBindingSource.Add(tempc);
                incomeReportBindingSource.MoveLast();
            }

            using (PrintIncome prec = new PrintIncome(incomeReportBindingSource.DataSource as List<IncomeReport>,
                string.Format("{0}", total_txt.Text),
                DateTime.Now.ToString("dd/MM/yyyy")
                ))
            {
                prec.ShowDialog();
            }
        }

        private void incomeReportBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void total_txt_TextChanged(object sender, EventArgs e)
        {
           
        }

    }
}
