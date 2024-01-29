using DeltaFit.Api.Domain.Shared;
using MediatR;

namespace DeltaFit.Api.Application.Abstractions.Messaging
{
    public interface IQueryHandler<TQuery, TResponse>
        : IRequestHandler<TQuery, Result<TResponse>>
        where TQuery : IQuery<TResponse>
    {
    }
}
