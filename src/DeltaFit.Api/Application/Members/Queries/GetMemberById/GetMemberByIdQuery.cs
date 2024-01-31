using DeltaFit.Api.Application.Abstractions.Messaging;

namespace DeltaFit.Api.Application.Members.Queries.GetMemberById
{
    public sealed record GetMemberByIdQuery(Guid MemberId) : IQuery<MemberResponse>;
}
