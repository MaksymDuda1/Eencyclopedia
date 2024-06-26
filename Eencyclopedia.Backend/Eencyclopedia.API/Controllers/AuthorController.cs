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
        var authors = await _authorService.GetAllAuthors();

        return Ok(authors);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<AuthorDto>> GetSingle(Guid id)
    {
        try
        {
            var author = await _authorService.GetSingleAuthor(id);

            return Ok(author);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<CreateAuthorDto>> CreateAuthor([FromForm] CreateAuthorDto request)
    {
        try
        {
            var author = await _authorService.CreateAuthor(request);

            return Ok(author);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult<CreateAuthorDto>>  UpdateAuthor([FromForm] UpdateAuthorDto request)
    {
        try
        {
            var author = await _authorService.UpdateAuthor(request);

            return Ok(author);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAuthor(Guid id)
    {
        await _authorService.Delete(id);

        return Ok();
    }
}