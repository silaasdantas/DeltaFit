using DeltaFit.Api.Domain.Shared;
using MediatR;

namespace DeltaFit.Api.Application.Abstractions.Messaging
{
    public interface ICommand : IRequest<Result>
    {
    }

    public interface ICommand<TResponse> : IRequest<Result<TResponse>>
    {

    }
}
