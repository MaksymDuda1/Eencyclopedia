using Eencyclopedia.Application.Models;
using Eencyclopedia.Domain.DTOs;

namespace Eencyclopedia.Application.Services;

public interface IAuthorizationService
{
    Task<TokenModel> LoginUser(LoginDto loginDto);
    Task<TokenModel> RegisterUser(RegistrationDto registrationDto);
}