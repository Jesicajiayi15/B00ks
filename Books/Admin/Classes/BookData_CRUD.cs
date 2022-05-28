using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace B00ks.Admin.Classes
{
    class BookData_CRUD
    {
        //bookdata
        public int ID { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string Category { get; set; }
        public int Stock { get; set; }
        public int Pages { get; set; }
        public decimal Price { get; set; }
        public int ISBN { get; set; }

        public int Qty { get; set; }




        public DataTable dt = new DataTable();
        public DataSet ds = new DataSet();

        SqlConnection conn = new SqlConnection(Connection.Config());

        public void Insert_BookData()
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "INSERT INTO Books_Data (Title, Publisher, Category, Stock, Pages, Price, ISBN) VALUES (@Title, @Publisher, @Category, @Stock, @Pages, @Price, @ISBN)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                cmd.Parameters.Add("@Title", SqlDbType.VarChar).Value = Title;
                cmd.Parameters.Add("@Publisher", SqlDbType.VarChar).Value = Publisher;
                cmd.Parameters.Add("@Category", SqlDbType.VarChar).Value = Category;
                cmd.Parameters.Add("@Stock", SqlDbType.Int).Value = Stock;
                cmd.Parameters.Add("@Pages", SqlDbType.Int).Value = Pages;
                cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = Price;
                cmd.Parameters.Add("@ISBN", SqlDbType.BigInt).Value = ISBN;

                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }

        public void Update_BookData()
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "UPDATE Books_Data SET Title=@Title, Publisher=@Publisher, Category=@Category, Stock=@Stock, Pages=@Pages, Price=@Price, ISBN=@ISBN WHERE ID = @ID";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                cmd.Parameters.Add("@Title", SqlDbType.VarChar).Value = Title;
                cmd.Parameters.Add("@Publisher", SqlDbType.VarChar).Value = Publisher;
                cmd.Parameters.Add("@Category", SqlDbType.VarChar).Value = Category;
                cmd.Parameters.Add("@Stock", SqlDbType.Int).Value = Stock;
                cmd.Parameters.Add("@Pages", SqlDbType.Int).Value = Pages;
                cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = Price;
                cmd.Parameters.Add("@ISBN", SqlDbType.BigInt).Value = ISBN;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = ID;

                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }

        public void Update_Stock_Books()
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "UPDATE Books_Data SET Stock -= @Qty WHERE ISBN = @ISBN";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = Qty;
                cmd.Parameters.Add("@ISBN", SqlDbType.BigInt).Value = ISBN;

                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }

        public int get_Stock(string isbn)
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                //dt.Clear();
                cmd.CommandText = "SELECT Stock FROM Books_Data WHERE ISBN ='" + isbn + "'";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                int stock = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
                return stock;
            }
        }

        public decimal GetPrice_Book(string isbn)
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                //dt.Clear();
                cmd.CommandText = "SELECT Price FROM Books_Data WHERE ISBN ='" + isbn + "'";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                decimal price = Convert.ToDecimal(cmd.ExecuteScalar());
                conn.Close();
                return price;
            }
        }

        public void Update_Stock_Books_Return()
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "UPDATE Books_Data SET Stock += @Qty WHERE ISBN = @ISBN";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = Qty;
                cmd.Parameters.Add("@ISBN", SqlDbType.BigInt).Value = ISBN;

                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }

        public void Update_Stock_Books1()
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "UPDATE Books_Data SET Stock += @Qty WHERE ISBN = @ISBN";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = Qty;
                cmd.Parameters.Add("@ISBN", SqlDbType.BigInt).Value = ISBN;

                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }

        public void Delete_BookData()
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "DELETE FROM Books_Data WHERE ISBN = @ISBN AND ID = @ID";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                cmd.Parameters.Add("@ISBN", SqlDbType.BigInt).Value = ISBN;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = ID;

                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }


        public void Read_BookData()
        {
            dt.Clear();
            string query = "SELECT * FROM Books_Data Where Stock != 0";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.Fill(ds);
            dt = ds.Tables[0];
        }

        public void Read_BookData_Admin()
        {
            dt.Clear();
            string query = "SELECT * FROM Books_Data";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.Fill(ds);
            dt = ds.Tables[0];
        }

        public void READ_ADMIN()
        {
            dt.Clear();
            string query = "SELECT * FROM Books_Data";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.Fill(ds);
            dt = ds.Tables[0];
        }

        public void Search_BookData(string parameter)
        {
            dt.Clear();
            string query = "SELECT * FROM Books_data WHERE Publisher LIKE '%" + parameter + "%' OR Title LIKE '%" + parameter + "%' AND Stock !=0";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.Fill(ds);
            dt = ds.Tables[0];
        }

        public void Search_BookData_Admin(string parameter)
        {
            dt.Clear();
            string query = "SELECT * FROM Books_data WHERE Publisher LIKE '%" + parameter + "%' OR Title LIKE '%" + parameter + "%'";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.Fill(ds);
            dt = ds.Tables[0];
        }

        public void check_stock(string isbn)
        {
            dt.Clear();
            string query = "SELECT Stock FROM Books_data WHERE ISBN =" + isbn + "";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.Fill(ds);
            dt = ds.Tables[0];
        }

        public void get_Titles()
        {
            dt.Clear();
            string query = "SELECT Title FROM Books_data";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.Fill(ds);
            dt = ds.Tables[0];
        }

        public void get_ISBNs()
        {
            string query = "SELECT ISBN FROM Books_data";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.Fill(ds);
            dt = ds.Tables[0];
            
        }

    }
}
