namespace DeltaFit.Application.Login
{
    public record LoginCommand(int Type, string Name, string Email, string Password);
}
