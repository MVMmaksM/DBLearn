using DBLibrary.Configurations;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary
{
    public class MainConnector
    {
        private SqlConnection connection;
        public async Task<bool> ConnectAsync()
        {
            bool result;

            try
            {
                connection = new SqlConnection(ConnectionString.MsSqlConnection);
                await connection.OpenAsync();
                result = true;
            }
            catch
            {
                result = false;
            }

            return result;
        }

        public async void DisconnectAsync()
        {
            if(connection.State == System.Data.ConnectionState.Open)
            {
                await connection.CloseAsync();
            }
        }

        public SqlConnection GetConnection() 
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                return connection;
            }
            else
            {
                throw new Exception("Подключение закрыто!");
            }
        }       
    }
}
