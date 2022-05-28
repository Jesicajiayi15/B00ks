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

namespace B00ks
{
    public partial class AdminPage : Form
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            homepage.FlatAppearance.MouseOverBackColor = homepage.BackColor;
            homepage.ForeColor = homepage.BackColor;

            openChlidForm(new Homepage());

        }

        private void Custom_Design()
        {

            //membuat submenu visible
            bookpanel.Visible = false;

        }

        private void Hide_SubMenu()
        {
            if(bookpanel.Visible == true)
            {
                bookpanel.Visible = false;
            }
        }

        private void show_Submenu(Panel Submenu)
        {
            if(Submenu.Visible == false)
            {
                Hide_SubMenu();
                Submenu.Visible = true;
            }
            else
            {
                Submenu.Visible = false;
            }
        }

        private void bookmangbtn_Click(object sender, EventArgs e)
        {
            show_Submenu(bookpanel);
        }

        private void bookdatabtn_Click(object sender, EventArgs e)
        {
            //code

            openChlidForm(new BooksData());

            
        }

        private Form activeForm = null;
        private void openChlidForm(Form Childform)
        {
            if(activeForm != null)
         
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void homepage_Click(object sender, EventArgs e)
        {
            Control click = (Control)sender;
            click.BackColor = Color.Transparent;
            click.ForeColor = Color.Transparent;

            openChlidForm(new Homepage());
        }

        private void homepage_MouseHover(object sender, EventArgs e)
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void catglangbtn_Click(object sender, EventArgs e)
        {
            openChlidForm(new CatgLang());
        }

        private void publisbtn_Click(object sender, EventArgs e)
        {
            openChlidForm(new PublisherData());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openChlidForm(new Damage_Lost_books());
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            openChlidForm(new AdminManagement());
        }
        private void exit_btn_Click_1(object sender, EventArgs e)
        {
            Login log = new Login();
            this.Close();
            log.Show();
        }
        private void accmanagbtn_Click(object sender, EventArgs e)
        {
            openChlidForm(new Income_page());
        }


        private void panelchild_Paint(object sender, PaintEventArgs e)
        {

        }

        private void orderbtn_Click(object sender, EventArgs e)
        {
            openChlidForm(new CustomerOrders());
        }

        private void bookrentbtn_Click(object sender, EventArgs e)
        {
            openChlidForm(new RentBook_Admin());
        }
    }
}
