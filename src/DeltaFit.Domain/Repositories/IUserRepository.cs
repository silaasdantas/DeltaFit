using DeltaFit.Domain.Entities;
using DeltaFit.Domain.ValueObjects;

namespace DeltaFit.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<User> GetByIdWithDapperAsync(Guid id, CancellationToken cancellationToken = default);

        Task<User> GetByEmailAsync(Email email, CancellationToken cancellationToken = default);

        Task<bool> IsEmailUniqueAsync(Email email, CancellationToken cancellationToken = default);

        Task<bool> IsPhoneUniqueAsync(Phone phone, CancellationToken cancellationToken);

        Task<List<User>> GetMembersAsync(CancellationToken cancellationToken = default);

        void Add(User user);

        void Update(User user);
    }
}
