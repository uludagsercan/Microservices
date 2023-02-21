using Npgsql;
using System.Data;

namespace Persistence.Contexts
{
    public class DiscountRepositoryContext
    {
        private readonly IDbConnection _connection;

        public DiscountRepositoryContext(string connectionString)
        {
            _connection = new NpgsqlConnection(connectionString);
        }

        public IDbConnection GetConnection()
        {
            return _connection ;
        }
    }
}
