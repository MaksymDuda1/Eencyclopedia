using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Eencyclopedia.Application.Abstractions;
using Eencyclopedia.Application.Models;
using Eencyclopedia.Domain.DTOs;
using Eencyclopedia.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Eencyclopedia.Application.Services;

public class AuthorizationService : IAuthorizationService
{
    private readonly IJwtService _jwtService;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AuthorizationService(IJwtService jwtService,
        UserManager<User> userManager,
        SignInManager<User> signInManager)
    {
        _jwtService = jwtService;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<TokenModel> LoginUser(LoginDto loginDto)
    {
        var user = await _userManager.FindByEmailAsync(loginDto.Email);

        if (user is null)
            throw new Exception("User doesn't exist");

        var result = await _signInManager
            .PasswordSignInAsync(user, loginDto.Password, false, false);

        if (!result.Succeeded)
            throw new Exception("Incorrect login or password");

        var roles = await _userManager.GetRolesAsync(user);

        foreach (var role in roles)
        {
            Console.WriteLine(role);
        }
        
        var claims = await _userManager.GetClaimsAsync(user);
        _jwtService.AddRolesToClaims(claims, roles);
        var token = _jwtService.CreateToken(claims);

        await _userManager.UpdateAsync(user);

        return new TokenModel()
        {
            Token = token
        };
    }

    public async Task<TokenModel> RegisterUser(RegistrationDto registrationDto)
    {
        string userName = registrationDto.Email.Substring(0, registrationDto.Email.IndexOf('@'));

        var user = new User()
        {
            Id = Guid.NewGuid(),
            UserName = userName,
            Email = registrationDto.Email,
            FullName = registrationDto.FullName
        };

        var result = await _userManager.CreateAsync(user, registrationDto.Password);

        if (!result.Succeeded)
            throw new Exception(result.Errors.First().Description);

        await _userManager.AddToRoleAsync(user, "USER");
        
        var roles = await _userManager.GetRolesAsync(user);
        var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email, user.Email),
            new(JwtRegisteredClaimNames.Jti, user.Id.ToString())
        };
        
        _jwtService.AddRolesToClaims(authClaims, roles);

        var token = _jwtService.CreateToken(authClaims);

        return new TokenModel()
        {
            Token = token
        };
    }
}