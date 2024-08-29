using Microsoft.AspNetCore.Http;

namespace Vuba.Domain.Interfaces
{
    public interface IJwtAuthenticationService
    {
        string GenerateToken(int AccountId);
        void SetTokenCookie(HttpContext context, string token);
        int GetTokenInfo(HttpRequest Request);
    }
}
