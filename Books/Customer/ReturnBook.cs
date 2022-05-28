using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Forms;
using B00ks.Customer.Classes;

namespace B00ks.Customer
{
    public partial class ReturnBook : Form
    {
        Rent_Book_Data rent_crud = new Rent_Book_Data();
        Order_Data o_crud = new Order_Data();

        public TimeSpan value;
        public int value1 = 0;
        public DateTime now = DateTime.Now.Date;

        public ReturnBook()
        {
            InitializeComponent();
        }

        public void READ_BookRent()
        {
            dataGridViewdreturnbook.DataSource = null;
            rent_crud.Read_Rent();
            dataGridViewdreturnbook.DataSource = rent_crud.dt;
        }

        public void RETURN_Book()
        {
            if(todate.Value < DateTime.Now.Date)
            {
                MessageBox.Show("You need to contact to admin for Late return Charge");
                retn_btn.Enabled = false;
            }
            else
            {
                rent_crud.ID = Convert.ToInt32(ids.Text);
                rent_crud.Return_Book();

                MessageBox.Show("Thankyou for returning the book on time, Have a nice day !");
            }
            
        }

        public bool Check_Order()
        {
            if (o_crud.Check_Order(fname.Text, lname.Text, isbn_rO.Text, title_cm.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
            


        }

        public void SEARCH_BookRent()
        {
            rent_crud.SEARCH_Rent(searchbox.Text);
            dataGridViewdreturnbook.DataSource = rent_crud.dt;
        }
        private void ReturnBook_Load(object sender, EventArgs e)
        {
            READ_BookRent();
            retn_btn.Enabled = true;
           
        }

        private void searchbox_TextChanged(object sender, EventArgs e)
        {
            if(searchbox.Text != "")
            {
                SEARCH_BookRent();
            }
            else
            {
                READ_BookRent();
            }
            
        }

        private void dataGridViewdreturnbook_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView sendgrd = (DataGridView)sender;

            try
            {
                if (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    ids.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[0].Value.ToString());
                    fname.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[1].Value.ToString());
                    lname.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[2].Value.ToString());
                    isbn_rO.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[5].Value.ToString());
                    title_cm.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[4].Value.ToString());
                    qty.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[6].Value.ToString());
                    fromdate.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[7].Value.ToString());
                    todate.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[8].Value.ToString());
                }

                DateTime test = todate.Value;

                if (todate.Value < DateTime.Now.Date)
                {
                    labelnote.Text = "Please reach B00ks admin for paying the Late Return Charge !";
                    value = now - test;
                    decimal value2 = Convert.ToDecimal(value.TotalDays);
                    value1 = Convert.ToInt32(value2 * 2000);

                    latereturn.Text = (value1).ToString("N", CultureInfo.CreateSpecificCulture("id-ID"));
                    retn_btn.Enabled = false;
                }
                else
                {
                    labelnote.Text = "";
                    latereturn.Text = "0";
                    retn_btn.Enabled = true;
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void dataGridViewdreturnbook_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView sendgrd = (DataGridView)sender;

            try
            {
                if (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    ids.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[0].Value.ToString());
                    fname.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[1].Value.ToString());
                    lname.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[2].Value.ToString());
                    isbn_rO.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[5].Value.ToString());
                    title_cm.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[4].Value.ToString());
                    qty.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[6].Value.ToString());
                    fromdate.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[7].Value.ToString());
                    todate.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[8].Value.ToString());
                }

                DateTime test = todate.Value;

                if (todate.Value < DateTime.Now.Date)
                {
                    labelnote.Text = "Please reach B00ks admin for paying the Late Return Charge !";
                    value = now - test;
                    decimal value2 = Convert.ToDecimal(value.TotalDays);
                    value1 = Convert.ToInt32(value2 * 2000);

                    latereturn.Text = (value1).ToString("N", CultureInfo.CreateSpecificCulture("id-ID"));
                    retn_btn.Enabled = false;
                }
                else
                {
                    labelnote.Text = "";
                    latereturn.Text = "0";
                    retn_btn.Enabled = true;
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void dataGridViewdreturnbook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView sendgrd = (DataGridView)sender;

            try
            {
                if (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    ids.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[0].Value.ToString());
                    fname.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[1].Value.ToString());
                    lname.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[2].Value.ToString());
                    isbn_rO.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[5].Value.ToString());
                    title_cm.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[4].Value.ToString());
                    qty.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[6].Value.ToString());
                    fromdate.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[7].Value.ToString());
                    todate.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[8].Value.ToString());
                }
                
                DateTime test = todate.Value;

                if (todate.Value < DateTime.Now.Date)
                {
                    labelnote.Text = "Please reach B00ks admin for paying the Late Return Charge !";
                    value = now - test;
                    decimal value2 = Convert.ToDecimal(value.TotalDays);
                    value1 = Convert.ToInt32(value2 * 2000);

                    latereturn.Text = (value1).ToString("N", CultureInfo.CreateSpecificCulture("id-ID"));

                    //latereturn.Text = Convert.ToString(value1);
                    retn_btn.Enabled = false;
                }
                else
                {
                    labelnote.Text = "";
                    latereturn.Text = "0";
                    retn_btn.Enabled = true;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void dataGridViewdreturnbook_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView sendgrd = (DataGridView)sender;

            try
            {
                if (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    ids.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[0].Value.ToString());
                    fname.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[1].Value.ToString());
                    lname.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[2].Value.ToString());
                    isbn_rO.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[5].Value.ToString());
                    title_cm.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[4].Value.ToString());
                    qty.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[6].Value.ToString());
                    fromdate.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[7].Value.ToString());
                    todate.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[8].Value.ToString());
                }

                DateTime test = todate.Value;

                if (todate.Value < DateTime.Now.Date)
                {
                    labelnote.Text = "Please reach B00ks admin for paying the Late Return Charge !";
                    value = now - test;
                    decimal value2 = Convert.ToDecimal(value.TotalDays);
                    value1 = Convert.ToInt32(value2 * 2000);

                    latereturn.Text = (value1).ToString("N", CultureInfo.CreateSpecificCulture("id-ID"));
                    retn_btn.Enabled = false;
                }
                else
                {
                    labelnote.Text = "";
                    latereturn.Text = "0";
                    retn_btn.Enabled = true;
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void latereturn_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void retn_btn_Click(object sender, EventArgs e)
        {
            if (Check_Order())
            {
                MessageBox.Show("You Haven't recieve the book!");
            }
            else
            {
                RETURN_Book();
                READ_BookRent();
            }
            
        }
    }
}
