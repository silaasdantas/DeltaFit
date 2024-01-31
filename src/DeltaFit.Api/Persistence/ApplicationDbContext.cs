using DeltaFit.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeltaFit.Api.Persistence
{
    public sealed class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) 
            : base(options)
        {                
        }
        public DbSet<Member> Members { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        //         modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
    }
}
