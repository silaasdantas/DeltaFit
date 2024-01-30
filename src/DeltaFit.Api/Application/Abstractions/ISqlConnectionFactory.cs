using Microsoft.Data.SqlClient;

namespace DeltaFit.Api.Application.Abstractions
{
    public interface ISqlConnectionFactory
    {
        SqlConnection CreateConnection();
    }
}
