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
    public partial class Damage_Lost_books : Form
    {
        DamageLostBooks DLB = new DamageLostBooks();
        BookData_CRUD BK = new BookData_CRUD();
        Income in_crud = new Income();

        int qtyi;
        public Damage_Lost_books()
        {
            InitializeComponent();
        }

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

        public void Income_INSERT()
        {
            if(paid_cm.Text == "Yes" && reasons_cm.Text == "Damaged")
            {
                in_crud.Title = title_cm.Text;
                in_crud.ISBN = (int)Convert.ToInt32(isbn_rO.Text);
                in_crud.Qty = Convert.ToInt32(qty.Text);
                in_crud.Total = Convert.ToDecimal(totalp.Text);
                in_crud.Cust_First_Name = "B00ks";
                in_crud.Cust_Last_Name = "B00ks";
                in_crud.Phone_Num = "-";
                in_crud.Date = DateTime.UtcNow.Date;
                in_crud.Type = "Damaged";

                in_crud.Insert_BookData();
            }
            else if(paid_cm.Text == "Yes" && reasons_cm.Text == "Lost")
            {
                in_crud.Title = title_cm.Text;
                in_crud.ISBN = (int)Convert.ToInt32(isbn_rO.Text);
                in_crud.Qty = Convert.ToInt32(qty.Text);
                in_crud.Total = Convert.ToDecimal(totalp.Text);
                in_crud.Cust_First_Name = "B00ks";
                in_crud.Cust_Last_Name = "B00ks";
                in_crud.Phone_Num = "-";
                in_crud.Date = DateTime.UtcNow.Date;
                in_crud.Type = "Lost";

                in_crud.Insert_BookData();
            }
            else
            {
                in_crud.Title = title_cm.Text;
                in_crud.ISBN = (int)Convert.ToInt32(isbn_rO.Text);
                in_crud.Qty = Convert.ToInt32(qty.Text);
                in_crud.Total = Convert.ToDecimal(totalp.Text);
                in_crud.Cust_First_Name = "B00ks";
                in_crud.Cust_Last_Name = "B00ks";
                in_crud.Phone_Num = "-";
                in_crud.Date = DateTime.UtcNow.Date;
                in_crud.Type = "Others";

                in_crud.Insert_BookData();
            }
        }
        public void BookData_READ()
        {
            //dataGridViewdatabook.DataSource = null;
            BK.Read_BookData();
            //dataGridViewdatabook.DataSource = BK.dt;
        }

        public void BookData_SEARCH()
        {
            //dataGridViewdatabook.DataSource = null;
            BK.Search_BookData(searchbox.Text);
            //dataGridViewdatabook.DataSource = BK.dt;
        }

        public void DL_READ_All()
        {
            dataGridViewdlbook.DataSource = null;
            DLB.DL_Read_All();
            dataGridViewdlbook.DataSource = DLB.dt;
        }


        public void DL_READ_NoPaid()
        {
            dataGridViewdlbook.DataSource = null;
            DLB.DL_Read();
            dataGridViewdlbook.DataSource = DLB.dt;
        }

        public void DL_SEARCH()
        {
            dataGridViewdlbook.DataSource = null;
            DLB.DL_Search(searchbox.Text);
            dataGridViewdlbook.DataSource = DLB.dt;
        }

        public void DL_INSERT()
        {
            if (title_cm.Text == "")
            {
                MessageBox.Show("Please choose the Title of the damaged/lost book", "Error");
            }
            else if (price.Text == "")
            {
                MessageBox.Show("Please choose the price of the damaged/lost book", "Error");
            }
            else if (qty.Text == "")
            {
                MessageBox.Show("Please Insert the quantity of the damaged/lost book", "Error");
            }
            else if (isbn_rO.Text == "")
            {
                MessageBox.Show("Please choose the ISBN of the damaged/lost book", "Error");
            }
            else if (reasons_cm.Text == "")
            {
                MessageBox.Show("Please choose a reason of the damaged/lost book", "Error");
            }
            else if (paid_cm.Text == "")
            {
                MessageBox.Show("Please choose if the damaged/lost book is already paid for the damage/lost or not", "Error");
            }
            else
            {
                
                DLB.Title = title_cm.Text;
                DLB.ISBN = (int)Convert.ToInt64(isbn_rO.Text);
                DLB.Qty = Convert.ToInt32(qty.Text);
                DLB.Price = Convert.ToDecimal(price.Text);
                DLB.Reason = reasons_cm.Text;
                DLB.Total = Convert.ToDecimal(totalp.Text);
                DLB.Paid = paid_cm.Text;

                DLB.DL_Insert();
                UPDATE_Stock();
                MessageBox.Show(title_cm.Text + " has successfully inserted to Damaged/Lost Books !", "Info");

            }
        }

        public void DL_DELETE()
        {
            if (MessageBox.Show("Are you sure to delete this Damaged/Lost Book?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (paid_cm.Text == "No")
                {
                    DLB.ID = Convert.ToInt32(ids.Text);
                    DLB.ISBN = (int)Convert.ToInt64(isbn_rO.Text);

                    UPDATE_Stock1();

                    DLB.DL_Delete_haventPaid();
                }
                else
                {
                    DLB.ID = Convert.ToInt32(ids.Text);
                    DLB.ISBN = (int)Convert.ToInt64(isbn_rO.Text);

                    DLB.DL_Delete();
                }

                MessageBox.Show(title_cm.Text + " has successfully deleted in damaged/lost book!", "Info");
            }

        }
        public void UPDATE_dlbook()
        {
            DLB.Paid = paid_cm.Text;
            DLB.ID = Convert.ToInt32(ids.Text);
            DLB.DL_Update();
        }

        public void get_title()
        {
            title_cm.DataSource = null;
            BK.get_Titles();
            title_cm.DataSource = BK.dt;
            title_cm.DisplayMember = "Title";
        }

        public void get_ISBN()
        {
            isbn_rO.DataSource = null;
            BK.get_ISBNs();
            isbn_rO.DataSource = BK.dt;
            isbn_rO.DisplayMember = "ISBN";
        }
        public void UPDATE_Stock()
        {
                BK.Qty = Convert.ToInt32(qty.Text);
                BK.ISBN = (int)Convert.ToInt64(isbn_rO.Text);
                BK.Update_Stock_Books();
            
        }

        public void UPDATE_Stock1()
        {
            BK.Qty = Convert.ToInt32(qty.Text);
            BK.ISBN = (int)Convert.ToInt64(isbn_rO.Text);
            BK.Update_Stock_Books1();

        }

        private void Damage_Lost_books_Load(object sender, EventArgs e)
        {
            //BookData_READ();
            DL_READ_NoPaid();
            //get_title();
            //get_ISBN();
            paid_cm.SelectedItem = "No";

            title_cm.Enabled = false;
            isbn_rO.Enabled = false;
            price.Enabled = false;
            qty.Enabled = false;
            reasons_cm.Enabled = false;
            totalp.Enabled = false;
        }
        //private void dataGridViewdatabook_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        if (dataGridViewdatabook.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
        //        {

        //            title_cm.Text = (dataGridViewdatabook.Rows[e.RowIndex].Cells[1].Value.ToString());
        //            isbn_rO.Text = (dataGridViewdatabook.Rows[e.RowIndex].Cells[5].Value.ToString());
        //            price.Text = (dataGridViewdatabook.Rows[e.RowIndex].Cells[7].Value.ToString());

        //            title_cm.Enabled = true;
        //            isbn_rO.Enabled = true;
        //            price.Enabled = true;
        //            qty.Enabled = true;
        //            reasons_cm.Enabled = true;
        //            totalp.Enabled = true;
        //        }
        //    }
        //    catch (Exception err)
        //    {
        //        //MessageBox.Show(err.Message);
        //    }
        //}

        //private void stock_TextChanged(object sender, EventArgs e)
        //{

        //    //BK.check_stock(isbn_rO.Text);

            
        //    try
        //    {
        //        if(qty.Text == "")
        //        {
        //            totalp.Text = "";
        //        }
        //        else if(qty.Text == "0")
        //        {
        //            MessageBox.Show("Quantity should not be equal to zero", "Error");
        //        }
        //        else
        //        {
        //            for (int items = 0; items < dataGridViewdatabook.Rows.Count; items++)
        //            {
        //                if (isbn_rO.Text == dataGridViewdatabook.Rows[items].Cells["ISBN"].Value.ToString() && Convert.ToInt32(qty.Text) > Convert.ToInt32(dataGridViewdatabook.Rows[items].Cells["Stock"].Value.ToString()))
        //                {
        //                    MessageBox.Show("Quantity is exceeded from the actual stock! should be equal or less than the actual stock", "Error");
        //                    ClearTextBoxes();
        //                    return;
        //                }
        //            }
                    
        //                totalp.Text = Convert.ToString(Convert.ToInt32(price.Text) * Convert.ToInt32(qty.Text));
                    
                    
        //        }
        //    }
        //    catch(Exception err)
        //    {
        //        //MessageBox.Show(err.Message);
        //    }
            
        //}

        //private void dataGridViewdatabook_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        if (dataGridViewdatabook.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
        //        {

        //            title_cm.Text = (dataGridViewdatabook.Rows[e.RowIndex].Cells[1].Value.ToString());
        //            isbn_rO.Text = (dataGridViewdatabook.Rows[e.RowIndex].Cells[5].Value.ToString());
        //            price.Text = (dataGridViewdatabook.Rows[e.RowIndex].Cells[7].Value.ToString());
        //            qty.Text = "";
        //            reasons_cm.Text = "";
        //            totalp.Text = "";

        //            title_cm.Enabled = true;
        //            isbn_rO.Enabled = true;
        //            price.Enabled = true;
        //            qty.Enabled = true;
        //            reasons_cm.Enabled = true;
        //            totalp.Enabled = true;
        //        }
        //    }
        //    catch (Exception err)
        //    {
        //        MessageBox.Show(err.Message);
        //    }
        //}

        //private void dataGridViewdatabook_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        if (dataGridViewdatabook.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
        //        {

        //            title_cm.Text = (dataGridViewdatabook.Rows[e.RowIndex].Cells[1].Value.ToString());
        //            isbn_rO.Text = (dataGridViewdatabook.Rows[e.RowIndex].Cells[5].Value.ToString());
        //            price.Text = (dataGridViewdatabook.Rows[e.RowIndex].Cells[7].Value.ToString());
        //            qty.Text = "";
        //            reasons_cm.Text = "";
        //            totalp.Text = "";

        //            title_cm.Enabled = true;
        //            isbn_rO.Enabled = true;
        //            price.Enabled = true;
        //            qty.Enabled = true;
        //            reasons_cm.Enabled = true;
        //            totalp.Enabled = true;
        //        }
        //    }
        //    catch (Exception err)
        //    {
        //        MessageBox.Show(err.Message);
        //    }
        //}

        //private void dataGridViewdatabook_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        if (dataGridViewdatabook.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
        //        {

        //            title_cm.Text = (dataGridViewdatabook.Rows[e.RowIndex].Cells[1].Value.ToString());
        //            isbn_rO.Text = (dataGridViewdatabook.Rows[e.RowIndex].Cells[5].Value.ToString());
        //            price.Text = (dataGridViewdatabook.Rows[e.RowIndex].Cells[7].Value.ToString());
        //            qty.Text = "";
        //            reasons_cm.Text = "";
        //            totalp.Text = "";

        //            title_cm.Enabled = true;
        //            isbn_rO.Enabled = true;
        //            price.Enabled = true;
        //            qty.Enabled = true;
        //            reasons_cm.Enabled = true;
        //            totalp.Enabled = true;

        //        }
        //    }
        //    catch (Exception err)
        //    {
        //        MessageBox.Show(err.Message);
        //    }
        //}

        private void searchbox_TextChanged(object sender, EventArgs e)
        {

            if (searchbox.Text=="")
            {
                BookData_READ();
                DL_READ_NoPaid();
            }
            else
            {
                BookData_SEARCH();
                DL_SEARCH();
            }
            
            
        }

        private void Ins_btn_Click(object sender, EventArgs e)
        {
            DL_INSERT();
            Income_INSERT();
            BookData_READ();
            DL_READ_NoPaid();
            ClearTextBoxes();
        }

        private void del_btn_Click(object sender, EventArgs e)
        {
            DL_DELETE();
            DL_READ_NoPaid();
            BookData_READ();
            ClearTextBoxes();
        }
        private void dataGridViewdlbook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewdlbook.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    ids.Text = (dataGridViewdlbook.Rows[e.RowIndex].Cells[0].Value.ToString());
                    title_cm.Text = (dataGridViewdlbook.Rows[e.RowIndex].Cells[1].Value.ToString());
                    isbn_rO.Text = (dataGridViewdlbook.Rows[e.RowIndex].Cells[2].Value.ToString());
                    qty.Text = (dataGridViewdlbook.Rows[e.RowIndex].Cells[3].Value.ToString());
                    price.Text = (dataGridViewdlbook.Rows[e.RowIndex].Cells[4].Value.ToString());
                    totalp.Text = (dataGridViewdlbook.Rows[e.RowIndex].Cells[5].Value.ToString());
                    reasons_cm.Text = (dataGridViewdlbook.Rows[e.RowIndex].Cells[6].Value.ToString());
                    paid_cm.Text = (dataGridViewdlbook.Rows[e.RowIndex].Cells[7].Value.ToString());


                    title_cm.Enabled = false;
                    isbn_rO.Enabled = false;
                    price.Enabled = false;
                    qty.Enabled = false;
                    reasons_cm.Enabled = false;
                    totalp.Enabled = false;

                    price.Text = (decimal.Parse(price.Text)).ToString("N", CultureInfo.CreateSpecificCulture("id-ID"));
                    totalp.Text = (decimal.Parse(totalp.Text)).ToString("N", CultureInfo.CreateSpecificCulture("id-ID"));
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void dataGridViewdlbook_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewdlbook.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    ids.Text = (dataGridViewdlbook.Rows[e.RowIndex].Cells[0].Value.ToString());
                    title_cm.Text = (dataGridViewdlbook.Rows[e.RowIndex].Cells[1].Value.ToString());
                    isbn_rO.Text = (dataGridViewdlbook.Rows[e.RowIndex].Cells[2].Value.ToString());
                    qty.Text = (dataGridViewdlbook.Rows[e.RowIndex].Cells[3].Value.ToString());
                    price.Text = (dataGridViewdlbook.Rows[e.RowIndex].Cells[4].Value.ToString());
                    totalp.Text = (dataGridViewdlbook.Rows[e.RowIndex].Cells[5].Value.ToString());
                    reasons_cm.Text = (dataGridViewdlbook.Rows[e.RowIndex].Cells[6].Value.ToString());
                    paid_cm.Text = (dataGridViewdlbook.Rows[e.RowIndex].Cells[7].Value.ToString());

                    price.Text = (decimal.Parse(price.Text)).ToString("N", CultureInfo.CreateSpecificCulture("id-ID"));
                    totalp.Text = (decimal.Parse(totalp.Text)).ToString("N", CultureInfo.CreateSpecificCulture("id-ID"));
                }


                title_cm.Enabled = false;
                isbn_rO.Enabled = false;
                price.Enabled = false;
                qty.Enabled = false;
                reasons_cm.Enabled = false;
                totalp.Enabled = false;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void dataGridViewdlbook_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewdlbook.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    ids.Text = (dataGridViewdlbook.Rows[e.RowIndex].Cells[0].Value.ToString());
                    title_cm.Text = (dataGridViewdlbook.Rows[e.RowIndex].Cells[1].Value.ToString());
                    isbn_rO.Text = (dataGridViewdlbook.Rows[e.RowIndex].Cells[2].Value.ToString());
                    qty.Text = (dataGridViewdlbook.Rows[e.RowIndex].Cells[3].Value.ToString());
                    price.Text = (dataGridViewdlbook.Rows[e.RowIndex].Cells[4].Value.ToString());
                    totalp.Text = (dataGridViewdlbook.Rows[e.RowIndex].Cells[5].Value.ToString());
                    reasons_cm.Text = (dataGridViewdlbook.Rows[e.RowIndex].Cells[6].Value.ToString());
                    paid_cm.Text = (dataGridViewdlbook.Rows[e.RowIndex].Cells[7].Value.ToString());

                    price.Text = (decimal.Parse(price.Text)).ToString("N", CultureInfo.CreateSpecificCulture("id-ID"));
                    totalp.Text = (decimal.Parse(totalp.Text)).ToString("N", CultureInfo.CreateSpecificCulture("id-ID"));

                }


                title_cm.Enabled = false;
                isbn_rO.Enabled = false;
                price.Enabled = false;
                qty.Enabled = false;
                reasons_cm.Enabled = false;
                totalp.Enabled = false;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void dataGridViewdlbook_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewdlbook.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    ids.Text = (dataGridViewdlbook.Rows[e.RowIndex].Cells[0].Value.ToString());
                    title_cm.Text = (dataGridViewdlbook.Rows[e.RowIndex].Cells[1].Value.ToString());
                    isbn_rO.Text = (dataGridViewdlbook.Rows[e.RowIndex].Cells[2].Value.ToString());
                    qty.Text = (dataGridViewdlbook.Rows[e.RowIndex].Cells[3].Value.ToString());
                    price.Text = (dataGridViewdlbook.Rows[e.RowIndex].Cells[4].Value.ToString());
                    totalp.Text = (dataGridViewdlbook.Rows[e.RowIndex].Cells[5].Value.ToString());
                    reasons_cm.Text = (dataGridViewdlbook.Rows[e.RowIndex].Cells[6].Value.ToString());
                    paid_cm.Text = (dataGridViewdlbook.Rows[e.RowIndex].Cells[7].Value.ToString());

                    price.Text = (decimal.Parse(price.Text)).ToString("N", CultureInfo.CreateSpecificCulture("id-ID"));
                    totalp.Text = (decimal.Parse(totalp.Text)).ToString("N", CultureInfo.CreateSpecificCulture("id-ID"));

                }


                title_cm.Enabled = false;
                isbn_rO.Enabled = false;
                price.Enabled = false;
                qty.Enabled = false;
                reasons_cm.Enabled = false;
                totalp.Enabled = false;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void upd_btn_Click(object sender, EventArgs e)
        {
            UPDATE_dlbook();
            Income_INSERT();
            DL_READ_NoPaid();
            ClearTextBoxes();
        }

        private void title_cm_SelectionChangeCommitted(object sender, EventArgs e)
        {
        }

        private void isbn_rO_SelectionChangeCommitted(object sender, EventArgs e)
        {
        }

        private void isbn_rO_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void price_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void title_cm_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void isbn_rO_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void title_cm_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void yespaid_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void price_Leave(object sender, EventArgs e)
        {
            price.Text = (decimal.Parse(price.Text)).ToString("N", CultureInfo.CreateSpecificCulture("id-ID"));
        }
    }
}
