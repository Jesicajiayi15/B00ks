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
using System.Threading;
using System.Globalization;

namespace B00ks.Customer
{
    public partial class Cart : Form
    {
        public Cart()
        {
            InitializeComponent();
        }

        decimal rupiah;
        decimal rupiah1;
        TempComCart tempc_crud = new TempComCart();
        Order_Data inc_dta = new Order_Data();
        BookData_CRUD b_crud = new BookData_CRUD();

       

        public int Stotal;


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

        public void READ_TempCart()
        {
            dataGridViewcart.DataSource = null;
            tempc_crud.Read_Cart();
            dataGridViewcart.DataSource = tempc_crud.dt;
        }

        public void SEARCH_TempCart()
        {
            dataGridViewcart.DataSource = null;
            tempc_crud.Search_Item(searchbox.Text);
            dataGridViewcart.DataSource = tempc_crud.dt;
        }

        public void SumTotal()
        {
            int sum = 0;
            try
            {
                for (int i = 0; i < dataGridViewcart.Rows.Count; i++)
                {
                    sum += Convert.ToInt32(dataGridViewcart.Rows[i].Cells[5].Value);
                }

                total.Text = (sum).ToString("N", CultureInfo.CreateSpecificCulture("id-ID"));

            }
            catch
            {

            }
        }

        public void CANCEL_Item()
        {
            if (MessageBox.Show("Are you sure to Cancel this book purchases?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                tempc_crud.ID = Convert.ToInt32(ids.Text);

                tempc_crud.Cancel_A_Item();

                MessageBox.Show("The Book has successfully Cancelled !", "Info");
            }
        }

        public void CANCEL_Cart()
        {
            if (MessageBox.Show("Are you sure to Cancel ALL of the book purchases?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                tempc_crud.CancelAll_Item_or_Clean_Cart();

                MessageBox.Show("All books have successfully Cancelled !", "Info");
            }
        }
        public void CLEAN_Cart()
        {
            tempc_crud.CancelAll_Item_or_Clean_Cart();
        }

        public void INSERT_toOrder()
        {
            //tempc_crud.Check_Item_IsExistInCart1();
            //MessageBox.Show(tempc_crud.CustomerCount.ToString());
            if (f_name.Text == "")
            {
                MessageBox.Show("Please Insert your First Name!", "Error");
            }
            else if (l_name.Text == "")
            {
                MessageBox.Show("Please Insert your Last Name!", "Error");
            }
            else if (phone.Text == "")
            {
                MessageBox.Show("Please Insert your Phone Number!", "Error");
            }
            else if (phone.Text.Length < 9)
            {
                MessageBox.Show("Please Insert your Phone Number at Least 9 digits!", "Error");
            }
            else if (cash_txt.Text == "")
            {
                MessageBox.Show("Please Insert your Payment!", "Error");
            }
            else if (Convert.ToDecimal(total.Text) > Convert.ToDecimal(cash_txt.Text))
            {
                MessageBox.Show("Insuffient Payment, the Cash should be equal or bigger than the Total !", "Error");
            }
            else
            {
                foreach (DataGridViewRow dt in dataGridViewcart.Rows)
                {
                    inc_dta.Title = dt.Cells[1].Value.ToString();
                    inc_dta.ISBN = (int)Convert.ToInt32(dt.Cells[2].Value);
                    inc_dta.Qty = Convert.ToInt32(dt.Cells[4].Value);
                    inc_dta.Total = Convert.ToDecimal(dt.Cells[5].Value);
                    inc_dta.Cust_First_Name = f_name.Text;
                    inc_dta.Cust_Last_Name = l_name.Text;
                    inc_dta.Phone_Num = phone.Text;
                    inc_dta.Type = "Customer Order";

                    inc_dta.Insert_Order();

                }
                
                


                MessageBox.Show("Thank you for purchasing, have a wonderful day !", "Successfully Purchase");

                UPDATE_Stock();

                //pass data to reportviewer

                foreach (DataGridViewRow dt in dataGridViewcart.Rows)
                {
                    Reciept tempc = new Reciept()
                    {
                        //ID = Convert.ToInt32(dataGridViewcart.Rows[i].Cells[0].Value.ToString()),
                        Title = dt.Cells[1].Value.ToString(),
                        Price = Convert.ToDecimal(dt.Cells[3].Value),
                        ISBN = (int)Convert.ToInt32(dt.Cells[2].Value),
                        Qty = Convert.ToInt32(dt.Cells[4].Value),
                        Total = Convert.ToDecimal(dt.Cells[5].Value)
                    };
                    recieptBindingSource.Add(tempc);
                    recieptBindingSource.MoveLast();
                }

                using (PurchaseReport prec = new PurchaseReport(recieptBindingSource.DataSource as List<Reciept>,
                    string.Format("{0}", total.Text),
                    string.Format("{0}", cash_txt.Text),
                    string.Format("{0}", change_txt.Text),
                    DateTime.Now.ToString("dd/MM/yyyy"),
                    string.Format("{0}", f_name.Text),
                    string.Format("{0}", l_name.Text),
                    string.Format("{0}", phone.Text)
                    ))
                {
                    prec.ShowDialog();
                }


                ClearTextBoxes();
                CLEAN_Cart();
            }
        }

        public void UPDATE_Stock()
        {
            foreach (DataGridViewRow dt in dataGridViewcart.Rows)
            {
                b_crud.Qty = Convert.ToInt32(dt.Cells[4].Value);
                b_crud.ISBN = (int)Convert.ToInt64(dt.Cells[2].Value);
                b_crud.Update_Stock_Books();
            }   
        }

        private void Cart_Load(object sender, EventArgs e)
        {
            READ_TempCart();
            SumTotal();


            recieptBindingSource.DataSource = new List<Reciept>();
        }

        private void dataGridViewdatabook_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            
        }

        private void dataGridViewcart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView sendgrd = (DataGridView)sender;

            try
            {
                if (dataGridViewcart.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    ids.Text = (dataGridViewcart.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void dataGridViewcart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView sendgrd = (DataGridView)sender;

            try
            {
                if (dataGridViewcart.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    ids.Text = (dataGridViewcart.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void dataGridViewcart_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView sendgrd = (DataGridView)sender;

            try
            {
                if (dataGridViewcart.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    ids.Text = (dataGridViewcart.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void dataGridViewcart_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView sendgrd = (DataGridView)sender;

            try
            {
                if (dataGridViewcart.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    ids.Text = (dataGridViewcart.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void purchs_btn_Click(object sender, EventArgs e)
        {

            INSERT_toOrder();
            READ_TempCart();

            
        }

        private void cncl_btn_Click(object sender, EventArgs e)
        {
            CANCEL_Item();
            READ_TempCart();
            ClearTextBoxes();
        }

        private void canclall_btn_Click(object sender, EventArgs e)
        {
            CANCEL_Cart();
            READ_TempCart();
            ClearTextBoxes();
        }

        private void searchbox_TextChanged(object sender, EventArgs e)
        {
            SEARCH_TempCart();
        }

        private void cash_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8;
            if (e.KeyChar == (char)13)

            {

                cash_txt.Text = string.Format("{0:n0}", double.Parse(cash_txt.Text));

            }

        }

        private void cash_txt_TextChanged(object sender, EventArgs e)
        {
            //purchs_btn.Enabled = true;
            if (total.Text == "")
            {
                change_txt.Text = "";

            }
            //else if (string.IsNullOrWhiteSpace(cash_txt.Text))
            //{
            //    rupiah = 0;
            //}
           ////else if(Convert.ToDecimal(total.Text) > Convert.ToDecimal(cash_txt.Text))
            ////{
            ////    change_txt.Text = "";
            ////    purchs_btn.Enabled = false;
            ////} 
            //else
            //{
            //   // change_txt.Text = Convert.ToString(Convert.ToDecimal(cash_txt.Text) - Convert.ToDecimal(total.Text));
            //    rupiah = Convert.ToDecimal(cash_txt.Text);
            //    //rupiah1 = decimal.Parse(change_txt.Text);


            //    purchs_btn.Enabled = true;

            //}

            //cash_txt.Text = rupiah.ToString("C", CultureInfo.CreateSpecificCulture("id-ID"));


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textBox1.Text))
            {
                rupiah = 0;
            }
            else
            {
                cash_txt.Text = (Convert.ToDecimal(cash_txt.Text)).ToString("N", CultureInfo.CreateSpecificCulture("id-ID"));

            }

            //cash_txt.Text = rupiah.ToString("N", CultureInfo.CreateSpecificCulture("id-ID"));
        }

        private void cash_txt_Leave(object sender, EventArgs e)
        {
            cash_txt.Text = (decimal.Parse(cash_txt.Text)).ToString("N", CultureInfo.CreateSpecificCulture("id-ID"));

            if(Convert.ToDecimal(cash_txt.Text) < Convert.ToDecimal(total.Text))
            {
                change_txt.Text = "0.00";
            }
            else
            {
                change_txt.Text = (Convert.ToDecimal(cash_txt.Text) - Convert.ToDecimal(total.Text)).ToString("N", CultureInfo.CreateSpecificCulture("id"));
            }
        }
    }
}
