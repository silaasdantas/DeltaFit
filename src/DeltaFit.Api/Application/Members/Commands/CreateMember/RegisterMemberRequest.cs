namespace DeltaFit.Api.Application.Members.Commands.CreateMember
{
    public sealed record RegisterMemberRequest(
        string Email,
        string FirstName,
        string LastName,
        string Password);
}
