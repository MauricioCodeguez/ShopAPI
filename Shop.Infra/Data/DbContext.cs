using Shop.Domain.Context;
using Shop.Shared;
using System.Data;
using System.Data.SqlClient;

namespace Shop.Infra.Data
{
    public class DbContext : IDbContext
    {
        public IDbConnection Connection { get; }

        public DbContext()
        {
            Connection = new SqlConnection(Settings.ConnectionString);
            Connection.Open();
        }

        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }
    }
}