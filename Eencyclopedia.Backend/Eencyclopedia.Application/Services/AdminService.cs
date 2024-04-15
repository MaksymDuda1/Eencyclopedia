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
    public async Task ChangeUserRole(ChangeRoleDto changeRoleDto)
    {
        var user = await _userManager.FindByIdAsync(changeRoleDto.UserId.ToString());

        if (user == null)
            throw new Exception("User does not exist");
        
        var claims =await _userManager.GetClaimsAsync(user);
        var currentRoles = await _userManager.GetRolesAsync(user);

        if (currentRoles.Contains("Admin"))
        {
            await _userManager.RemoveFromRoleAsync(user, "Admin");
            await _userManager.AddToRoleAsync(user, "User");
        }
        else 
        {
            await _userManager.RemoveFromRoleAsync(user, "User");
            await _userManager.AddToRoleAsync(user, "Admin");
        }

        /*await _userManager.ReplaceClaimAsync(user, claims.FirstOrDefault(x => x.Type == JwtClaimTypes.Role),
            new Claim(JwtClaimTypes.Role, role.Name));*/
        await _userManager.UpdateAsync(user);
    }
}