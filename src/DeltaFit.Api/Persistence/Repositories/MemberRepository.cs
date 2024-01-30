using Dapper;
using DeltaFit.Api.Application.Abstractions;
using DeltaFit.Api.Domain.Entities;
using DeltaFit.Api.Domain.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DeltaFit.Api.Persistence.Repositories
{
    public sealed class MemberRepository : IMemberRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ISqlConnectionFactory _connectionFactory;

        public MemberRepository(ApplicationDbContext dbContext, ISqlConnectionFactory connectionFactory)
        {
            _dbContext = dbContext;
            _connectionFactory = connectionFactory;
            SeedData();
        }

        private void SeedData()
        {
            if (!_dbContext.Members.Any())
            {
                _dbContext.Members.Add(new Member(Guid.NewGuid(), "silas.dantas@gmail.com", "Silas", "Dantas Pereira"));
                _dbContext.Members.Add(new Member(Guid.NewGuid(), "paloma.almeida@gmail.com", "Paloma", "Alemida Barros"));
                _dbContext.SaveChanges();
            }
        }

        public async Task<List<Member>> GetMembersAsync(CancellationToken cancellationToken = default)
        => await _dbContext.Set<Member>().ToListAsync(cancellationToken);

        public async Task<Member> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
            await _dbContext
                .Set<Member>()
                .FirstOrDefaultAsync(member => member.Id == id, cancellationToken);

        public async Task<Member> GetByIdWithDapperAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await using SqlConnection sqlConnection = _connectionFactory.CreateConnection();

            Member member = await sqlConnection
                 .QueryFirstOrDefaultAsync<Member>(
                 @"SELECT Id, Email, FirstName, LastName 
                   FROM Members
                   WHERE Id = @MemberId",
                  new
                  {
                      id
                  });

            return member;
        }

        //public async Task<Member> GetByEmailAsync(Email email, CancellationToken cancellationToken = default) =>
        //     await _dbContext
        //        .Set<Member>()
        //        .FirstOrDefaultAsync(member => member.Email == email, cancellationToken);

        //public async Task<bool> IsEmailUniqueAsync(
        //    Email email,
        //    CancellationToken cancellationToken = default) =>
        //    !await _dbContext
        //        .Set<Member>()
        //        .AnyAsync(member => member.Email == email, cancellationToken);

        public void Add(Member member) =>
            _dbContext.Set<Member>().Add(member);

        public void Update(Member member) =>
            _dbContext.Set<Member>().Update(member);
    }
}
