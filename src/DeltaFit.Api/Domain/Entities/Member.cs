using DeltaFit.Api.Domain.Primitives;

namespace DeltaFit.Api.Domain.Entities
{
    public class Member : AggregateRoot, IAuditableEntity
    {
        public Member(Guid id, string email, string firstName, string lastName, byte[] passwordHash, byte[] passwordSalt)
            : base(id)
        {
            Id = id;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }
        private Member()
        {
        }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime? ModifiedOnUtc { get; set; }
        public bool Active { get; set; }
        public ICollection<Role> Roles { get; set; }

        public static Member Create(
                   Guid id,
                   string email,
                   string firstName,
                   string lastName,
                   byte[] passwordHash,
                   byte[] passwordSalt)
        {

            var member = new Member(
                id,
                email,
                firstName,
                lastName,
                 passwordHash,
                 passwordSalt);

            //member.RaiseDomainEvent(new MemberRegisteredDomainEvent(
            // Guid.NewGuid(),
            // member.Id));

            return member;
        }

        public void UpdatePassword(byte[] passwordHash, byte[] passwordSalt)
        {
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }
    }
}
