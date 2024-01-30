using DeltaFit.Api.Application.Abstractions;
using Microsoft.Data.SqlClient;

namespace DeltaFit.Api.Persistence
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
            return new SqlConnection(
                _configuration.GetConnectionString("DeltaFit"));
        }
    }
}
