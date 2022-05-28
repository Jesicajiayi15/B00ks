using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data; 

namespace B00ks.Customer.Classes
{
    public class TempComCart
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int ISBN { get; set; }
        public int Qty { get; set; }
        public decimal Total { get; set; }


        public DataTable dt = new DataTable();
        public DataSet ds = new DataSet();
        public int CustomerCount;
        SqlConnection conn = new SqlConnection(Connection.Config());

        public void Insert_Cart()
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SET NOCOUNT ON INSERT INTO Temp_Cart (Title, ISBN, Price, Qty, Total) VALUES (@Title, @ISBN, @Price, @Qty, @Total)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                cmd.Parameters.Add("@Title", SqlDbType.VarChar).Value = Title;
                cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = Qty;
                cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = Price;
                cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = Total;
                cmd.Parameters.Add("@ISBN", SqlDbType.BigInt).Value = ISBN;

                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }

        public void Cancel_A_Item()
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "DELETE FROM Temp_Cart WHERE ID = @ID";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                cmd.Parameters.Add("@ISBN", SqlDbType.BigInt).Value = ISBN;


                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }

        public void CancelAll_Item_or_Clean_Cart()
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "DELETE FROM Temp_Cart";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                cmd.Parameters.Add("@ISBN", SqlDbType.BigInt).Value = ISBN;

                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }

        public bool Check_Item_IsExistInCart(string isbn)
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                //dt.Clear();
                cmd.CommandText = "SELECT COUNT(*) FROM Temp_Cart WHERE ISBN ='" +isbn+"'";
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

        public void Search_Item(string parameter)
        {
            dt.Clear();
            string query = "SELECT * FROM Temp_Cart WHERE Title LIKE '%" + parameter + "%'";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.Fill(ds);
            dt = ds.Tables[0];
        }

        public void Read_Cart()
        {
            dt.Clear();
            string query = "SELECT * FROM Temp_Cart";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.Fill(ds);
            dt = ds.Tables[0];
        }
    }
}
