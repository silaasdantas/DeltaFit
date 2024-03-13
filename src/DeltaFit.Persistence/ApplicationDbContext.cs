using DeltaFit.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeltaFit.Persistence
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
        public DbSet<RolePermission> RolePermissions { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        //         modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
    }
}
