using DeltaFit.Domain.Entities;
using DeltaFit.Domain.ValueObjects;
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
             .Property(x => x.Email)
             .HasConversion(x => x.Value, v => Email.Create(v).Value);

            builder
               .Property(x => x.Phone)
               .HasMaxLength(11);

            builder
                .Property(x => x.Phone)
                .HasConversion(x => x.Value, v => Phone.Create(v).Value)
                .HasMaxLength(Phone.MaxLength);

            builder
                .Property(x => x.FirstName)
                .HasConversion(x => x.Value, v => FirstName.Create(v).Value)
                .HasMaxLength(FirstName.MaxLength);

            builder
                .Property(x => x.LastName)
                .HasConversion(x => x.Value, v => LastName.Create(v).Value)
                .HasMaxLength(LastName.MaxLength);

            builder.HasIndex(x => x.Email).IsUnique();
        }
    }
}
