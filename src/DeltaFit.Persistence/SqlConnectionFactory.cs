using DeltaFit.Persistence.Abstractions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DeltaFit.Persistence
{
    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public SqlConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SqlConnection CreateConnection()
        {
            //TODO use options pattern
            return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
