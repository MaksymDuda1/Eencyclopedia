using Eencyclopedia.Domain.DTOs;

namespace Eencyclopedia.Application.Abstractions;

public interface IAdminService
{
    Task ChangeUserRole(UserDto userDto);
}