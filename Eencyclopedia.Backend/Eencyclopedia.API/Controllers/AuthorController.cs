using Eencyclopedia.Application.Abstractions;
using Eencyclopedia.Domain.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Eencyclopedia.API.Controllers;

[ApiController]
[Route("api/authors")]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpGet]
    public async Task<ActionResult<List<AuthorDto>>> GetAllAuthors()
    {
        var authors = await _authorService.GetAllAsync();
        
        return Ok(authors);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAuthor([FromBody] AuthorDto request)
    {
        await _authorService.CreateAuthor(request);
        
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAuthor(Guid id)
    {
        await _authorService.Delete(id);

        return Ok();
    }
}