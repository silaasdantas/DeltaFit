using Dapper;
using DeltaFit.Domain.Entities;
using DeltaFit.Domain.Repositories;
using DeltaFit.Domain.ValueObjects;
using DeltaFit.Persistence.Abstractions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DeltaFit.Persistence.Respositories
{
    public sealed class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ISqlConnectionFactory _connectionFactory;

        public UserRepository(
            ApplicationDbContext dbContext,
            ISqlConnectionFactory connectionFactory)
        {
            _dbContext = dbContext;
            _connectionFactory = connectionFactory;
        }

        public async Task<List<User>> GetUsersAsync(CancellationToken cancellationToken = default)
            => await _dbContext.Set<User>().ToListAsync(cancellationToken);

        public async Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
            => await _dbContext
                    .Set<User>()
                    .FirstOrDefaultAsync(user => user.Id == id, cancellationToken);

        public async Task<User> GetByIdWithDapperAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await using SqlConnection sqlConnection = _connectionFactory.CreateConnection();

            User user = await sqlConnection
                 .QueryFirstOrDefaultAsync<User>(
                 @"SELECT Id, Email, FirstName, LastName, Phone
                   FROM Users
                   WHERE Id = @UserId",
                  new
                  {
                      id
                  });

            return user;
        }

        public async Task<User> GetByEmailAsync(Email email, CancellationToken cancellationToken = default) =>
             await _dbContext.Set<User>()
                .FirstOrDefaultAsync(user => user.Email == email, cancellationToken);

        public async Task<bool> IsEmailUniqueAsync(
            Email email,
            CancellationToken cancellationToken = default)
            => !await _dbContext
                .Set<User>()
                .AnyAsync(user => user.Email == email, cancellationToken);

        public void Add(User user)
            => _dbContext.Set<User>().Add(user);

        public void Update(User user)
            => _dbContext.Set<User>().Update(user);

        public async Task<bool> IsPhoneUniqueAsync(
            Phone phone,
            CancellationToken cancellationToken = default)
            => !await _dbContext
                    .Set<User>()
                    .AnyAsync(user => user.Phone == phone, cancellationToken);

    }
}
