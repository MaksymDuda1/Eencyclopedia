using System.Security.Claims;
using AutoMapper;
using Eencyclopedia.Application.Abstractions;
using Eencyclopedia.Domain.DTOs;
using Eencyclopedia.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Eencyclopedia.Application.Services;

public class AdminService(UserManager<User> _userManager) : IAdminService
{
    public async Task ChangeUserRole(UserDto userDto)
    {
        var user = await _userManager.FindByIdAsync(userDto.Id.ToString());

        if (user == null)
            throw new Exception("User does not exist");

        var currentRoles = await _userManager.GetRolesAsync(user);

        if (currentRoles.Contains("Admin"))
        {
            await _userManager.RemoveFromRoleAsync(user, "Admin");
            await _userManager.AddToRoleAsync(user, "User");
        }
        else if (currentRoles.Contains("User"))
        {
            await _userManager.RemoveFromRoleAsync(user, "User");
            await _userManager.AddToRoleAsync(user, "Admin");
        }

        await _userManager.UpdateAsync(user);
    }
}