using DeltaFit.Api.Application.Abstractions.Messaging;

namespace DeltaFit.Api.Application.Members.Queries.GetMembers
{
    public sealed record class GetMembersQuery(int Page, int PageSize) : IQuery<List<MemberResponse>>;
}
