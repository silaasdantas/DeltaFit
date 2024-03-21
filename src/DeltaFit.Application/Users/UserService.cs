using DeltaFit.Application.Services;
using DeltaFit.Application.Users.Commands;
using DeltaFit.Application.Users.Responses;
using DeltaFit.Domain.Entities;
using DeltaFit.Domain.Errors;
using DeltaFit.Domain.Repositories;
using DeltaFit.Domain.Shared;
using DeltaFit.Domain.ValueObjects;
using DeltaFit.Infrastructure.Cryptography;

namespace DeltaFit.Application.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(
            IUserRepository userRepository,
            IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<UserResponse>> GetUserByIdQuery(Guid id, CancellationToken cancellationToken)
        {
            var dbUser = await _userRepository.GetByIdWithDapperAsync(
                id,
                cancellationToken);

            if (dbUser is null)
            {
                return Result.Failure<UserResponse>(DomainErrors.User.NotFound(id));
            }

            var response = new UserResponse(dbUser.Id, dbUser.Email.Value, dbUser.Phone.Value, dbUser.FirstName.Value, dbUser.LastName.Value);

            return response;
        }

        public async Task<Result<Guid>> CreateUser(CreateUserCommand request, CancellationToken cancellationToken)
        {
            Result<Email> emailResult = Email.Create(request.Email);
            Result<FirstName> firstNameResult = FirstName.Create(request.FirstName);
            Result<LastName> lastNameResult = LastName.Create(request.LastName);
            Result<Phone> phoneResult = Phone.Create(request.Phone);
            Result<Phone> passwordResult = Phone.Create(request.Password);

            if (!await _userRepository.IsEmailUniqueAsync(emailResult.Value, cancellationToken))
            {
                return Result.Failure<Guid>(DomainErrors.User.EmailAlreadyInUse);
            }

            if (!await _userRepository.IsPhoneUniqueAsync(phoneResult.Value, cancellationToken))
            {
                return Result.Failure<Guid>(DomainErrors.User.PhoneAlreadyInUse);
            }

            var (Hash, Salt) = Hashing.DoCompute(passwordResult.Value.Value);

            var user = User.Create(
                Guid.NewGuid(),
                emailResult.Value,
                phoneResult.Value,
                firstNameResult.Value,
                lastNameResult.Value,
                Hash,
                Salt
                );

            _userRepository.Add(user);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return user.Id;
        }

    }
}
