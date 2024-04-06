using Eencyclopedia.Application.Abstractions;
using Eencyclopedia.Domain.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Eencyclopedia.API.Controllers;

[ApiController]
[Route("api/books")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<List<BookDto>> GetAllBooks()
    {
        var books = await _bookService.GetAllBooks();

        return books;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<BookDto>> GetSingle(Guid id)
    {
        var book = await _bookService.GetSingleBook(id);

        return Ok(book);
    }

    [HttpGet("genre")]
    public async Task<ActionResult<List<BookDto>>> GetBookByGenre([FromBody] GetByGenreDto request)
    {
        try
        {
            var books = await _bookService.GetByConditionals(request);

            return books;
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateBook([FromBody] CreateBookDto request)
    {
        await _bookService.CreateBook(request);

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBook([FromBody] UpdateBookDto request)
    {
        try
        {
            await _bookService.UpdateBook(request);

            return Ok();
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
            
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteBook(Guid id)
    {
        try
        {
            await _bookService.DeleteBook(id);
            
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("image")]
    public async Task<IActionResult> AddBookImage([FromForm(Name = "Image")] AddBookImageDto addBookImageDto)
    {
        try
        {
            await _bookService.AddBookImage(addBookImageDto);

            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}