namespace DeltaFit.Api.Application.Members.Queries
{
    public sealed record MemberResponse(
    Guid Id,
    string Email,
    string FirstName,
    string LastName);
}
