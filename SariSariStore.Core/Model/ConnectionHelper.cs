using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SariSariStore.Core.Model
{
    public class ConnectionHelper
    {
        public static string GetConnectionString()
        {
            return @"Data Source=JEYSI\SQLEXPRESS;Initial Catalog=SariSariStoreDB;Integrated Security=True;Trust Server Certificate=True;";
        }
    }
}
