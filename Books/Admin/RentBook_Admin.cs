using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using B00ks.Customer.Classes;
using B00ks.Admin.Classes;
using System.Globalization;

namespace B00ks.Admin
{
    public partial class RentBook_Admin : Form
    {
        public RentBook_Admin()
        {
            InitializeComponent();
        }

        Rent_Book_Data rent_crud = new Rent_Book_Data();
        BookData_CRUD BK = new BookData_CRUD();
        Income inc_dta = new Income();
        Order_Data o_crud = new Order_Data();

        public TimeSpan value;
        public int value1 = 0;
        public DateTime now = DateTime.Now.Date.AddDays(4);

        private void ClearTextBoxes()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };

            func(Controls);
        }

        public void READ_BookRent()
        {
            dataGridViewdreturnbook.DataSource = null;
            rent_crud.Read_Rent();
            dataGridViewdreturnbook.DataSource = rent_crud.dt;
        }

        public void UPDATE_Stock_Return()
        {
            BK.Qty = Convert.ToInt32(qty.Text);
            BK.ISBN = (int)Convert.ToInt64(isbn_rO.Text);
            BK.Update_Stock_Books_Return();

        }

        
        public void REMOVE_Return_Book()
        {
            rent_crud.ID = Convert.ToInt32(ids.Text);
            rent_crud.Return_Book();

            MessageBox.Show("Updated successfully");
        }
        public void RETURN_Book()
        {
            if(MessageBox.Show("Customer have paid the late return charge?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                rent_crud.ID = Convert.ToInt32(ids.Text);
                rent_crud.Return_Book();

                MessageBox.Show("Updated successfully");
            }

        }

        public void INSERT_toOrder_Damaged()
        {
            //tempc_crud.Check_Item_IsExistInCart1();
            //MessageBox.Show(tempc_crud.CustomerCount.ToString());
            if (fname.Text == "")
            {
                MessageBox.Show("Please Choose First Name!", "Error");
            }
            else if (lname.Text == "")
            {
                MessageBox.Show("Please Choose Last Name!", "Error");
            }
            else if (isbn_rO.Text == "")
            {
                MessageBox.Show("Please Choose ISBN!", "Error");
            }
            else if (title_cm.Text == "")
            {
                MessageBox.Show("Please Choose Title!", "Error");
            }
            else if (qty.Text == "")
            {
                MessageBox.Show("Please Choose Qty!", "Error");
            }
            else
            {
                decimal price = BK.GetPrice_Book(isbn_rO.Text);
                price *= Convert.ToInt32(qty.Text);

                string phnum = rent_crud.GetPhoneNum(fname.Text, lname.Text, isbn_rO.Text, qty.Text);


                inc_dta.Title = title_cm.Text;
                inc_dta.ISBN = (int)Convert.ToInt32(isbn_rO.Text);
                inc_dta.Qty = Convert.ToInt32(qty.Text);
                inc_dta.Total = price;
                inc_dta.Cust_First_Name = fname.Text;
                inc_dta.Cust_Last_Name = lname.Text;
                inc_dta.Phone_Num = phnum;
                inc_dta.Date = DateTime.Now.Date;
                inc_dta.Type = "Damaged";

                inc_dta.Insert_BookData();



            }
        }

        public void INSERT_toOrder_Lost()
        {
            //tempc_crud.Check_Item_IsExistInCart1();
            //MessageBox.Show(tempc_crud.CustomerCount.ToString());
            if (fname.Text == "")
            {
                MessageBox.Show("Please Choose First Name!", "Error");
            }
            else if (lname.Text == "")
            {
                MessageBox.Show("Please Choose Last Name!", "Error");
            }
            else if (isbn_rO.Text == "")
            {
                MessageBox.Show("Please Choose ISBN!", "Error");
            }
            else if (title_cm.Text == "")
            {
                MessageBox.Show("Please Choose Title!", "Error");
            }
            else if (qty.Text == "")
            {
                MessageBox.Show("Please Choose Qty!", "Error");
            }
            else
            {
                decimal price = BK.GetPrice_Book(isbn_rO.Text);
                price *= Convert.ToInt32(qty.Text);

                string phnum = rent_crud.GetPhoneNum(fname.Text, lname.Text, isbn_rO.Text, qty.Text);


                inc_dta.Title = title_cm.Text;
                inc_dta.ISBN = (int)Convert.ToInt32(isbn_rO.Text);
                inc_dta.Qty = Convert.ToInt32(qty.Text);
                inc_dta.Total = price;
                inc_dta.Cust_First_Name = fname.Text;
                inc_dta.Cust_Last_Name = lname.Text;
                inc_dta.Date = DateTime.Now.Date;
                inc_dta.Phone_Num = phnum;
                inc_dta.Type = "Lost";

                inc_dta.Insert_BookData();



            }
        }

        public void INSERT_toOrder_Late_Return()
        {
            //tempc_crud.Check_Item_IsExistInCart1();
            //MessageBox.Show(tempc_crud.CustomerCount.ToString());
            if (fname.Text == "")
            {
                MessageBox.Show("Please Choose which Customer want to do return!", "Error");
            }
            else if (lname.Text == "")
            {
                MessageBox.Show("Please Choose Last Name!", "Error");
            }
            else if (isbn_rO.Text == "")
            {
                MessageBox.Show("Please Choose ISBN!", "Error");
            }
            else if (title_cm.Text == "")
            {
                MessageBox.Show("Please Choose Title!", "Error");
            }
            else if (qty.Text == "")
            {
                MessageBox.Show("Please Choose Qty!", "Error");
            }
            else
            {
                

                string phnum = rent_crud.GetPhoneNum(fname.Text, lname.Text, isbn_rO.Text, qty.Text);


                inc_dta.Title = title_cm.Text;
                inc_dta.ISBN = (int)Convert.ToInt32(isbn_rO.Text);
                inc_dta.Qty = Convert.ToInt32(qty.Text);
                inc_dta.Total = Convert.ToDecimal(latereturn.Text);
                inc_dta.Cust_First_Name = fname.Text;
                inc_dta.Cust_Last_Name = lname.Text;
                inc_dta.Date = DateTime.Now.Date;
                inc_dta.Phone_Num = phnum;
                inc_dta.Type = "Late Return";

                inc_dta.Insert_BookData();



            }
        }

        public bool Check_Order()
        {
            if (o_crud.Check_Order(fname.Text, lname.Text, isbn_rO.Text, title_cm.Text))
            {
                return true;
            }
            return false;

        }

        public void SEARCH_BookRent()
        {
            rent_crud.SEARCH_Rent(searchbox.Text);
            dataGridViewdreturnbook.DataSource = rent_crud.dt;
        }

        private void damg_lost_Click(object sender, EventArgs e)
        {
            if (Check_Order())
            {
                MessageBox.Show("You Haven't recieve the book!");
            }
            else
            {

                INSERT_toOrder_Damaged();
                REMOVE_Return_Book();
                READ_BookRent();
                ClearTextBoxes();
            }
        }


        private void RentBook_Admin_Load(object sender, EventArgs e)
        {
            READ_BookRent();
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
                    title_cm.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[4].Value.ToString());
                    isbn_rO.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[5].Value.ToString());
                    qty.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[6].Value.ToString());
                    fromdate.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[7].Value.ToString());
                    todate.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[8].Value.ToString());
                }

                DateTime test = todate.Value;

                if (todate.Value < DateTime.Now.Date.AddDays(2))
                {
                    value = now - test;
                    decimal value2 = Convert.ToDecimal(value.TotalDays);
                    value1 = Convert.ToInt32(value2 * 2000);

                    latereturn.Text = Convert.ToString(value1);
                }
                else
                {
                    latereturn.Text = "0";
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
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
                    title_cm.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[4].Value.ToString());
                    isbn_rO.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[5].Value.ToString());
                    qty.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[6].Value.ToString());
                    fromdate.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[7].Value.ToString());
                    todate.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[8].Value.ToString());
                }

                DateTime test = todate.Value;

                if (todate.Value < DateTime.Now.Date.AddDays(2))
                {
                    value = now - test;
                    decimal value2 = Convert.ToDecimal(value.TotalDays);
                    value1 = Convert.ToInt32(value2 * 2000);

                    latereturn.Text = Convert.ToString(value1);
                }
                else
                {
                    latereturn.Text = "0";
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
                    title_cm.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[4].Value.ToString());
                    isbn_rO.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[5].Value.ToString());
                    qty.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[6].Value.ToString());
                    fromdate.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[7].Value.ToString());
                    todate.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[8].Value.ToString());
                }

                DateTime test = todate.Value;

                if (todate.Value < DateTime.Now.Date.AddDays(2))
                {
                    value = now - test;
                    decimal value2 = Convert.ToDecimal(value.TotalDays);
                    value1 = Convert.ToInt32(value2 * 2000);

                    latereturn.Text = Convert.ToString(value1);
                }
                else
                {
                    latereturn.Text = "0";
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
                    title_cm.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[4].Value.ToString());
                    isbn_rO.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[5].Value.ToString());
                    qty.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[6].Value.ToString());
                    fromdate.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[7].Value.ToString());
                    todate.Text = (dataGridViewdreturnbook.Rows[e.RowIndex].Cells[8].Value.ToString());
                }

                DateTime test = todate.Value;

                if (todate.Value < DateTime.Now.Date.AddDays(4))
                {
                    value = now - test;
                    decimal value2 = Convert.ToDecimal(value.TotalDays);
                    value1 = Convert.ToInt32(value2 * 2000);

                    latereturn.Text = Convert.ToString(value1);
                }
                else
                {
                    latereturn.Text = "0";
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void retn_btn_Click(object sender, EventArgs e)
        {

            if (Check_Order())
            {
                MessageBox.Show("You Haven't recieve the book!");
            }
            else
            {
                INSERT_toOrder_Late_Return();
                RETURN_Book();
                UPDATE_Stock_Return();
                READ_BookRent();
                ClearTextBoxes();
            }
        }
           

        private void lost_btn_Click(object sender, EventArgs e)
        {
            if (Check_Order())
            {
                MessageBox.Show("You Haven't recieve the book!");
            }
            else
            {
                INSERT_toOrder_Lost();
                REMOVE_Return_Book();
                READ_BookRent();
                ClearTextBoxes();
            }
        }

        private void latereturn_TextChanged(object sender, EventArgs e)
        {
            //latereturn.Text = (decimal.Parse(latereturn.Text)).ToString("N", CultureInfo.CreateSpecificCulture("id-ID"));
        }
    }
}
