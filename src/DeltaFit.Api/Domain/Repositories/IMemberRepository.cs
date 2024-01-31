using DeltaFit.Api.Domain.Entities;

namespace DeltaFit.Api.Domain.Repositories
{
    public interface IMemberRepository
    {
        Task<Member> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<Member> GetByIdWithDapperAsync(Guid id, CancellationToken cancellationToken = default);

        Task<Member> GetByEmailAsync(string email, CancellationToken cancellationToken = default);

        Task<bool> IsEmailUniqueAsync(string email, CancellationToken cancellationToken = default);

        Task<List<Member>> GetMembersAsync(CancellationToken cancellationToken = default);

        void Add(Member member);

        void Update(Member member);
    }
}
