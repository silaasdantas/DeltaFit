using DeltaFit.Api.Domain.Primitives;

namespace DeltaFit.Api.Domain.Entities
{
    public sealed class Role : Enumeration<Role>
    {
        public static readonly Role Registered = new(1, "Registered");

        public Role(int id, string name)
            : base(id, name)
        {
        }

        public ICollection<Role> Roles { get; set; }

        public ICollection<Permission> Permissions { get; set; }

        public ICollection<Member> Members { get; set; }
    }
}
