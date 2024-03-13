
using DeltaFit.Api.Application.Abstractions.Messaging;
using DeltaFit.Api.Domain.Entities;
using DeltaFit.Api.Domain.Errors;
using DeltaFit.Api.Domain.Repositories;
using DeltaFit.Api.Domain.Shared;
using DeltaFit.Api.Domain.ValueObjects;
using DeltaFit.Api.Infrastructure.Cryptography;

namespace DeltaFit.Api.Application.Members.Commands.CreateMember
{
    internal sealed class CreateMemberCommandHandler : ICommandHandler<CreateMemberCommand, Guid>
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateMemberCommandHandler(
            IMemberRepository memberRepository,
            IUnitOfWork unitOfWork)
        {
            _memberRepository = memberRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
        {
            Result<Email> emailResult = Email.Create(request.Email);
            Result<FirstName> firstNameResult = FirstName.Create(request.FirstName);
            Result<LastName> lastNameResult = LastName.Create(request.LastName);
            Result<Phone> phoneResult = Phone.Create(request.Phone);
            Result<Phone> passwordResult = Phone.Create(request.Password);

            if (!await _memberRepository.IsEmailUniqueAsync(emailResult.Value, cancellationToken))
            {
                return Result.Failure<Guid>(DomainErrors.Member.EmailAlreadyInUse);
            }

            if (!await _memberRepository.IsPhoneUniqueAsync(phoneResult.Value, cancellationToken))
            {
                return Result.Failure<Guid>(DomainErrors.Member.PhoneAlreadyInUse);
            }      

            var (Hash, Salt) = Hashing.DoCompute(passwordResult.Value.Value);

            var member = Member.Create(
                Guid.NewGuid(),
                emailResult.Value,
                phoneResult.Value,
                firstNameResult.Value,
                lastNameResult.Value,
                Hash,
                Salt
                /*isEmailUniqueAsync*/);

            _memberRepository.Add(member);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return member.Id;
        }
    }
}
