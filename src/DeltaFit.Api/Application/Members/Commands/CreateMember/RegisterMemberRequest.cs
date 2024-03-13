namespace DeltaFit.Api.Application.Members.Commands.CreateMember
{
    public sealed record RegisterMemberRequest(
        string Email,
        string Phone,
        string FirstName,
        string LastName,
        string Password);
}
