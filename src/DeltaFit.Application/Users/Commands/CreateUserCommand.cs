namespace DeltaFit.Application.Users.Commands
{
    public sealed record CreateUserCommand(
       string Email,
       string Phone,
       string FirstName,
       string LastName,
       string Password); //: ICommand<Guid>;
}
