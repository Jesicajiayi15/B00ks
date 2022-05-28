using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace B00ks.Admin.Classes
{
    class AccountManage
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        public int Validflag { get; set; }


        public DataTable dt = new DataTable();
        public DataSet ds = new DataSet();

        SqlConnection conn = new SqlConnection(Connection.Config());

        public void Insert_Acc()
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "INSERT INTO Account_Management (Username, Password, Status, Validflag) VALUES (@Username, @Password, @Status, @Validflag)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = Username;
                cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = Password;
                cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status;
                cmd.Parameters.Add("@Validflag", SqlDbType.Int).Value = Validflag;

                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }

        public void Update_Acc()
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "UPDATE Account_Management SET Username = @Username, Password = @Password, Status = @Status, Validflag = @Validflag WHERE ID=@ID";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = Username;
                cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = Password;
                cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status;
                cmd.Parameters.Add("@Validflag", SqlDbType.Int).Value = Validflag;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;

                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }

        public void Delete_Acc()
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "DELETE FROM Account_Management WHERE ID=@ID AND Username=@Username";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = Username;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;

                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }

        public void Read_Acc()
        {
            dt.Clear();
            string query = "SELECT * FROM Account_Management";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.Fill(ds);
            dt = ds.Tables[0];
        }

        public void Search_Acc(string parameter)
        {
            dt.Clear();
            string query = "SELECT * FROM Account_Management WHERE Username LIKE '%"+parameter+"%' OR Status LIKE '%"+parameter+"%'";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.Fill(ds);
            dt = ds.Tables[0];
        }

        public void ReadActive_Acc()
        {
            dt.Clear();
            string query = "SELECT * FROM Account_Management WHERE Validflag='1'";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.Fill(ds);
            dt = ds.Tables[0];
        }
    }
}
