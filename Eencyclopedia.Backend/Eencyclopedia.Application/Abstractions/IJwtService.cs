using System.Security.Claims;

namespace Eencyclopedia.Application.Services;

public interface IJwtService
{
    string CreateToken(IList<Claim> claims);
    void AddRolesToClaims(List<Claim> claims, IList<string> roles);
}