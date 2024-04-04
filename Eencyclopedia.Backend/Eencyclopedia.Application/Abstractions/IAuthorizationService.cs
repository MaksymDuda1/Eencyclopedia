using Eencyclopedia.Application.Models;
using Eencyclopedia.Domain.DTOs;

namespace Eencyclopedia.Application.Abstractions;

public interface IAuthorizationService
{
    Task<TokenModel> LoginUser(LoginDto loginDto);
    Task<TokenModel> RegisterUser(RegistrationDto registrationDto);
}