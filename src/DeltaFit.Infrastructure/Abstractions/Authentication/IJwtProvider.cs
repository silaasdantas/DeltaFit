using DeltaFit.Domain.Entities;

namespace DeltaFit.Infrastructure.Abstractions.Authentication
{
    public interface IJwtProvider
    {
        Jwt GenerateToken(User user);
    }
}
