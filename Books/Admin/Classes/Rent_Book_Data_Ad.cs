using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace B00ks.Admin.Classes
{
    class Rent_Book_Data_Ad
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
    }
}
