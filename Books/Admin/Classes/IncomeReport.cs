using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B00ks.Admin.Classes
{
    public class IncomeReport
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
    }
}
