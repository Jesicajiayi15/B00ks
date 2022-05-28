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
using B00ks.Customer.Classes;
using System.Globalization;

namespace B00ks.Admin
{
    public partial class CustomerOrders : Form
    {

        Order_Data o_crud = new Order_Data();
        Income in_crud = new Income();
        public CustomerOrders()
        {
            InitializeComponent();
        }

        public void READ_Order()
        {
            dataGridVieworder.DataSource = null;
            o_crud.Read_Order();
            dataGridVieworder.DataSource = o_crud.dt;
        }

        public void READ_Order_Type()
        {
           
            o_crud.Read_Order_Type(type_cm.Text);
            dataGridVieworder.DataSource = o_crud.dt;
        }

        public void REMOVE_from_Order()
        {
            if (MessageBox.Show("Confirm with the selection?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                for (int i = 0; i < dataGridVieworder.Rows.Count; i++)
                {

                    if (Convert.ToBoolean(dataGridVieworder.Rows[i].Cells[0].Value) == true)
                    {
                        o_crud.ID = Convert.ToInt32(dataGridVieworder.Rows[i].Cells[1].Value);
                        o_crud.ISBN = (int)Convert.ToInt64(dataGridVieworder.Rows[i].Cells[3].Value);

                        o_crud.Delete_Order();
                    }
                }
            }
            else
            {

            }
        }

        public void INSERT_toIncome()
        {
            REMOVE_from_Order();
            for (int i = 0; i < dataGridVieworder.Rows.Count; i++)
            {

                if (Convert.ToBoolean(dataGridVieworder.Rows[i].Cells[0].Value) == true)
                {
                    

                    if (Convert.ToInt32(dataGridVieworder.Rows[i].Cells[5].Value) == 0)
                    {
                        
                    }
                    else
                    {
                        in_crud.Title = dataGridVieworder.Rows[i].Cells[2].Value.ToString();
                        in_crud.ISBN = (int)Convert.ToInt32(dataGridVieworder.Rows[i].Cells[3].Value);
                        in_crud.Qty = Convert.ToInt32(dataGridVieworder.Rows[i].Cells[4].Value);
                        in_crud.Total = Convert.ToDecimal(dataGridVieworder.Rows[i].Cells[5].Value);
                        in_crud.Cust_First_Name = dataGridVieworder.Rows[i].Cells[6].Value.ToString();
                        in_crud.Cust_Last_Name = dataGridVieworder.Rows[i].Cells[7].Value.ToString();
                        in_crud.Phone_Num = dataGridVieworder.Rows[i].Cells[8].Value.ToString();
                        in_crud.Date = DateTime.UtcNow.Date;
                        in_crud.Type = "Customer Order";

                        in_crud.Insert_BookData();
                    }
                   
                }
            }

        }

        public void COUNT_total()
        {
            decimal tot = 0;
            for (int i = 0; i < dataGridVieworder.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dataGridVieworder.Rows[i].Cells[0].Value) == true)
                {
                    tot += Convert.ToDecimal(dataGridVieworder.Rows[i].Cells[5].Value);
                }

            }

            total_txt.Text = (tot).ToString("N", CultureInfo.CreateSpecificCulture("id-ID"));

        }

        private void CustomerOrders_Load(object sender, EventArgs e)
        {
            READ_Order();

            type_cm.SelectedItem = "All";

            //MessageBox.Show((dataGridVieworder.Rows[3].Cells[5].Value.ToString()));

            //MessageBox.Show(("Customer Rent Book" == "Customer Rent Book").ToString());

            //MessageBox.Show((Convert.ToInt32(dataGridVieworder.Rows[3].Cells[5].Value) == 0).ToString());
            
        }

        private void upd_btn_Click(object sender, EventArgs e)
        {
            COUNT_total();
        }

        private void Ins_btn_Click(object sender, EventArgs e)
        {
            COUNT_total();
            
            INSERT_toIncome();
            //MessageBox.Show("Data Inserted!");

            total_txt.Clear();
            READ_Order();

        }

        private void type_cm_SelectedValueChanged(object sender, EventArgs e)
        {
            if(type_cm.Text == "All")
            {
                READ_Order();
            }
            else
            {
                READ_Order_Type();
            }            
        }

        private void total_txt_TextChanged(object sender, EventArgs e)
        {
            //total_txt.Text = (decimal.Parse(total_txt.Text)).ToString("N", CultureInfo.CreateSpecificCulture("id-ID"));
        }
    }
}
