using DeltaFit.Api.Domain.Entities;
using DeltaFit.Api.Domain.ValueObjects;

namespace DeltaFit.Api.Domain.Repositories
{
    public interface IMemberRepository
    {
        Task<Member> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<Member> GetByIdWithDapperAsync(Guid id, CancellationToken cancellationToken = default);

        Task<Member> GetByEmailAsync(Email email, CancellationToken cancellationToken = default);

        Task<bool> IsEmailUniqueAsync(Email email, CancellationToken cancellationToken = default);

        Task<bool> IsPhoneUniqueAsync(Phone phone, CancellationToken cancellationToken);

        Task<List<Member>> GetMembersAsync(CancellationToken cancellationToken = default);

        void Add(Member member);

        void Update(Member member);
    }
}
