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
    public partial class CatgLang : Form
    {
        int result;

        CategoriesLanguages catgLang = new CategoriesLanguages();
        public CatgLang()
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

        public void CatgLang_READ()
        {
            dataGridViewcatglang.DataSource = null;
            catgLang.CategoryLang_Read1();
            dataGridViewcatglang.DataSource = catgLang.dt;
        }

        public void CatgLang_INSERT()
        {
            if (category.Text == "")
            {
                MessageBox.Show("Please Insert categories", "Error");
            }
            else if (languages.Text == "")
            {
                MessageBox.Show("Please Insert a language", "Error");
            }
            else
            {

                //check if catg with lang exist or not
                for (int items = 0; items < dataGridViewcatglang.Rows.Count; items++)
                {
                    if (category.Text == dataGridViewcatglang.Rows[items].Cells["Category"].Value.ToString() && languages.Text == dataGridViewcatglang.Rows[items].Cells["Languages"].Value.ToString())
                    {
                        MessageBox.Show("This Category with this Language already exist !", "WARNING");
                        ClearTextBoxes();
                        return;
                    }
                }

                catgLang.Languages = languages.Text;
                catgLang.Category = category.Text;

                catgLang.CategoryLang_Insert();

                MessageBox.Show("The Categories and Languages has successfully updated !", "Info");

            }
        }

        public void CatgLang_DELETE()
        {
            if (category.Text == "")
            {
                MessageBox.Show("Please Insert categories", "Error");
            }
            else if (languages.Text == "")
            {
                MessageBox.Show("Please Insert a language", "Error");
            }
            else
            {
                if (MessageBox.Show("Are you sure to delete this categories and Language? Please check if any books is under this Categories and Language", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        catgLang.CategoryLang_CheckBfrDelete(category.Text, languages.Text);

                        if (catgLang.result != 0)
                        {
                            MessageBox.Show("There is one or more Books with this category and this language, please check before delete !!! ","BOMB");
                        }
                        else
                        {
                            catgLang.ID = Convert.ToInt32(ids.Text);
                            catgLang.CategoryLang_Delete();

                            MessageBox.Show("The Categories and Languages has successfully deleted !", "Info");
                        }
                    }
                    catch(Exception err)
                    {
                        MessageBox.Show("Invalid, " + err.Message, "BOMB ERROR");
                    }
                        
                }
            }


            
            
        }

        public void CatgLang_SEARCH()
        {
            dataGridViewcatglang.DataSource = null;
            catgLang.CategoryLang_Search(searchbox.Text);
            dataGridViewcatglang.DataSource = catgLang.dt;
        }

        private void CatgLang_Load(object sender, EventArgs e)
        {
            CatgLang_READ();
        }

        private void Ins_btn_Click(object sender, EventArgs e)
        {
            CatgLang_INSERT();
            CatgLang_READ();
            ClearTextBoxes();
        }

        private void del_btn_Click(object sender, EventArgs e)
        {
            CatgLang_DELETE();
            CatgLang_READ();
            ClearTextBoxes();
        }

        private void dataGridViewcatglang_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridView sendgrd = (DataGridView)sender;

            try
            {
                if (dataGridViewcatglang.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    ids.Text = (dataGridViewcatglang.Rows[e.RowIndex].Cells[0].Value.ToString());
                    category.Text = (dataGridViewcatglang.Rows[e.RowIndex].Cells[1].Value.ToString());
                    languages.Text = (dataGridViewcatglang.Rows[e.RowIndex].Cells[2].Value.ToString());
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void dataGridViewcatglang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView sendgrd = (DataGridView)sender;

            try
            {
                if (dataGridViewcatglang.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    ids.Text = (dataGridViewcatglang.Rows[e.RowIndex].Cells[0].Value.ToString());
                    category.Text = (dataGridViewcatglang.Rows[e.RowIndex].Cells[1].Value.ToString());
                    languages.Text = (dataGridViewcatglang.Rows[e.RowIndex].Cells[2].Value.ToString());
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void dataGridViewcatglang_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView sendgrd = (DataGridView)sender;

            try
            {
                if (dataGridViewcatglang.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    ids.Text = (dataGridViewcatglang.Rows[e.RowIndex].Cells[0].Value.ToString());
                    category.Text = (dataGridViewcatglang.Rows[e.RowIndex].Cells[1].Value.ToString());
                    languages.Text = (dataGridViewcatglang.Rows[e.RowIndex].Cells[2].Value.ToString());
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void dataGridViewcatglang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView sendgrd = (DataGridView)sender;

            try
            {
                if (dataGridViewcatglang.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    ids.Text = (dataGridViewcatglang.Rows[e.RowIndex].Cells[0].Value.ToString());
                    category.Text = (dataGridViewcatglang.Rows[e.RowIndex].Cells[1].Value.ToString());
                    languages.Text = (dataGridViewcatglang.Rows[e.RowIndex].Cells[2].Value.ToString());
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void searchbox_TextChanged(object sender, EventArgs e)
        {
            CatgLang_SEARCH();
        }
    }
}
