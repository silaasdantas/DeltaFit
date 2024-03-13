using FluentValidation;

namespace DeltaFit.Api.Application.Members.Commands.CreateMember
{
    internal class CreateMemberCommandValidator : AbstractValidator<CreateMemberCommand>
    {
        public CreateMemberCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty();

            RuleFor(x => x.Phone).NotEmpty();

            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);

            RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);

            RuleFor(x => x.Password).NotEmpty().MaximumLength(16);

        }
    }
}