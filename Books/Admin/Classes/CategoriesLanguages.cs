using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace B00ks.Admin.Classes
{
    class CategoriesLanguages
    {
        //category
        public string Languages { get; set; }
        public string Category { get; set; }

        public string catgLang { get; set; }
        public int ID { get; set; }

        public int Total { get; set; }

        public DataTable dt = new DataTable();
        public DataSet ds = new DataSet();

        public int result;

        SqlConnection conn = new SqlConnection(Connection.Config());


        public void CategoryLang_Insert()
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "INSERT INTO CategoryLang (Category, Languages) VALUES (@Category, @Languages)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                cmd.Parameters.Add("@Category", SqlDbType.VarChar).Value = Category;
                cmd.Parameters.Add("@Languages", SqlDbType.VarChar).Value = Languages;
                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }
        public void CategoryLang_Delete()
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "DELETE FROM CategoryLang WHERE ID = @ID";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }

        public void CategoryLang_Read()
        {

            dt.Clear();
            string query = "SELECT CONCAT(Category,'; ', Languages) AS catgLang from CategoryLang";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.Fill(ds);
            dt = ds.Tables[0];

        }

        public void CategoryLang_Read1()
        {

            dt.Clear();
            string query = "SELECT * from CategoryLang ORDER BY ID";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.Fill(ds);
            dt = ds.Tables[0];

        }

        public void CategoryLang_Search(string parameter)
        {
            dt.Clear();
            string query = "SELECT * from CategoryLang WHERE Category LIKE '%"+parameter+"%' OR Languages LIKE '%"+parameter+"%' ORDER BY ID";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.Fill(ds);
            dt = ds.Tables[0];
        }


        //Check before Delete to prevent BOMB
        public void CategoryLang_CheckBfrDelete(string category, string languages)
        {
            
            dt.Clear();
            string query = "SELECT COUNT(*) AS Total FROM Books_Data WHERE CONCAT('" + category + "','; ', '" + languages + "') = Category";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.Fill(ds);
            dt = ds.Tables[0];

            foreach(DataRow mdt in dt.Rows)
            {
                object value = mdt["Total"];
                if(Convert.ToInt32(value) == 0)
                {
                    result = 0;
                }
                else
                {
                    result = 1;
                }
            }
        }
    }
}
