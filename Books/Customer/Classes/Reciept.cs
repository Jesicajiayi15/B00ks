using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B00ks.Customer.Classes
{
    public class Reciept
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int ISBN { get; set; }
        public int Qty { get; set; }
        public decimal Total { get; set; }

    }
}
