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
using B00ks.Admin.Classes;
using B00ks.Customer.Classes;

namespace B00ks.Customer
{
    public partial class Browsebook : Form
    {
        public Browsebook()
        {
            InitializeComponent();
        }

        BookData_CRUD b_crud = new BookData_CRUD();
        RentbookTemp_data rent_crud = new RentbookTemp_data();
        TempComCart tempc_crud = new TempComCart();
        Cart cart = new Cart();
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

        public void READ_Book()
        {
            dataGridViewdatabook.DataSource = null;
            b_crud.Read_BookData();
            dataGridViewdatabook.DataSource = b_crud.dt;
        }
        public void SEARCH_Book()
        {
            dataGridViewdatabook.DataSource = null;
            b_crud.Search_BookData(searchbox.Text);
            dataGridViewdatabook.DataSource = b_crud.dt;
        }

        public void INSERT_toRentTemp()
        {
            int stock = b_crud.get_Stock(isbn.Text);
            if (title.Text == "" || price.Text == "" || isbn.Text == "")
            {
                MessageBox.Show("Please Choose a book from the browse table", "Error");
            }
            else if (qty.Text == "")
            {
                MessageBox.Show("Please Insert a Quantity of the book that want to rent", "Error");
            }
            else if (Convert.ToInt32(qty.Text) > stock)
            {
                MessageBox.Show("Invalid, quantity is bigger than stock !", "Error");
            }
            else
            {
                //check if isbn exist or not in rent
                int num;
                if (rent_crud.Check_Item_IsExistInRent(isbn.Text))
                {
                    MessageBox.Show("You have Inserted this Book in your Rent, Please check your Rent Books !", "Error");
                }
                else
                {
                    rent_crud.Title = title.Text;
                    rent_crud.ISBN = (int)Convert.ToInt64(isbn.Text);
                    rent_crud.Qty = Convert.ToInt32(qty.Text);
                    rent_crud.From_Date = DateTime.Now.Date;
                    rent_crud.To_Date = DateTime.Now.Date.AddDays(1);

                    rent_crud.Insert_BookRent();

                    MessageBox.Show(title.Text + " has successfully inserted to your rent !", "Info");
                }
            }
        }
        public void INSERT_toCart()
        {

            int stock = b_crud.get_Stock(isbn.Text);
            if (title.Text == "" || price.Text == "" || isbn.Text == "")
            {
                MessageBox.Show("Please Choose a book from the browse table", "Error");
            }
            else if (qty.Text == "")
            {
                MessageBox.Show("Please Insert a Quantity of the book that want to buy", "Error");
            }
            else if(Convert.ToInt32(qty.Text) > stock)
            {
                MessageBox.Show("Invalid, quantity is bigger than stock !", "Error");
            }
            else
            {
                //check if isbn exist or not in cart
                int num;
                if (tempc_crud.Check_Item_IsExistInCart(isbn.Text))
                {
                    MessageBox.Show("You have Inserted this Book in your cart, Please check your Cart !", "Error");
                }
                else
                {
                    tempc_crud.Title = title.Text;
                    tempc_crud.ISBN = (int)Convert.ToInt64(isbn.Text);
                    tempc_crud.Qty = Convert.ToInt32(qty.Text);
                    tempc_crud.Total = Convert.ToDecimal(total.Text);
                    tempc_crud.Price = Convert.ToDecimal(price.Text);

                    tempc_crud.Insert_Cart();

                    MessageBox.Show(title.Text + " has successfully inserted to your cart !", "Info");
                }

            }
        }

        private void Browsebook_Load(object sender, EventArgs e)
        {
            READ_Book();
        }

        private void dataGridViewdatabook_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView sendgrd = (DataGridView)sender;

            try
            {
                if (dataGridViewdatabook.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    ids.Text = (dataGridViewdatabook.Rows[e.RowIndex].Cells[0].Value.ToString());
                    title.Text = (dataGridViewdatabook.Rows[e.RowIndex].Cells[1].Value.ToString());
                    pusb.Text = (dataGridViewdatabook.Rows[e.RowIndex].Cells[2].Value.ToString());
                    catg.Text = (dataGridViewdatabook.Rows[e.RowIndex].Cells[3].Value.ToString());
                    isbn.Text = (dataGridViewdatabook.Rows[e.RowIndex].Cells[5].Value.ToString());
                    price.Text = (dataGridViewdatabook.Rows[e.RowIndex].Cells[7].Value.ToString());
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void dataGridViewdatabook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView sendgrd = (DataGridView)sender;

            try
            {
                if (dataGridViewdatabook.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    ids.Text = (dataGridViewdatabook.Rows[e.RowIndex].Cells[0].Value.ToString());
                    title.Text = (dataGridViewdatabook.Rows[e.RowIndex].Cells[1].Value.ToString());
                    pusb.Text = (dataGridViewdatabook.Rows[e.RowIndex].Cells[2].Value.ToString());
                    catg.Text = (dataGridViewdatabook.Rows[e.RowIndex].Cells[3].Value.ToString());
                    isbn.Text = (dataGridViewdatabook.Rows[e.RowIndex].Cells[5].Value.ToString());
                    price.Text = (dataGridViewdatabook.Rows[e.RowIndex].Cells[7].Value.ToString());

                   price.Text = (decimal.Parse(price.Text)).ToString("N", CultureInfo.CreateSpecificCulture("id-ID"));
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void dataGridViewdatabook_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView sendgrd = (DataGridView)sender;

            try
            {
                if (dataGridViewdatabook.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    ids.Text = (dataGridViewdatabook.Rows[e.RowIndex].Cells[0].Value.ToString());
                    title.Text = (dataGridViewdatabook.Rows[e.RowIndex].Cells[1].Value.ToString());
                    pusb.Text = (dataGridViewdatabook.Rows[e.RowIndex].Cells[2].Value.ToString());
                    catg.Text = (dataGridViewdatabook.Rows[e.RowIndex].Cells[3].Value.ToString());
                    isbn.Text = (dataGridViewdatabook.Rows[e.RowIndex].Cells[5].Value.ToString());
                    price.Text = (dataGridViewdatabook.Rows[e.RowIndex].Cells[7].Value.ToString());
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void dataGridViewdatabook_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView sendgrd = (DataGridView)sender;

            try
            {
                if (dataGridViewdatabook.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    ids.Text = (dataGridViewdatabook.Rows[e.RowIndex].Cells[0].Value.ToString());
                    title.Text = (dataGridViewdatabook.Rows[e.RowIndex].Cells[1].Value.ToString());
                    pusb.Text = (dataGridViewdatabook.Rows[e.RowIndex].Cells[2].Value.ToString());
                    catg.Text = (dataGridViewdatabook.Rows[e.RowIndex].Cells[3].Value.ToString());
                    isbn.Text = (dataGridViewdatabook.Rows[e.RowIndex].Cells[5].Value.ToString());
                    price.Text = (dataGridViewdatabook.Rows[e.RowIndex].Cells[7].Value.ToString());
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void Ins_btn_Click(object sender, EventArgs e)
        {
            INSERT_toCart();
            ClearTextBoxes();
        }

        private void qty_TextChanged(object sender, EventArgs e)
        {
            if(qty.Text == "")
            {
                total.Text = "";
            }
            else
            {
                total.Text = ((Convert.ToDecimal(qty.Text) * Convert.ToDecimal(price.Text)).ToString("N", CultureInfo.CreateSpecificCulture("id-ID")));

            }
        }

        private void searchbox_TextChanged(object sender, EventArgs e)
        {
           if(searchbox.Text == "")
            {
                READ_Book();
            }
            else
            {
                SEARCH_Book();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            INSERT_toRentTemp();
            ClearTextBoxes();
        }
    }
}
