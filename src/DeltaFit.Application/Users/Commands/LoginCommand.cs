namespace DeltaFit.Application.Users.Commands
{
    public record LoginCommand(int Type, string Name, string Email, string Password);
}
