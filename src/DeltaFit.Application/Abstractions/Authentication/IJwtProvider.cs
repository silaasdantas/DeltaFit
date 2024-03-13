using DeltaFit.Application.Login;

namespace DeltaFit.Application.Abstractions.Authentication
{
    public interface IJwtProvider
    {
        Jwt GenerateToken(LoginCommand command);
    }
}
