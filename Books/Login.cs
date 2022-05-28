using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using B00ks.Customer;
using B00ks.Admin;

namespace B00ks
{
    
    public partial class Login : Form
    {
        public static int res = 1;
        class login
        {
            SqlConnection conn = new SqlConnection(Connection.Config());
           
            public string getUser(string username, string pass)
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Account_Management WHERE Username = '" + username + "' AND Password = '" + pass + "' AND Validflag = '1'", conn);
                DataTable dta = new DataTable();
                sda.Fill(dta);

                try
                {
                    if(dta.Rows.Count == 0)
                    {
                        res = 2;
                    }
                    else
                    {
                        foreach(DataRow dt in dta.Rows)
                        {
                            
                            if(dt["Status"].ToString() == "Admin")
                            {
                                res = 0;
                            }
                            else if(dt["Status"].ToString() == "Customer")
                            {
                                res = 1;
                            }
                            else
                            {
                                res = 2;
                            }
                        }
                        
                    }
                    return res.ToString();
                }
                catch(Exception err)
                {
                    MessageBox.Show(err.Message);
                }

                conn.Close();
                return res.ToString();
            }

        }



        public Login()
        {
            InitializeComponent();
        }
        private void Login_Load(object sender, EventArgs e)
        {
            pass.UseSystemPasswordChar = true;
        }

        private void showpas_CheckedChanged(object sender, EventArgs e)
        {
            if (showpas.Checked)
            {
                pass.UseSystemPasswordChar = false;
            }
            else
            {
                pass.UseSystemPasswordChar = true;  
            }
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //login
            if(username.Text == "")
            {
                MessageBox.Show("Please insert a username");
            }
            else if(pass.Text == "")
            {
                MessageBox.Show("Please insert a password");
            }
            else
            {
                login log = new login();

                string res = log.getUser(username.Text, pass.Text);

                if(res == "0")
                {
                   // MessageBox.Show("Hello " + username.Text);
                    AdminPage adm = new AdminPage();
                    adm.Show();
                    this.Hide();
                }
                else if(res == "1")
                {
                    //MessageBox.Show("Hello " + username.Text);
                    CustomerPage cust = new CustomerPage();
                    cust.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Username or password", "Invalid");
                    username.Clear();
                    pass.Clear();
                }
                
            }
        }
    }
}
