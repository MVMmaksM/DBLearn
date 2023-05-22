using DBLibrary;
using System.Data;
using System.Data.SqlClient;

namespace DBLearn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var manager = new Manager();

            manager.Connect();

            manager.ShowData();

            manager.Disconnect();

            Console.ReadKey();
        }
    }
}