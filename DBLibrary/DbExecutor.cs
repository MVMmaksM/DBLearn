using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary
{
    public class DbExecutor
    {
        private MainConnector mainConnector;

        public DbExecutor(MainConnector mainConnector)
        {
            this.mainConnector = mainConnector;
        }

        public DataTable SelectAll(string table)
        {
            var sqlCommandText = $"SELECT * FROM {table};";
            var adapter = new SqlDataAdapter(sqlCommandText, mainConnector.GetConnection());

            var dataSet = new DataSet();
            adapter.Fill(dataSet);

            return dataSet.Tables[0];
        }

        public SqlDataReader SelectAllCommandReader(string table)
        {
            var command = new SqlCommand
            {
                CommandType = System.Data.CommandType.Text,
                CommandText = $"SELECT * FROM {table};",
                Connection = mainConnector.GetConnection()
            };

            SqlDataReader sqlDataReader = command.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                return sqlDataReader;
            }

            return null;
        }

        public int DeleteByColumn(string table, string column, string value)
        {
            var command = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = "delete from " + table + " where " + column + " = '" + value + "';",
                Connection = mainConnector.GetConnection(),
            };

            return command.ExecuteNonQuery();

        }
    }
}
