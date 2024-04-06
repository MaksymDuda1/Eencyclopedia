using Eencyclopedia.Application.Abstractions;
using Eencyclopedia.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Eencyclopedia.API.Controllers;

[ApiController]
[Route("api/admin")]
public class AdminController: ControllerBase
{
    private readonly IAdminService _adminService;

    public AdminController(IAdminService adminService)
    {
        _adminService = adminService;
    }

    [HttpPut]
    public async Task<IActionResult> ChangeUserRole(UserDto userDto)
    {
        try
        {
            await _adminService.ChangeUserRole(userDto);

            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}