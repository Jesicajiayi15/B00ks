using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B00ks.Customer.Classes
{
    public class RentReciept_Data
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int ISBN { get; set; }
        public int Qty { get; set; }
        public DateTime From_Date { get; set; }
        public DateTime To_Date { get; set; }
    }
}
