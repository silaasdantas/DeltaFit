namespace DeltaFit.Api.Contracts.Users
{
    public sealed record RegisterUserRequest(
        string Email,
        string Phone,
        string FirstName,
        string LastName,
        string Password);
}
