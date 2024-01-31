using DeltaFit.Api.Application.Abstractions;
using DeltaFit.Api.Application.Abstractions.Messaging;
using DeltaFit.Api.Domain.Entities;
using DeltaFit.Api.Domain.Errors;
using DeltaFit.Api.Domain.Repositories;
using DeltaFit.Api.Domain.Shared;
using DeltaFit.Api.Infrastructure.Cryptography;
using System.Security.Cryptography;
using System.Text;

namespace DeltaFit.Api.Application.Members.Commands.Login
{
    internal sealed class LoginCommandHandler
         : ICommandHandler<LoginCommand, string>
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IJwtProvider _jwtProvider;

        public LoginCommandHandler(IMemberRepository memberRepository,
            IJwtProvider jwtProvider)
        {
            _memberRepository = memberRepository;
            _jwtProvider = jwtProvider;
        }
        public async Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var email = request.Email;
            //Result<Email> email = Email.Create(request.Email);

            Member member = await _memberRepository.GetByEmailAsync(
                email,
                cancellationToken);

            if (member is null)
            {
                return Result.Failure<string>(
                    DomainErrors.Member.InvalidCredentials);
            }

            var computedHash = Hashing.DoCompute(request.Password, member.PasswordSalt);
            
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != member.PasswordHash[i])
                    return Result.Failure<string>(
                        DomainErrors.Member.InvalidCredentials);
            }

            string token = await _jwtProvider.GenerateAsync(member);

            return token;
        }
    }
}
