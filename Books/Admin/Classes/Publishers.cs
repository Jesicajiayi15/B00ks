using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace B00ks.Admin.Classes
{
    class Publishers
    {

        //Publisher
        public int ID { get; set; }
        public string Publisher_First_Name { get; set; }
        public string Publisher_Middle_Name { get; set; }
        public string Publisher_Last_Name { get; set; }
        public DateTime DOB { get; set; }
        public string Country { get; set; }


        //public int Total { get; set; }
        public int result;

        //public string FullName { get; set; }

        public DataTable dt = new DataTable();
        public DataSet ds = new DataSet();

        SqlConnection conn = new SqlConnection(Connection.Config());

        public void Publisher_Read()
        {

            dt.Clear();
            string querya = "SELECT CONCAT(Publisher_First_Name,' ', Publisher_Last_Name) AS FullName from Publisher";
            SqlDataAdapter sdaa = new SqlDataAdapter(querya, conn);
            sdaa.Fill(ds);
            dt = ds.Tables[0];

        }

        public void Publisher_Read1()
        {

            dt.Clear();
            string querya = "SELECT ID, Publisher_First_Name, Publisher_Middle_Name, Publisher_Last_Name, DOB, Country from Publisher ORDER BY ID";
            SqlDataAdapter sdaa = new SqlDataAdapter(querya, conn);
            sdaa.Fill(ds);
            dt = ds.Tables[0];

        }

        public void Publisher_Insert()
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "INSERT INTO Publisher (Publisher_First_Name, Publisher_Middle_Name, Publisher_Last_Name, DOB, Country) VALUES (@Publisher_First_Name, @Publisher_Middle_Name, @Publisher_Last_Name, @DOB, @Country)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                cmd.Parameters.Add("@Publisher_First_Name", SqlDbType.VarChar).Value = Publisher_First_Name;
                cmd.Parameters.Add("@Publisher_Middle_Name", SqlDbType.VarChar).Value = Publisher_Middle_Name;
                cmd.Parameters.Add("@Publisher_Last_Name", SqlDbType.VarChar).Value = Publisher_Last_Name;
                cmd.Parameters.Add("@DOB", SqlDbType.Date).Value = DOB;
                cmd.Parameters.Add("@Country", SqlDbType.VarChar).Value = Country;

                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }

        public void Publisher_Update()
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "UPDATE Publisher SET Publisher_First_Name = @Publisher_First_Name, Publisher_Middle_Name=@Publisher_Middle_Name, Publisher_Last_Name=@Publisher_Last_Name, DOB=@DOB, Country=@Country WHERE ID = @ID";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                cmd.Parameters.Add("@Publisher_First_Name", SqlDbType.VarChar).Value = Publisher_First_Name;
                cmd.Parameters.Add("@Publisher_Middle_Name", SqlDbType.VarChar).Value = Publisher_Middle_Name;
                cmd.Parameters.Add("@Publisher_Last_Name", SqlDbType.VarChar).Value = Publisher_Last_Name;
                cmd.Parameters.Add("@DOB", SqlDbType.Date).Value = DOB;
                cmd.Parameters.Add("@Country", SqlDbType.Int).Value = Country;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = ID;

                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }

        public void Publisher_Delete()
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "DELETE FROM Publisher WHERE ID = @ID";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = ID;

                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }

        public void Publisher_Search(string parameter)
        {
            dt.Clear();
            string querya = "SELECT ID, Publisher_First_Name, Publisher_Middle_Name, Publisher_Last_Name, DOB, Country from Publisher WHERE Publisher_First_Name LIKE '%" + parameter+"%' OR Publisher_Middle_Name LIKE '%"+parameter+"%' OR Publisher_Last_Name LIKE '%"+parameter+"%' OR Country LIKE '%"+parameter+"%'ORDER BY ID";
            SqlDataAdapter sdaa = new SqlDataAdapter(querya, conn);
            sdaa.Fill(ds);
            dt = ds.Tables[0];
        }


        //Check before Delete to prevent BOMB
        public bool Publisher_CheckBfrDelete(string fn, string ls, string country)
        {

            //dt.Clear();
            //string query = "SELECT COUNT(*) AS Total FROM Books_Data AS A, Publisher AS B WHERE CONCAT('" + fn + "',' ', '" + ls + "') = A.Publisher AND B.Country = '" + country+"'";
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {


                cmd.CommandText = "SELECT COUNT(*) AS Total FROM Books_Data AS A, Publisher AS B WHERE CONCAT('" + fn + "',' ', '" + ls + "') = A.Publisher AND B.Country = '" + country + "'";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                int count = (int)Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();

                if (count == 0)
                {
                    return true;
                }
                return false;
            }

            
            //SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            //sda.Fill(ds);
            //dt = ds.Tables[0];

            //foreach (DataRow mdt in dt.Rows)
            //{
            //    object value = mdt["Total"];
            //    if (Convert.ToInt32(value) == 0)
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        return false;
            //    } 
            //}

            //return false;
        }
    }
}
