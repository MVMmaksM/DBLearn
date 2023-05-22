using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Configurations
{
    public static class Settings
    {
        private static string _connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=BookLibrary;TrustServerCertificate=True;Trusted_Connection=True";
        public static string  ConnectionString=> _connectionString;
    }
}
