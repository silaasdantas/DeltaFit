using DeltaFit.Api.Application.Abstractions.Messaging;

namespace DeltaFit.Api.Application.Members.Commands.Login
{
    public record LoginCommand(string Email, string Password) : ICommand<string>;
}
