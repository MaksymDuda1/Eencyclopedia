using Eencyclopedia.Application.Abstractions;
using Eencyclopedia.Domain.DTOs;
using Eencyclopedia.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Eencyclopedia.API.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<List<UserDto>> GetAll()
    {
        return await _userService.GetAll();
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<List<BookDto>>> GetFavoriteBooks(Guid id)
    {
        try
        {
            var books = await _userService.GetFavoriteBooks(id);

            return Ok(books);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPut("addToFavorites")]
    public async Task<IActionResult> AddBookToFavorite([FromBody] AddBookToFavoritesDto request)
    {
        try
        {
            await _userService.AddBookToFavorite(request);

            return Ok();
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}