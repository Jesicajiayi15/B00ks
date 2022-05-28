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

namespace B00ks.Customer
{
    public partial class RentBook : Form
    {
        public RentBook()
        {
            InitializeComponent();
        }

        RentbookTemp_data r_crud = new RentbookTemp_data();
        Order_Data o_crud = new Order_Data();
        BookData_CRUD b_crud = new BookData_CRUD();
        Rent_Book_Data rent_crud = new Rent_Book_Data();

        public void READ_RentBook()
        {
            dataGridViewdrentbook.DataSource = null;
            r_crud.Read_Rent();
            dataGridViewdrentbook.DataSource = r_crud.dt;
        }
        public void SEARCH_RentBook_Temp()
        {
            r_crud.Search_BookRentTemp(searchbox.Text);
            dataGridViewdrentbook.DataSource = r_crud.dt;
        }
        public void UPDATE_Stock()
        {
            foreach (DataGridViewRow dt in dataGridViewdrentbook.Rows)
            {
                b_crud.Qty = Convert.ToInt32(dt.Cells[3].Value);
                b_crud.ISBN = (int)Convert.ToInt64(dt.Cells[2].Value);
                b_crud.Update_Stock_Books();
            }
        }
        public void INSERT_BookRentOrder()
        {
            foreach (DataGridViewRow dt in dataGridViewdrentbook.Rows)
            {
                o_crud.Title = dt.Cells[1].Value.ToString();
                o_crud.ISBN = (int)Convert.ToInt32(dt.Cells[2].Value);
                o_crud.Qty = Convert.ToInt32(dt.Cells[3].Value);
                o_crud.Total = Convert.ToDecimal(0);
                o_crud.Cust_First_Name = fname.Text;
                o_crud.Cust_Last_Name = lname.Text;
                o_crud.Phone_Num = phone.Text;
                o_crud.Type = "Customer Book Rent";

                o_crud.Insert_Order();

            }
        }

        public void INSERT_BookRentOff()
        {
            foreach (DataGridViewRow dt in dataGridViewdrentbook.Rows)
            {
                rent_crud.Title = dt.Cells[1].Value.ToString();
                rent_crud.ISBN = (int)Convert.ToInt32(dt.Cells[2].Value);
                rent_crud.Qty = Convert.ToInt32(dt.Cells[3].Value);
                rent_crud.First_Name = fname.Text;
                rent_crud.Last_Name = lname.Text;
                rent_crud.Phone_Num = phone.Text;
                rent_crud.From_Date = Convert.ToDateTime(dt.Cells[4].Value);
                rent_crud.To_Date = Convert.ToDateTime(dt.Cells[5].Value);

                rent_crud.Insert_BookRent();

            }
        }
        public void CANCEL_Aitem_Rent()
        {

            if (MessageBox.Show("Are you sure to Cancel this book Rent", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if(ids.Text == "")
                {
                    MessageBox.Show("Please choose the Book to Cancel");
                }
                else
                {
                    r_crud.ID = Convert.ToInt32(ids.Text);
                    r_crud.Cancel_Aitem_Rent();

                    MessageBox.Show("The Book Rent has successfully Cancelled !", "Info");
                }
                
            }
        }

        public void CANCEL_ALL_Rent()
        {
            if (MessageBox.Show("Are you sure to Cancel All the book Rent", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //r_crud.ID = Convert.ToInt32(ids.Text);
                r_crud.Remove_or_CancelAll_Rent_Temp();

                MessageBox.Show("All Book Rent has successfully Cancelled !", "Info");
            }
        }

        public void REMOVE_ALL_Rent_Temp()
        {
            r_crud.Remove_or_CancelAll_Rent_Temp();
        }
        
        public void PrintReciept()
        {
            foreach(DataGridViewRow dt in dataGridViewdrentbook.Rows)
            {
                RentReciept_Data tempc = new RentReciept_Data()
                {
                    //ID = Convert.ToInt32(dataGridViewcart.Rows[i].Cells[0].Value.ToString()),
                    Title = dt.Cells[1].Value.ToString(),
                    ISBN = (int)Convert.ToInt32(dt.Cells[2].Value),
                    Qty = Convert.ToInt32(dt.Cells[3].Value),
                    From_Date = Convert.ToDateTime(dt.Cells[4].Value),
                    To_Date = Convert.ToDateTime(dt.Cells[5].Value)
                };
                rentRecieptDataBindingSource.Add(tempc);
                rentRecieptDataBindingSource.MoveLast();
            }

            using (PrintRentReport prec = new PrintRentReport(rentRecieptDataBindingSource.DataSource as List<RentReciept_Data>,
                    string.Format("{0}", fname.Text),
                    string.Format("{0}", lname.Text),
                    string.Format("{0}", phone.Text),
                    DateTime.Now.ToString("dd/MM/yyyy")
                    ))
            {
                prec.ShowDialog();
            }
        }
        public void UPDATE_RentBook()
        {
            if (fname.Text == "")
            {
                MessageBox.Show("Please insert your first name", "Error");
            }
            else if (lname.Text == "")
            {
                MessageBox.Show("Please insert your last name", "Error");
            }
            else
            {
                //r_crud.First_Name = fname.Text;
                //r_crud.Last_Name = lname.Text;
                
                foreach(DataGridViewRow dt in dataGridViewdrentbook.Rows)
                {
                    r_crud.First_Name = fname.Text;
                    r_crud.Last_Name = lname.Text;
                    r_crud.ID = Convert.ToInt32(dt.Cells[0].Value.ToString());
                    r_crud.UPDATE_BookRent();
                }

                MessageBox.Show("Thankyou for Renting Book from B00ks Library!", "Info");
                PrintReciept();
                INSERT_BookRentOff();
                INSERT_BookRentOrder();
                UPDATE_Stock();

                REMOVE_ALL_Rent_Temp();
            }
        }

        private void RentBook_Load(object sender, EventArgs e)
        {
            //todate.Value = fromdate.Value.AddMinutes(1);
            fname.Enabled = true;
            lname.Enabled = true;

            READ_RentBook();


            rentRecieptDataBindingSource.DataSource = new List<RentReciept_Data>();
        }
        private void rnt_box_Click(object sender, EventArgs e)
        {
            UPDATE_RentBook();
            
            
            READ_RentBook();
        }

        private void dataGridViewdrentbook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView sendgrd = (DataGridView)sender;

            try
            {
                if (dataGridViewdrentbook.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    ids.Text = (dataGridViewdrentbook.Rows[e.RowIndex].Cells[0].Value.ToString());
                    fromdate.Text = (dataGridViewdrentbook.Rows[e.RowIndex].Cells[4].Value.ToString());
                    todate.Text = (dataGridViewdrentbook.Rows[e.RowIndex].Cells[5].Value.ToString());
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void dataGridViewdrentbook_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView sendgrd = (DataGridView)sender;

            try
            {
                if (dataGridViewdrentbook.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    ids.Text = (dataGridViewdrentbook.Rows[e.RowIndex].Cells[0].Value.ToString());
                    fromdate.Text = (dataGridViewdrentbook.Rows[e.RowIndex].Cells[4].Value.ToString());
                    todate.Text = (dataGridViewdrentbook.Rows[e.RowIndex].Cells[5].Value.ToString());
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void dataGridViewdrentbook_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView sendgrd = (DataGridView)sender;

            try
            {
                if (dataGridViewdrentbook.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    ids.Text = (dataGridViewdrentbook.Rows[e.RowIndex].Cells[0].Value.ToString());
                    fromdate.Text = (dataGridViewdrentbook.Rows[e.RowIndex].Cells[4].Value.ToString());
                    todate.Text = (dataGridViewdrentbook.Rows[e.RowIndex].Cells[5].Value.ToString());
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void dataGridViewdrentbook_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView sendgrd = (DataGridView)sender;

            try
            {
                if (dataGridViewdrentbook.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    ids.Text = (dataGridViewdrentbook.Rows[e.RowIndex].Cells[0].Value.ToString());
                    fromdate.Text = (dataGridViewdrentbook.Rows[e.RowIndex].Cells[4].Value.ToString());
                    todate.Text = (dataGridViewdrentbook.Rows[e.RowIndex].Cells[5].Value.ToString());
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void canclall_btn_Click(object sender, EventArgs e)
        {
            CANCEL_ALL_Rent();
            READ_RentBook();
        }

        private void cncl_btn_Click(object sender, EventArgs e)
        {
            CANCEL_Aitem_Rent();
            READ_RentBook();
        }

        private void searchbox_TextChanged(object sender, EventArgs e)
        {
            SEARCH_RentBook_Temp();
        }
    }
}
