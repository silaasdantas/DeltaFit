using DeltaFit.Api.Domain.Entities;

namespace DeltaFit.Api.Application.Abstractions
{
    public interface IJwtProvider
    {
        Task<string> GenerateAsync(Member member);
    }
}
