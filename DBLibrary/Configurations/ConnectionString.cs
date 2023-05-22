using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.Configurations
{
    public static class ConnectionString
    {
        public static string MsSqlConnection => @"Server = p45-DB08;Database = Test;Trusted_Connection=True";
    }
}
