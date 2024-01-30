using DeltaFit.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeltaFit.Api.Persistence
{
    public sealed class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {                
        }
        public DbSet<Member> Members { get; set; }
    }
}
