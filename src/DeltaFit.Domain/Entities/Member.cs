namespace DeltaFit.Domain.Entities
{
    public class Member
    {
        private Member()
        {
        }
        public string FirstName { get; set; }
        //public Email Email { get; set; }

        //public LastName LastName { get; set; }
        //public Phone Phone { get; set; }
        //public byte[] PasswordHash { get; set; }
        //public byte[] PasswordSalt { get; set; }
        //public DateTime CreatedOnUtc { get; set; }
        //public DateTime? ModifiedOnUtc { get; set; }
        //public bool Active { get; set; }
        //public ICollection<Role> Roles { get; set; }

        //public static Member Create(
        //           Guid id,
        //           Email email,
        //           Phone phone,
        //           FirstName firstName,
        //           LastName lastName,
        //           byte[] passwordHash,
        //           byte[] passwordSalt)
        //{

        //    var member = new Member(
        //        id,
        //        email,
        //        phone,
        //        firstName,
        //        lastName,
        //         passwordHash,
        //         passwordSalt);

        //    //member.RaiseDomainEvent(new MemberRegisteredDomainEvent(
        //    // Guid.NewGuid(),
        //    // member.Id));

        //    return member;
        //}

        //public void UpdatePassword(byte[] passwordHash, byte[] passwordSalt)
        //{
        //    PasswordHash = passwordHash;
        //    PasswordSalt = passwordSalt;
        //}
    }
}
