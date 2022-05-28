using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace B00ks.Admin.Classes
{
    class DamageLostBooks
    {
        public string Title { get; set; }
        public int ISBN { get; set; }
        public string Reason { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public int Qty { get; set; }
        public string Paid { get; set; }
        public int ID { get; set; }

        public DataTable dt = new DataTable();
        public DataSet ds = new DataSet();

        SqlConnection conn = new SqlConnection(Connection.Config());

        public void DL_Read()
        {
            dt.Clear();
            string query = "SELECT * FROM Damaged_Lost_Books WHERE Paid = 'No'";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.Fill(ds);
            dt = ds.Tables[0];
        }

        public void DL_Read_All()
        {
            dt.Clear();
            string query = "SELECT * FROM Damaged_Lost_Books";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.Fill(ds);
            dt = ds.Tables[0];
        }

        public void DL_Insert()
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "INSERT INTO Damaged_Lost_Books (Title, ISBN, Qty, Price, Total, Reason, Paid) VALUES (@Title, @ISBN, @Qty, @Price, @Total, @Reason, @Paid)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                cmd.Parameters.Add("@Title", SqlDbType.VarChar).Value = Title;
                cmd.Parameters.Add("@ISBN", SqlDbType.BigInt).Value = ISBN;
                cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = Qty;
                cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = Price;
                cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = Total;
                cmd.Parameters.Add("@Reason", SqlDbType.VarChar).Value = Reason;
                cmd.Parameters.Add("@Paid", SqlDbType.VarChar).Value = Paid;

                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }

        public void DL_Update()
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "UPDATE Damaged_Lost_Books SET Paid=@Paid WHERE ID = @ID";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                cmd.Parameters.Add("@Paid", SqlDbType.VarChar).Value = Paid;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = ID;

                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }

        public void DL_Delete()
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "DELETE FROM Damaged_Lost_Books WHERE ISBN = @ISBN AND ID = @ID";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                cmd.Parameters.Add("@ISBN", SqlDbType.BigInt).Value = ISBN;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = ID;

                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }

        public void DL_Delete_haventPaid()
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "DELETE FROM Damaged_Lost_Books WHERE ISBN = @ISBN AND ID = @ID AND Paid ='No'";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                cmd.Parameters.Add("@ISBN", SqlDbType.BigInt).Value = ISBN;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = ID;

                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }

        public void DL_Search(string parameter)
        {
            dt.Clear();
            string query = "SELECT * FROM Damaged_Lost_Books WHERE Title LIKE '%" + parameter + "%' AND Paid = 'No'  OR Reason LIKE '%" + parameter + "%' AND Paid = 'No'";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.Fill(ds);
            dt = ds.Tables[0];
        }



    }


}
