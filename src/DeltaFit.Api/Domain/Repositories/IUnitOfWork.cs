using System.Data;

namespace DeltaFit.Api.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync(CancellationToken cancellationToken = default);

        //IDbTransaction BeginTransaction();
    }
}
