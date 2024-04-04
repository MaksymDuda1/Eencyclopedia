using System.Security.Claims;

namespace Eencyclopedia.Application.Abstractions;

public interface IJwtService
{
    string CreateToken(IList<Claim> claims);
    void AddRolesToClaims(IList<Claim> claims, IList<string> roles);
}