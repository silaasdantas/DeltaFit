using DeltaFit.Api.Domain.Shared;
using MediatR;

namespace DeltaFit.Api.Application.Abstractions.Messaging
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
