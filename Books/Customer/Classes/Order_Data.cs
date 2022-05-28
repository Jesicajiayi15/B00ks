using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace B00ks.Customer.Classes
{
    class Order_Data
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int ISBN { get; set; }
        public int Qty { get; set; }
        public decimal Total { get; set; }
        public string Cust_First_Name { get; set; }
        public string Cust_Last_Name { get; set; }
        public string Phone_Num { get; set; }
        public string Type{ get; set; }




        public DataTable dt = new DataTable();
        public DataSet ds = new DataSet();

        SqlConnection conn = new SqlConnection(Connection.Config());


        public void Insert_Order()
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "INSERT INTO Order_Data (Title, ISBN, Qty, Total, Cust_First_Name, Cust_Last_Name, Phone_Num, Type) VALUES (@Title, @ISBN, @Qty, @Total, @Cust_First_Name, @Cust_Last_Name, @Phone_Num, @Type)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                cmd.Parameters.Add("@Title", SqlDbType.VarChar).Value = Title;
                cmd.Parameters.Add("@ISBN", SqlDbType.BigInt).Value = ISBN;
                cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = Qty;
                cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = Total;
                cmd.Parameters.Add("@Cust_First_Name", SqlDbType.VarChar).Value = Cust_First_Name;
                cmd.Parameters.Add("@Cust_Last_Name", SqlDbType.VarChar).Value = Cust_Last_Name;
                cmd.Parameters.Add("@Phone_Num", SqlDbType.VarChar).Value = Phone_Num;
                cmd.Parameters.Add("@Type", SqlDbType.VarChar).Value = Type;

                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }

        public void Read_Order()
        {
            dt.Clear();
            string query = "SELECT * FROM Order_Data";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.Fill(ds);
            dt = ds.Tables[0];
        }

        public void Read_Order_Type(string type)
        {
            dt.Clear();
            string query = "SELECT * FROM Order_Data WHERE Type LIKE '%"+type+"%'";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.Fill(ds);
            dt = ds.Tables[0];
        }

        public void Delete_Order()
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "DELETE FROM Order_Data WHERE ISBN = @ISBN AND ID = @ID";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                cmd.Parameters.Add("@ISBN", SqlDbType.BigInt).Value = ISBN;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = ID;

                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }

        public bool Check_Order(string fname, string lname, string isbn, string title)
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                //dt.Clear();
                cmd.CommandText = "SELECT COUNT(*) FROM Order_Data WHERE ISBN ='" + isbn + "' AND Cust_First_Name = '"+fname+"' AND Cust_Last_Name = '"+lname+"' AND Title = '"+title+"'";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                    int CustomerCount1 = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
                if (CustomerCount1 > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            conn.Close();
        }


    }


}
