using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace B00ks.Admin.Classes
{
    public class Income
    {

        public int ID { get; set; }
        public string Title { get; set; }
        public int ISBN { get; set; }
        public int Qty { get; set; }
        public decimal Total { get; set; }
        public string Cust_First_Name { get; set; }
        public string Cust_Last_Name { get; set; }
        public string Phone_Num { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }



        public DataTable dt = new DataTable();
        public DataSet ds = new DataSet();

        SqlConnection conn = new SqlConnection(Connection.Config());

        public void Insert_BookData()
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "INSERT INTO Income_Data (Title, ISBN, Qty, Total, Cust_First_Name, Cust_Last_Name, Phone_Num, Date, Type) VALUES (@Title, @ISBN, @Qty, @Total, @Cust_First_Name, @Cust_Last_Name, @Phone_Num, @Date, @Type)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                cmd.Parameters.Add("@Title", SqlDbType.VarChar).Value = Title;
                cmd.Parameters.Add("@ISBN", SqlDbType.BigInt).Value = ISBN;
                cmd.Parameters.Add("@Cust_First_Name", SqlDbType.VarChar).Value = Cust_First_Name;
                cmd.Parameters.Add("@Cust_Last_Name", SqlDbType.VarChar).Value = Cust_Last_Name;
                cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = Qty;
                cmd.Parameters.Add("@Phone_Num", SqlDbType.VarChar).Value = Phone_Num;
                cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = Total;
                cmd.Parameters.Add("@Date", SqlDbType.Date).Value = Date;
                cmd.Parameters.Add("@Type", SqlDbType.VarChar).Value = Type;

                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }

        public void Read_Income()
        {
            dt.Clear();
            string query = "SELECT * FROM Income_Data";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.Fill(ds);
            dt = ds.Tables[0];
        }


        public void Search_Income(string parameter)
        {
            dt.Clear();
            string query = "SELECT * FROM Income_Data WHERE Cust_First_Name LIKE '%"+parameter+"%' OR Cust_Last_Name  LIKE '%"+parameter+"%' OR Title LIKE '%"+parameter+"%'";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.Fill(ds);
            dt = ds.Tables[0];
        }

        public void Search_Income1(string parameter, string parameter1)
        {
            dt.Clear();
            string query = "SELECT * FROM Income_Data WHERE Cust_First_Name LIKE '%" + parameter + "%' OR Cust_Last_Name  LIKE '%" + parameter + "%' OR Title LIKE '%" + parameter + "%' AND Type = '"+parameter1+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.Fill(ds);
            dt = ds.Tables[0];
        }

        public void Search_by_Combobx(string parameter)
        {
            dt.Clear();
            string query = "SELECT * FROM Income_Data WHERE Type LIKE '%" + parameter + "%'";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.Fill(ds);
            dt = ds.Tables[0];
        }

        public void SearchDate_Income(string fromdate, string todate)
        {
            conn.Open();
            dt.Clear();
            string query = "SELECT * FROM Income_Data WHERE Date BETWEEN '"+fromdate+"' AND '"+todate+"'";
            SqlCommand sda = new SqlCommand (query, conn);
            dt = new DataTable();
            dt.Load(sda.ExecuteReader());
            //sda.SelectCommand.Parameters.AddWithValue("@fromdate", fromdate);
            //sda.SelectCommand.Parameters.AddWithValue("@todate", todate);
            //sda.Fill(dt);
            //dt = ds.Tables[0];
            conn.Close();
        }


    }
}
