using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace B00ks.Customer.Classes
{
    class RentbookTemp_data
    {
        public int ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
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
            string query = "SELECT ID, Title, ISBN, Qty, From_Date, To_Date FROM Rent_Book_Temp";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.Fill(ds);
            dt = ds.Tables[0];
        }

        public void Remove_or_CancelAll_Rent_Temp()
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "DELETE FROM Rent_Book_Temp";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                cmd.Parameters.Add("@ISBN", SqlDbType.BigInt).Value = ISBN;

                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }

        public void Cancel_Aitem_Rent()
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "DELETE FROM Rent_Book_Temp WHERE ID = @ID";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                cmd.Parameters.Add("@ISBN", SqlDbType.BigInt).Value = ISBN;

                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }
        public void Insert_BookRent()
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "INSERT INTO Rent_Book_Temp (Title, ISBN, Qty, From_Date, To_Date) VALUES (@Title, @ISBN, @Qty, @From_Date, @To_Date)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                cmd.Parameters.Add("@Title", SqlDbType.VarChar).Value = Title;
                cmd.Parameters.Add("@ISBN", SqlDbType.BigInt).Value = ISBN;
                cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = Qty;
                cmd.Parameters.Add("@From_Date", SqlDbType.Date).Value = From_Date;
                cmd.Parameters.Add("@To_Date", SqlDbType.Date).Value = To_Date;

                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }

        public void Search_BookRentTemp(string parameter)
        {
            dt.Clear();
            string query = "SELECT ID, Title, ISBN, Qty, From_Date, To_Date FROM Rent_Book_Temp WHERE Title LIKE '%"+parameter+"%'";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.Fill(ds);
            dt = ds.Tables[0];
        }
        public void UPDATE_BookRent()
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "UPDATE Rent_Book_Temp SET First_Name = @First_Name, Last_Name = @Last_Name WHERE ID = @ID";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                cmd.Parameters.Add("@First_Name", SqlDbType.VarChar).Value = First_Name;
                cmd.Parameters.Add("@Last_Name", SqlDbType.VarChar).Value = Last_Name;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;

                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }

        public bool Check_Item_IsExistInRent(string isbn)
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                //dt.Clear();
                cmd.CommandText = "SELECT COUNT(*) FROM Rent_Book_Temp WHERE ISBN ='" + isbn + "'";
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

        }
    }
}
