using DeltaFit.Api.Application.Abstractions.Messaging;

namespace DeltaFit.Api.Application.Members.Commands.CreateMember
{
    public sealed record CreateMemberCommand(
        string Email,
        string FirstName,
        string LastName,
        string Password) : ICommand<Guid>;
}
