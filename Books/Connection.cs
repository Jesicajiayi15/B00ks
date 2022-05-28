using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace B00ks
{
    public static class Connection
    {
        public static string Config()
        {
            return ConfigurationManager.ConnectionStrings["B00ksDatabase"].ConnectionString;
        }
    }
}
