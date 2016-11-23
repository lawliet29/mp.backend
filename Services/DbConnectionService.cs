using System.Data;
using System.Data.OleDb;

namespace Backend.Services
{
    public interface IDbConnectionService
    {
        IDbConnection Connect();
    }

    public class DbConnectionService : IDbConnectionService
    {
        private readonly IDatabaseLocator _locator;

        public DbConnectionService(IDatabaseLocator locator)
        {
            _locator = locator;
        }

        public IDbConnection Connect()
        {
            var connection = new OleDbConnection
            {
                ConnectionString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={_locator.LocateDatabase()}"
            };

            connection.Open();

            return connection;
        }
    }
}
