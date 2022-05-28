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

namespace B00ks.Admin
{
    public partial class AdminManagement : Form
    {
        public AdminManagement()
        {
            InitializeComponent();
        }
        AccountManage acm = new AccountManage();

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

        public void READ_Acc()
        {
            dataGridViewdaccmanage.DataSource = null;
            acm.Read_Acc();
            dataGridViewdaccmanage.DataSource = acm.dt;
        }

        public void READAct_Acc()
        {
            dataGridViewdaccmanage.DataSource = null;
            acm.ReadActive_Acc();
            dataGridViewdaccmanage.DataSource = acm.dt;
        }
        
        public void SEARCH_Acc()
        {
            acm.Search_Acc(searchbox.Text);
            dataGridViewdaccmanage.DataSource = acm.dt;
        }

        public void INSERT_Acc()
        {

            if (user_txt.Text == "")
            {
                MessageBox.Show("Please Insert a Username", "Error");
            }

            else if (pass_txt.Text == "")
            {
                MessageBox.Show("Please Insert a Password", "Error");
            }
            else if (status_cm.Text == "")
            {
                MessageBox.Show("Please Choose the status of the user", "Error");
            }
            else if (validf_txt.Text != "1")
            {
                MessageBox.Show("Validflag for a new username will always be 1", "Error");
                validf_txt.Text = "1";

            }
            else
            {
                // check if acc exist or not
                for (int items = 0; items < dataGridViewdaccmanage.Rows.Count; items++)
                {
                    if (user_txt.Text == dataGridViewdaccmanage.Rows[items].Cells["Username"].Value.ToString())
                    {
                        MessageBox.Show("This Username is already exist ! Try to use another one", "WARNING");
                        ClearTextBoxes();
                        return;
                    }
                }
                acm.Username = user_txt.Text;
                acm.Password = pass_txt.Text;
                acm.Status = status_cm.Text;
                acm.Validflag = Convert.ToInt32(validf_txt.Text);

                acm.Insert_Acc();

                MessageBox.Show(user_txt.Text + " has successfully inserted !", "Info");
            }
            
        }


        public void UPDATE_Acc()
        {

            if (user_txt.Text == "")
            {
                MessageBox.Show("Please Insert a Username", "Error");
            }

            else if (pass_txt.Text == "")
            {
                MessageBox.Show("Please Insert a Password", "Error");
            }
            else if (status_cm.Text == "")
            {
                MessageBox.Show("Please Choose the status of the user", "Error");
            }
            else
            {
                
                acm.Username = user_txt.Text;
                acm.Password = pass_txt.Text;
                acm.Status = status_cm.Text;
                acm.Validflag = Convert.ToInt32(validf_txt.Text);
                acm.ID = Convert.ToInt32(ids.Text);

                acm.Update_Acc();

                MessageBox.Show(user_txt.Text + " has successfully inserted !", "Info");
                ClearTextBoxes();
            }

        }

        public void DELETE_Acc()
        {
            if(validf_txt.Text == "1")
            {
                if (MessageBox.Show("This Account is still active, are you sure to delete this Account?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    acm.ID = Convert.ToInt32(ids.Text);
                    acm.Username = user_txt.Text;

                    acm.Delete_Acc();

                    MessageBox.Show(user_txt.Text + " has successfully deleted !", "Info");
                }
            }
            else
            {
                if (MessageBox.Show("Are you sure to delete this Account?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    acm.ID = Convert.ToInt32(ids.Text);
                    acm.Username = user_txt.Text;

                    acm.Delete_Acc();

                    MessageBox.Show(user_txt.Text + " has successfully deleted !", "Info");
                }
            }
            
        }

        private void AdminManagement_Load(object sender, EventArgs e)
        {
            READ_Acc();

            status_cm.SelectedItem = "Admin";
        }

        private void chxbox_CheckedChanged(object sender, EventArgs e)
        {
            if (chxbox.Checked)
            {
                READAct_Acc();
            }
            else
            {
                READ_Acc();
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Ins_btn_Click(object sender, EventArgs e)
        {
            INSERT_Acc();
            READ_Acc();
            
        }

        private void upd_btn_Click(object sender, EventArgs e)
        {
            UPDATE_Acc();
            READ_Acc();
            ClearTextBoxes();
        }

        private void del_btn_Click(object sender, EventArgs e)
        {
            DELETE_Acc();
            READ_Acc();
            ClearTextBoxes();
        }

        private void searchbox_TextChanged(object sender, EventArgs e)
        {
            SEARCH_Acc();
        }

        private void dataGridViewdaccmanage_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView sendgrd = (DataGridView)sender;

            try
            {
                if (dataGridViewdaccmanage.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    ids.Text = (dataGridViewdaccmanage.Rows[e.RowIndex].Cells[0].Value.ToString());
                    user_txt.Text = (dataGridViewdaccmanage.Rows[e.RowIndex].Cells[1].Value.ToString());
                    pass_txt.Text = (dataGridViewdaccmanage.Rows[e.RowIndex].Cells[2].Value.ToString());
                    status_cm.Text = (dataGridViewdaccmanage.Rows[e.RowIndex].Cells[3].Value.ToString());
                    validf_txt.Text = (dataGridViewdaccmanage.Rows[e.RowIndex].Cells[4].Value.ToString());
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void dataGridViewdaccmanage_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView sendgrd = (DataGridView)sender;

            try
            {
                if (dataGridViewdaccmanage.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    ids.Text = (dataGridViewdaccmanage.Rows[e.RowIndex].Cells[0].Value.ToString());
                    user_txt.Text = (dataGridViewdaccmanage.Rows[e.RowIndex].Cells[1].Value.ToString());
                    pass_txt.Text = (dataGridViewdaccmanage.Rows[e.RowIndex].Cells[2].Value.ToString());
                    status_cm.Text = (dataGridViewdaccmanage.Rows[e.RowIndex].Cells[3].Value.ToString());
                    validf_txt.Text = (dataGridViewdaccmanage.Rows[e.RowIndex].Cells[4].Value.ToString());
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void dataGridViewdaccmanage_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView sendgrd = (DataGridView)sender;

            try
            {
                if (dataGridViewdaccmanage.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    ids.Text = (dataGridViewdaccmanage.Rows[e.RowIndex].Cells[0].Value.ToString());
                    user_txt.Text = (dataGridViewdaccmanage.Rows[e.RowIndex].Cells[1].Value.ToString());
                    pass_txt.Text = (dataGridViewdaccmanage.Rows[e.RowIndex].Cells[2].Value.ToString());
                    status_cm.Text = (dataGridViewdaccmanage.Rows[e.RowIndex].Cells[3].Value.ToString());
                    validf_txt.Text = (dataGridViewdaccmanage.Rows[e.RowIndex].Cells[4].Value.ToString());
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void dataGridViewdaccmanage_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView sendgrd = (DataGridView)sender;

            try
            {
                if (dataGridViewdaccmanage.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    ids.Text = (dataGridViewdaccmanage.Rows[e.RowIndex].Cells[0].Value.ToString());
                    user_txt.Text = (dataGridViewdaccmanage.Rows[e.RowIndex].Cells[1].Value.ToString());
                    pass_txt.Text = (dataGridViewdaccmanage.Rows[e.RowIndex].Cells[2].Value.ToString());
                    status_cm.Text = (dataGridViewdaccmanage.Rows[e.RowIndex].Cells[3].Value.ToString());
                    validf_txt.Text = (dataGridViewdaccmanage.Rows[e.RowIndex].Cells[4].Value.ToString());
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
