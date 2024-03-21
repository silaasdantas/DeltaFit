using DeltaFit.Application.Users.Commands;
using DeltaFit.Application.Users.Responses;
using DeltaFit.Domain.Shared;

namespace DeltaFit.Application.Services
{
    public interface IUserService
    {
        Task<Result<UserResponse>> GetUserByIdQuery(Guid id, CancellationToken cancellationToken);
        Task<Result<Guid>> CreateUser(CreateUserCommand request, CancellationToken cancellationToken);
    }
}
