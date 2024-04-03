using Eencyclopedia.Application.Abstractions;
using Eencyclopedia.Application.Models;
using Eencyclopedia.Domain.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Eencyclopedia.API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthorizationService _authorizationService;

    public AuthController(IAuthorizationService authorizationService)
    {
        _authorizationService = authorizationService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<TokenModel>> Login([FromBody] LoginDto request)
    {
        try
        {
            var token = await _authorizationService.LoginUser(request);

            return Ok(token);
        }
        catch (Exception e)
        {
            return Unauthorized(e.Message);
        }
    }

    [HttpPost("registration")]
    public async Task<ActionResult<TokenModel>> Registration([FromBody] RegistrationDto request)
    {
        try
        {
            var token = await _authorizationService.RegisterUser(request);

            return Ok(token);
        }
        catch (Exception e)
        {
            return Unauthorized(e.Message);
        }
    }
}