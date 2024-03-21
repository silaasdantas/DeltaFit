using DeltaFit.Domain.Primitives;
using DeltaFit.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace DeltaFit.Persistence
{
    internal sealed class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext) => _dbContext = dbContext;

        public IDbTransaction BeginTransaction()
        {
            var transaction = _dbContext.Database.BeginTransaction();

            return transaction.GetDbTransaction();
        }

        public Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateAuditableEntities();

            return _dbContext.SaveChangesAsync(cancellationToken);
        }

        private void UpdateAuditableEntities()
        {
            IEnumerable<EntityEntry<IAuditableEntity>> entries =
               _dbContext
                  .ChangeTracker
                  .Entries<IAuditableEntity>();

            foreach (EntityEntry<IAuditableEntity> entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    entityEntry.Property(a => a.CreatedOnUtc).CurrentValue = DateTime.UtcNow;
                }

                if (entityEntry.State == EntityState.Modified)
                {
                    entityEntry.Property(a => a.ModifiedOnUtc).CurrentValue = DateTime.UtcNow;
                }
            }
        }
    }
}
