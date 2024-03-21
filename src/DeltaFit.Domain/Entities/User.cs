namespace DeltaFit.Domain.Entities
{
    public class User
    {
        public User(
                   Guid id,
                   string email,
                   string phone,
                   string firstName,
                   string lastName,
                   byte[] passwordHash,
                   byte[] passwordSalt)
        {
            Id = id;
            Email = email;
            Phone = phone;
            FirstName = firstName;
            LastName = lastName;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime? ModifiedOnUtc { get; set; }
        public bool Active { get; set; }
        public ICollection<Role> Roles { get; set; }

        public static User Create(
                   Guid id,
                   string email,
                   string phone,
                   string firstName,
                   string lastName,
                   byte[] passwordHash,
                   byte[] passwordSalt)
        {
            var user = new User(
                id,
                email,
                phone,
                firstName,
                lastName,
                passwordHash,
                passwordSalt);

            return user;
        }

        public void UpdatePassword(byte[] passwordHash, byte[] passwordSalt)
        {
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }
    }
}
