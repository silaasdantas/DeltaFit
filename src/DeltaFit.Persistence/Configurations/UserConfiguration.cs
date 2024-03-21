using DeltaFit.Domain.Entities;
using DeltaFit.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeltaFit.Persistence.Configurations
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(TableNames.Users);

            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Email);

            builder
               .Property(x => x.Phone)
               .HasMaxLength(11);

            builder
                .Property(x => x.FirstName)
                .HasMaxLength(50);

            builder
                .Property(x => x.LastName)
                .HasMaxLength(50);

            builder.HasIndex(x => x.Email).IsUnique();
        }
    }
}
