using DeltaFit.Domain.Primitives;

namespace DeltaFit.Domain.Entities
{
    public sealed class Role : Enumeration<Role>
    {
        public static readonly Role Admin = new(1, "Admin");
        public static readonly Role Trainer = new(2, "Trainer");
        public static readonly Role Student = new(3, "Student");

        public Role(int id, string name)
        : base(id, name)
        {
        }

        public ICollection<Permission> Permissions { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
