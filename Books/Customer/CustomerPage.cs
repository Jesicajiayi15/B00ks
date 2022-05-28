using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using B00ks.Admin;
using B00ks.Customer;

namespace B00ks.Customer
{
    public partial class CustomerPage : Form
    {
        public CustomerPage()
        {
            InitializeComponent();
        }

        private Form activeForm = null;
        private void openChlidForm(Form Childform)
        {
            if (activeForm != null)

                activeForm.Close();
            activeForm = Childform;
            Childform.TopLevel = false;
            Childform.FormBorderStyle = FormBorderStyle.None;
            Childform.Dock = DockStyle.Fill;
            panelchild.Controls.Add(Childform);
            panelchild.Tag = Childform;
            Childform.BringToFront();
            Childform.Show();

        }


        private void CustomerPage_Load(object sender, EventArgs e)
        {
            homepage.FlatAppearance.MouseOverBackColor = homepage.BackColor;
            homepage.ForeColor = homepage.BackColor;

            openChlidForm(new HomepageCust());
        }

        private void homepage_Click(object sender, EventArgs e)
        {
            Control click = (Control)sender;
            click.BackColor = Color.Transparent;
            click.ForeColor = Color.Transparent;

            openChlidForm(new HomepageCust());
        }

        private void browser_book_Click(object sender, EventArgs e)
        {
            openChlidForm(new Browsebook());
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            this.Close();
            log.Show();
        }

        private void cart_btn_Click(object sender, EventArgs e)
        {
            openChlidForm(new Cart());
        }

        private void rent_book_Click(object sender, EventArgs e)
        {
            openChlidForm(new RentBook());
        }

        private void rtn_book_Click(object sender, EventArgs e)
        {
            openChlidForm(new ReturnBook());
        }
    }
}
