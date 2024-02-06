﻿//using DeltaFit.Api.Application.Abstractions.Messaging;
//using DeltaFit.Api.Application.Members.Commands.CreateMember;
//using DeltaFit.Api.Domain.Errors;
//using DeltaFit.Api.Domain.Repositories;
//using DeltaFit.Api.Domain.Shared;
//using DeltaFit.Api.Infrastructure.Cryptography;

//namespace DeltaFit.Api.Application.Trainers.Commands.CreateTrainer
//{
//    public class CreateTrainerCommandHandler : ICommandHandler<CreateTrainerCommand, Guid>
//    {
//        private readonly IMemberRepository _memberRepository;
//        private readonly IUnitOfWork _unitOfWork;

//        public CreateTrainerCommandHandler(
//            IMemberRepository memberRepository,
//            IUnitOfWork unitOfWork)
//        {
//            _memberRepository = memberRepository;
//            _unitOfWork = unitOfWork;
//        }

//        public async Task<Result<Guid>> Handle(CreateTrainerCommand request, CancellationToken cancellationToken)
//        {
//            //Result<Email> emailResult = Email.Create(request.Email);
//            //Result<FirstName> firstNameResult = FirstName.Create(request.FirstName);
//            //Result<LastName> lastNameResult = LastName.Create(request.LastName);
//            var emailResult = request.NameOfWork;
//            var firstNameResult = request.TypeDocument;
//            //var lastNameResult = request.LastName;
//            //var passwordResult = request.Password;


//            if (!await _memberRepository.IsEmailUniqueAsync(emailResult, cancellationToken))
//            {
//                return Result.Failure<Guid>(DomainErrors.Member.EmailAlreadyInUse);
//            }

//            //different approach
//            //var isEmailUniqueAsync = await _memberRepository
//            //       .IsEmailUniqueAsync(emailResult.Value, cancellationToken);

//            //if (passwordResult is null)
//            //{
//            //    //"Senha precisa ser preenchida"
//            //    return Result.Failure<Guid>(DomainErrors.Member.EmailAlreadyInUse);
//            //}

//            //var criptography = Hashing.DoCompute(passwordResult);

//            //var member = Member.Create(
//            //    Guid.NewGuid(),
//            //    emailResult,
//            //    firstNameResult,
//            //    lastNameResult,
//            //    criptography.Hash,
//            //    criptography.Salt
//            //    /*isEmailUniqueAsync*/);

//            _memberRepository.Add(member);

//            await _unitOfWork.SaveChangesAsync(cancellationToken);

//            return member.Id;
//        }
//    }
//}
