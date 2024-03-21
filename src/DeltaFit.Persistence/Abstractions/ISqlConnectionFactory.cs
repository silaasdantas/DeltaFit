using Microsoft.Data.SqlClient;

namespace DeltaFit.Persistence.Abstractions
{
    public interface ISqlConnectionFactory
    {
        SqlConnection CreateConnection();
    }
}
