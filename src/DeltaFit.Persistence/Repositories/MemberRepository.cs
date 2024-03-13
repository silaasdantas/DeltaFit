using Dapper;
using DeltaFit.Api.Application.Abstractions;
using DeltaFit.Api.Domain.Entities;
using DeltaFit.Api.Domain.Repositories;
using DeltaFit.Api.Domain.ValueObjects;
using DeltaFit.Api.Infrastructure.Cryptography;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DeltaFit.Persistence.Repositories
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
                //_dbContext.Permissions.Add(new Permission() { Id = 1, Name = "Read" });
                //_dbContext.Permissions.Add(new Permission() { Id = 2, Name = "Update" });

                //_dbContext.Roles.Add(new Role(1, "Admin"));
                //_dbContext.Roles.Add(new Role(2, "PersonalTrainer"));
                //_dbContext.Roles.Add(new Role(3, "Customer"));


                //_dbContext.RolePermissions.Add(new RolePermission() { RoleId = 1, PermissionId = 1});
                //_dbContext.RolePermissions.Add(new RolePermission() { RoleId = 1, PermissionId = 2 });

                //_dbContext.RolePermissions.Add(new RolePermission() { RoleId = 2, PermissionId = 1 });
                //_dbContext.RolePermissions.Add(new RolePermission() { RoleId = 2, PermissionId = 2 });

                //_dbContext.RolePermissions.Add(new RolePermission() { RoleId = 3, PermissionId = 1 });


                //var criptography = Hashing.DoCompute("Sdq1w2e3r4@");

                //_dbContext.Members.Add(new Member(
                //    Guid.NewGuid(),
                //    "silas.dantas@gmail.com",
                //    "+5511998877664",
                //    "Silas", "Dantas Pereira",
                //    criptography.Hash,
                //    criptography.Salt));

                //_dbContext.Members.Add(new Member(
                //    Guid.NewGuid(),
                //    "paloma.almeida@gmail.com",
                //    "+5511998877665",
                //    "Paloma",
                //    "Alemida Barros",
                //    criptography.Hash,
                //    criptography.Salt));

                //_dbContext.SaveChanges();
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

        public async Task<Member> GetByEmailAsync(Email email, CancellationToken cancellationToken = default) =>
             await _dbContext
                .Set<Member>()
                .FirstOrDefaultAsync(member => member.Email == email, cancellationToken);

        public async Task<bool> IsEmailUniqueAsync(
            Email email,
            CancellationToken cancellationToken = default) =>
            !await _dbContext
                .Set<Member>()
                .AnyAsync(member => member.Email == email, cancellationToken);

        public void Add(Member member) =>
            _dbContext.Set<Member>().Add(member);

        public void Update(Member member) =>
            _dbContext.Set<Member>().Update(member);

        public async Task<bool> IsPhoneUniqueAsync(
          Phone phone,
          CancellationToken cancellationToken = default) =>
          !await _dbContext
              .Set<Member>()
              .AnyAsync(member => member.Phone == phone, cancellationToken);

    }
}
