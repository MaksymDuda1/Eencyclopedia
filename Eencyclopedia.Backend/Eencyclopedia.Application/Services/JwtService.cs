using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Eencyclopedia.Application.Abstractions;
using Eencyclopedia.Application.Models;
using Eencyclopedia.Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Eencyclopedia.Application.Services;

public class JwtService : IJwtService
{
    private readonly IConfiguration _configuration;
    private readonly EencyclopediaDbContext _context;

    public JwtService(IConfiguration configuration, 
        EencyclopediaDbContext context)
    {
        _configuration = configuration;
        _context = context;
    }
    
    public string CreateToken(IList<Claim> claims)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtSecret = _configuration["jwtSecret"]!;
        var key = Encoding.ASCII.GetBytes(jwtSecret);
        var identity = new ClaimsIdentity(claims);

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = identity,
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        
        return tokenHandler.WriteToken(token);
    }

    public void AddRolesToClaims(IList<Claim> claims, IList<string> roles)
    {
        foreach (var role in roles)
        {
            var roleClaims = new Claim(ClaimTypes.Role, role);
            claims.Add(roleClaims);
        }
    }
}