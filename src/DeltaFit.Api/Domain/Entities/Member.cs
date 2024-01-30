using DeltaFit.Api.Domain.Primitives;

namespace DeltaFit.Api.Domain.Entities
{
    public class Member: AggregateRoot, IAuditableEntity
    {
        public Member(Guid id, string email, string firstName, string lastName)
            : base(id)
        {
            Id = id;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }
        private Member()
        {
        }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }        
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime CreatedOnUtc { get; set; }
        public DateTime? ModifiedOnUtc { get; set; }
        public static Member Create(
                   Guid id,
                   string email,
                   string firstName,
                   string lastName)
        {

            var member = new Member(
                id,
                email,
                firstName,
                lastName);

            //member.RaiseDomainEvent(new MemberRegisteredDomainEvent(
            // Guid.NewGuid(),
            // member.Id));

            return member;
        }
    }
}
