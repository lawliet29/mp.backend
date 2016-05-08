using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services
{
    public interface IDbConnectionService
    {
        IDbConnection Connect();
    }

    public class DbConnectionService : IDbConnectionService
    {
        public IDbConnection Connect()
        {
            return new OdbcConnection();
        }
    }
}
