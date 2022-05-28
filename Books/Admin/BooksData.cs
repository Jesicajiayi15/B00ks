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
using System.Globalization;

namespace B00ks.Admin
{
    public partial class BooksData : Form
    {
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


        BookData_CRUD b_crud = new BookData_CRUD();
        CategoriesLanguages catg_crud = new CategoriesLanguages();
        Publishers pub_crud = new Publishers();
        DamageLostBooks DLB = new DamageLostBooks();

        public BooksData()
        {
            InitializeComponent();
        }
        public void Category_READ()
        {
            //Category
            catg.DataSource = null;
            catg_crud.CategoryLang_Read();
            catg.DataSource = catg_crud.dt;
            catg.DisplayMember = "catgLang";

        }

        public void Publisher_READ()
        {
            //Publisher
            pusb.DataSource = null;
            pub_crud.Publisher_Read();
            pusb.DataSource = pub_crud.dt;
            pusb.DisplayMember = "FullName";
        }

        public void BookData_INSERT()
        {
            if (title.Text =="")
            {
                MessageBox.Show("Please Insert the Title of the book", "Error");
            }
            else if (price.Text == "")
            {
                MessageBox.Show("Please Insert the price of the book", "Error");
            }
            else if (pages.Text == "")
            {
                MessageBox.Show("Please Insert the total pages of the book", "Error");
            }
            else if (isbn.Text == "")
            {
                MessageBox.Show("Please Insert the ISBN of the book", "Error");
            }
            else if (stock.Text == "")
            {
                MessageBox.Show("Please Insert the stock of the book or else insert 0", "Error");
            }
            else
            {
                //check if isbn exist or not
                for (int items = 0; items < dataGridViewdatabook.Rows.Count; items++)
                {
                    if (isbn.Text == dataGridViewdatabook.Rows[items].Cells["ISBN"].Value.ToString())
                    {
                        MessageBox.Show("This Title with this publisher already exist !", "WARNING");
                        ClearTextBoxes();
                        return;
                    }
                }

                b_crud.Title = title.Text;
                b_crud.Category = catg.Text;
                b_crud.Publisher = pusb.Text;
                b_crud.Price = Convert.ToDecimal(price.Text);
                b_crud.Pages = Convert.ToInt32(pages.Text);
                b_crud.ISBN = (int)Convert.ToInt32(isbn.Text);
                b_crud.Stock = Convert.ToInt32(stock.Text);

                b_crud.Insert_BookData();

                MessageBox.Show(title.Text + " has successfully inserted !", "Info");
            }
           
        }

        public void UPDATE_Stock()
        {
            b_crud.Qty = Convert.ToInt32(1);
            b_crud.ISBN = (int)Convert.ToInt64(isbn.Text);
            b_crud.Update_Stock_Books();

        }

        public void INSERT_Damage()
        {

            if (title.Text == "")
            {
                MessageBox.Show("Please choose the Title of the damaged/lost book", "Error");
            }
            else if (price.Text == "")
            {
                MessageBox.Show("Please choose the price of the damaged/lost book", "Error");
            }
            else if (isbn.Text == "")
            {
                MessageBox.Show("Please choose the ISBN of the damaged/lost book", "Error");
            }
            else if (stock.Text == "0")
            {
                MessageBox.Show("You cannot insert a zero stock book to Damage/Lost Book !", "Error");
            }
            else
            {

                DLB.Title = title.Text;
                DLB.ISBN = (int)Convert.ToInt64(isbn.Text);
                DLB.Qty = Convert.ToInt32(1);
                DLB.Price = Convert.ToDecimal(price.Text);
                DLB.Reason = "Damaged";
                DLB.Total = Convert.ToDecimal(price.Text);
                DLB.Paid = "No";

                DLB.DL_Insert();
                UPDATE_Stock();
                MessageBox.Show(title.Text + " has successfully inserted to Damaged/Lost Books !", "Info");

            }
        }

        public void INSERT_Lost()
        {
            if (title.Text == "")
            {
                MessageBox.Show("Please choose the Title of the damaged/lost book", "Error");
            }
            else if (price.Text == "")
            {
                MessageBox.Show("Please choose the price of the damaged/lost book", "Error");
            }
            else if (isbn.Text == "")
            {
                MessageBox.Show("Please choose the ISBN of the damaged/lost book", "Error");
            }
            else if(stock.Text == "0")
            {
                MessageBox.Show("You cannot insert a zero stock book to Damage/Lost Book !", "Error");
            }
            else
            {

                DLB.Title = title.Text;
                DLB.ISBN = (int)Convert.ToInt64(isbn.Text);
                DLB.Qty = Convert.ToInt32(1);
                DLB.Price = Convert.ToDecimal(price.Text);
                DLB.Reason = "Lost";
                DLB.Total = Convert.ToDecimal(price.Text);
                DLB.Paid = "No";

                DLB.DL_Insert();
                UPDATE_Stock();
                MessageBox.Show(title.Text + " has successfully inserted to Damaged/Lost Books !", "Info");

            }
        }
        public void BookData_UPDATE()
        {

            if (title.Text == "")
            {
                MessageBox.Show("Please Insert the Title of the book", "Error");
            }
            else if (price.Text == "")
            {
                MessageBox.Show("Please Insert the price of the book", "Error");
            }
            else if (pages.Text == "")
            {
                MessageBox.Show("Please Insert the total pages of the book", "Error");
            }
            else if (isbn.Text == "")
            {
                MessageBox.Show("Please Insert the ISBN of the book", "Error");
            }
            else if (stock.Text == "")
            {
                MessageBox.Show("Please Insert the stock of the book or else insert 0", "Error");
            }
            else
            {
                b_crud.ID = Convert.ToInt32(ids.Text);
                b_crud.Title = title.Text;
                b_crud.Category = catg.Text;
                b_crud.Publisher = pusb.Text;
                b_crud.Price = Convert.ToDecimal(price.Text);
                b_crud.Pages = Convert.ToInt32(pages.Text);
                b_crud.ISBN = (int)Convert.ToInt64(isbn.Text);
                b_crud.Stock = Convert.ToInt32(stock.Text);

                b_crud.Update_BookData();

                MessageBox.Show(title.Text + " has successfully updated !", "Info");
            }

        }

        public void BookData_DELETE()
        {
            if(MessageBox.Show("Are you sure to delete this book?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                b_crud.ID = Convert.ToInt32(ids.Text);
                b_crud.ISBN = (int)Convert.ToInt64(isbn.Text);

                b_crud.Delete_BookData();

                MessageBox.Show(title.Text + " has successfully deleted !", "Info");
            }
        }

        public void BookData_READ()
        {
            dataGridViewdatabook.DataSource = null;
            b_crud.READ_ADMIN();
            dataGridViewdatabook.DataSource = b_crud.dt;
        }
        private void BooksData_Load(object sender, EventArgs e)
        {
            Category_READ();
            Publisher_READ();
            BookData_READ();

            

            catg.Font = new Font(catg.Font, FontStyle.Regular);
            pusb.Font = new Font(pusb.Font, FontStyle.Regular);
        }

        public void BookData_SEARCH()
        {
            b_crud.Search_BookData_Admin(searchbox.Text);
            dataGridViewdatabook.DataSource = b_crud.dt;
        }

        //CRUD BOOKS_DATA
        private void Insert_Click_1(object sender, EventArgs e)
        {
            BookData_INSERT();
            BookData_READ();
            ClearTextBoxes();
        }
        private void upd_btn_Click(object sender, EventArgs e)
        {
            BookData_UPDATE();
            BookData_READ();
            ClearTextBoxes();
        }

        private void del_btn_Click(object sender, EventArgs e)
        {
            BookData_DELETE();
            BookData_READ();
            ClearTextBoxes();
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
                    pages.Text = (dataGridViewdatabook.Rows[e.RowIndex].Cells[4].Value.ToString());
                    isbn.Text = (dataGridViewdatabook.Rows[e.RowIndex].Cells[5].Value.ToString());
                    stock.Text = (dataGridViewdatabook.Rows[e.RowIndex].Cells[6].Value.ToString());
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
                    pages.Text = (dataGridViewdatabook.Rows[e.RowIndex].Cells[4].Value.ToString());
                    isbn.Text = (dataGridViewdatabook.Rows[e.RowIndex].Cells[5].Value.ToString());
                    stock.Text = (dataGridViewdatabook.Rows[e.RowIndex].Cells[6].Value.ToString());
                    price.Text = (dataGridViewdatabook.Rows[e.RowIndex].Cells[7].Value.ToString());
                    price.Text = (decimal.Parse(price.Text)).ToString("N", CultureInfo.CreateSpecificCulture("id-ID"));
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
                    pages.Text = (dataGridViewdatabook.Rows[e.RowIndex].Cells[4].Value.ToString());
                    isbn.Text = (dataGridViewdatabook.Rows[e.RowIndex].Cells[5].Value.ToString());
                    stock.Text = (dataGridViewdatabook.Rows[e.RowIndex].Cells[6].Value.ToString());
                    price.Text = (dataGridViewdatabook.Rows[e.RowIndex].Cells[7].Value.ToString());


                    price.Text = (decimal.Parse(price.Text)).ToString("N", CultureInfo.CreateSpecificCulture("id-ID"));
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
                    pages.Text = (dataGridViewdatabook.Rows[e.RowIndex].Cells[4].Value.ToString());
                    isbn.Text = (dataGridViewdatabook.Rows[e.RowIndex].Cells[5].Value.ToString());
                    stock.Text = (dataGridViewdatabook.Rows[e.RowIndex].Cells[6].Value.ToString());
                    price.Text = (dataGridViewdatabook.Rows[e.RowIndex].Cells[7].Value.ToString());

                    price.Text = (decimal.Parse(price.Text)).ToString("N", CultureInfo.CreateSpecificCulture("id-ID"));
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        private void Insert_Click(object sender, EventArgs e)
        {

        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void searchbox_TextChanged(object sender, EventArgs e)
        {
            BookData_SEARCH();
        }

        private void searchbox_TextAlignChanged(object sender, EventArgs e)
        {

        }

        private void damg_lost_Click(object sender, EventArgs e)
        {
            INSERT_Damage();
            BookData_READ();
        }

        private void lost_btn_Click(object sender, EventArgs e)
        {
            INSERT_Lost();
            BookData_READ();
        }

        private void price_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void price_Leave(object sender, EventArgs e)
        {
            price.Text = (decimal.Parse(price.Text)).ToString("N", CultureInfo.CreateSpecificCulture("id-ID"));
        }
    }
}
