namespace DeltaFit.Application.Users.Responses
{
    public sealed record UserResponse(
        Guid Id,
        string Email,
        string Phone,
        string FirstName,
        string LastName);
}
