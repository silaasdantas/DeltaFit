using DeltaFit.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Permission = DeltaFit.Domain.Enums.Permission;

namespace DeltaFit.Persistence.Configurations
{
    internal sealed class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.HasKey(x => new { x.RoleId, x.PermissionId });

            builder.HasData(
                Create(Role.Admin, Permission.Read),
                Create(Role.Admin, Permission.Update),
                Create(Role.Trainer, Permission.Read),
                Create(Role.Trainer, Permission.Update),
                Create(Role.Student, Permission.Read));
        }

        private static RolePermission Create(
            Role role, Permission permission)
        {
            return new RolePermission
            {
                RoleId = role.Id,
                PermissionId = (int)permission
            };
        }
    }
}
