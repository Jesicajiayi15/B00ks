using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace B00ks.Customer.Classes
{
    public class Rent_Book_Data
    {
        public int ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Phone_Num { get; set; }
        public string Title { get; set; }
        public int ISBN { get; set; }
        public int Qty { get; set; }
        public DateTime From_Date { get; set; }
        public DateTime To_Date { get; set; }

        public DataTable dt = new DataTable();
        public DataSet ds = new DataSet();

        SqlConnection conn = new SqlConnection(Connection.Config());


        public void Read_Rent()
        {
            dt.Clear();
            string query = "SELECT * FROM Rent_Books";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.Fill(ds);
            dt = ds.Tables[0];
        }

        public void SEARCH_Rent(string parameter)
        {
            dt.Clear();
            string query = "SELECT * FROM Rent_Books WHERE First_Name LIKE '%"+parameter+"%' OR Last_Name LIKE '%"+parameter+"%' OR Title LIKE '%"+parameter+"%'";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.Fill(ds);
            dt = ds.Tables[0];
        }

        public void Insert_BookRent()
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "INSERT INTO Rent_Books(First_Name, Last_Name, Phone_Num, Title, ISBN, Qty, From_Date, To_Date) VALUES (@First_Name, @Last_Name, @Phone_Num, @Title, @ISBN, @Qty, @From_Date, @To_Date)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                cmd.Parameters.Add("@First_Name", SqlDbType.VarChar).Value = First_Name;
                cmd.Parameters.Add("@Last_Name", SqlDbType.VarChar).Value = Last_Name;
                cmd.Parameters.Add("@Phone_Num", SqlDbType.VarChar).Value = Phone_Num;
                cmd.Parameters.Add("@Title", SqlDbType.VarChar).Value = Title;
                cmd.Parameters.Add("@ISBN", SqlDbType.BigInt).Value = ISBN;
                cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = Qty;
                cmd.Parameters.Add("@From_Date", SqlDbType.Date).Value = From_Date;
                cmd.Parameters.Add("@To_Date", SqlDbType.Date).Value = To_Date;

                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }


        public void Return_Book()
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "DELETE FROM Rent_Books WHERE ID = @ID";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;


                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;

                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }

        public void Delete_Return_Book()
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "DELETE FROM Rent_Books WHERE ID = @ID";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;


                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;

                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }

        public string GetPhoneNum(string firstname, string lastname, string isbn, string qty)
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                //dt.Clear();
                cmd.CommandText = "SELECT Phone_Num FROM Rent_Books WHERE ISBN ='" + isbn + "' AND First_Name = '" + firstname + "' AND Last_Name = '" +lastname +"' AND Qty = '"+qty+"' ";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                string phnum = Convert.ToString(cmd.ExecuteScalar());
                conn.Close();
                return phnum;
            }
        }

    }
}
