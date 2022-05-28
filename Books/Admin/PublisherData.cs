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
    public partial class PublisherData : Form
    {
        Publishers pub_CRUD = new Publishers();
        public PublisherData()
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

        public void Publisher_READ()
        {
            dataGridViewpublisher.DataSource = null;
            pub_CRUD.Publisher_Read1();
            dataGridViewpublisher.DataSource = pub_CRUD.dt;
        }

        public void Publisher_INSERT()
        {
            if(first_name.Text == "")
            {
                MessageBox.Show("Please Insert a First Name", "Error");
            }
            else if (last_name.Text == "")
            {
                MessageBox.Show("Please Insert a Last Name", "Error");
            }
            else if (country.Text == "")
            {
                MessageBox.Show("Please Insert a Country Name", "Error");
            }
            else if (Convert.ToString(dates.Text) == "")
            {
                MessageBox.Show("Please Insert a Middle Name", "Error");
            }
            else
            {
                //check if full name and country exist or not
                for (int items = 0; items < dataGridViewpublisher.Rows.Count; items++)
                {
                    if (first_name.Text == dataGridViewpublisher.Rows[items].Cells["Publisher_First_Name"].Value.ToString() &&
                        middle_name.Text == dataGridViewpublisher.Rows[items].Cells["Publisher_Middle_Name"].Value.ToString() &&
                        last_name.Text == dataGridViewpublisher.Rows[items].Cells["Publisher_Last_Name"].Value.ToString() &&
                        country.Text == dataGridViewpublisher.Rows[items].Cells["Country"].Value.ToString()
                        )
                    {
                        MessageBox.Show("This Title with this publisher already exist !", "WARNING");
                        ClearTextBoxes();
                        return;
                    }
                }

                pub_CRUD.Publisher_First_Name = first_name.Text;
                pub_CRUD.Publisher_Middle_Name = middle_name.Text;
                pub_CRUD.Publisher_Last_Name = last_name.Text;
                pub_CRUD.DOB = DateTime.Parse(dates.Text);
                pub_CRUD.Country = country.Text;

                pub_CRUD.Publisher_Insert();
            } 
        }

        public void Publisher_DELETE()
        {
            if (first_name.Text == "")
            {
                MessageBox.Show("Please Insert a First Name", "Error");
            }
            else if (last_name.Text == "")
            {
                MessageBox.Show("Please Insert a Last Name", "Error");
            }
            else if (country.Text == "")
            {
                MessageBox.Show("Please Insert a Country Name", "Error");
            }
            else if (Convert.ToString(dates.Text) == "")
            {
                MessageBox.Show("Please Insert a Middle Name", "Error");
            }
            else
            {
                try
                {
                    if (MessageBox.Show("Are you sure to delete this publisher? Please check if any Book is under this publisher", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        

                        if(pub_CRUD.Publisher_CheckBfrDelete(first_name.Text, last_name.Text, country.Text)!= true)
                        {
                            MessageBox.Show("There is one or more Books with this Publisher, please check before delete !!! ", "BOMB");
                        }
                        else
                        {
                            pub_CRUD.ID = Convert.ToInt32(ids.Text);
                            pub_CRUD.Publisher_Delete();

                            MessageBox.Show("The Publisher has successfully deleted !", "Info");
                            Publisher_READ();
                        }
                        
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show("Invalid, " + err.Message, "BOMB ERROR");
                }
            }
        }
      
        private void Publisher_SEARCH()
        {
            dataGridViewpublisher.DataSource = null;
            pub_CRUD.Publisher_Search(searchbox.Text);
            dataGridViewpublisher.DataSource = pub_CRUD.dt;
        }

        private void PublisherData_Load(object sender, EventArgs e)
        {
            Publisher_READ();
            dates.Font = new Font(dates.Font, FontStyle.Regular);
        }

        private void del_btn_Click(object sender, EventArgs e)
        {
            Publisher_DELETE();
            Publisher_READ();
        }

        private void Ins_btn_Click(object sender, EventArgs e)
        {
            Publisher_INSERT();
            Publisher_READ();
        }
        private void searchbox_TextChanged(object sender, EventArgs e)
        {
            Publisher_SEARCH();
        }
        private void dataGridViewpublisher_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView sendgrd = (DataGridView)sender;

            try
            {
                if (dataGridViewpublisher.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    ids.Text = (dataGridViewpublisher.Rows[e.RowIndex].Cells[0].Value.ToString());
                    first_name.Text = (dataGridViewpublisher.Rows[e.RowIndex].Cells[1].Value.ToString());
                    middle_name.Text = (dataGridViewpublisher.Rows[e.RowIndex].Cells[2].Value.ToString());
                    last_name.Text = (dataGridViewpublisher.Rows[e.RowIndex].Cells[3].Value.ToString());
                    country.Text = (dataGridViewpublisher.Rows[e.RowIndex].Cells[5].Value.ToString());
                    dates.Value = DateTime.Parse(dataGridViewpublisher.Rows[e.RowIndex].Cells[4].Value.ToString());
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void dataGridViewpublisher_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView sendgrd = (DataGridView)sender;

            try
            {
                if (dataGridViewpublisher.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    ids.Text = (dataGridViewpublisher.Rows[e.RowIndex].Cells[0].Value.ToString());
                    first_name.Text = (dataGridViewpublisher.Rows[e.RowIndex].Cells[1].Value.ToString());
                    middle_name.Text = (dataGridViewpublisher.Rows[e.RowIndex].Cells[2].Value.ToString());
                    last_name.Text = (dataGridViewpublisher.Rows[e.RowIndex].Cells[3].Value.ToString());
                    country.Text = (dataGridViewpublisher.Rows[e.RowIndex].Cells[5].Value.ToString());
                    dates.Value = DateTime.Parse(dataGridViewpublisher.Rows[e.RowIndex].Cells[4].Value.ToString());
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void dataGridViewpublisher_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView sendgrd = (DataGridView)sender;

            try
            {
                if (dataGridViewpublisher.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    ids.Text = (dataGridViewpublisher.Rows[e.RowIndex].Cells[0].Value.ToString());
                    first_name.Text = (dataGridViewpublisher.Rows[e.RowIndex].Cells[1].Value.ToString());
                    middle_name.Text = (dataGridViewpublisher.Rows[e.RowIndex].Cells[2].Value.ToString());
                    last_name.Text = (dataGridViewpublisher.Rows[e.RowIndex].Cells[3].Value.ToString());
                    country.Text = (dataGridViewpublisher.Rows[e.RowIndex].Cells[5].Value.ToString());
                    dates.Value = DateTime.Parse(dataGridViewpublisher.Rows[e.RowIndex].Cells[4].Value.ToString());
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void dataGridViewpublisher_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView sendgrd = (DataGridView)sender;

            try
            {
                if (dataGridViewpublisher.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    ids.Text = (dataGridViewpublisher.Rows[e.RowIndex].Cells[0].Value.ToString());
                    first_name.Text = (dataGridViewpublisher.Rows[e.RowIndex].Cells[1].Value.ToString());
                    middle_name.Text = (dataGridViewpublisher.Rows[e.RowIndex].Cells[2].Value.ToString());
                    last_name.Text = (dataGridViewpublisher.Rows[e.RowIndex].Cells[3].Value.ToString());
                    country.Text = (dataGridViewpublisher.Rows[e.RowIndex].Cells[5].Value.ToString());
                    dates.Value = DateTime.Parse(dataGridViewpublisher.Rows[e.RowIndex].Cells[4].Value.ToString());
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        
    }
}
