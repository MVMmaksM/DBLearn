using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Configurations
{
    public static class Settings
    {
        private static string _connectionString = "Data Source=P45-DB08;Initial Catalog=Test;TrustServerCertificate=True;Trusted_Connection=True";

        public static string  ConnectionString=> _connectionString;
    }
}
