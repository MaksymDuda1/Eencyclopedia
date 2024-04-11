using Eencyclopedia.Application.Abstractions;
using Eencyclopedia.Domain.DTOs;
using Eencyclopedia.Domain.Enums;
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

    [HttpGet("genre/{genre:int}")]
    public async Task<ActionResult<List<BookDto>>> GetBookByGenre(int genre)
    {
        try
        {
            var books = await _bookService.GetByConditionals(genre);

            return books;
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<BookDto>> CreateBook([FromBody] CreateBookDto request)
    {
        var book = await _bookService.CreateBook(request);

        return Ok(book);
    }

    [HttpPut]
    public async Task<ActionResult<BookDto>> UpdateBook([FromForm] UpdateBookDto request)
    {
        try
        {
            var book = await _bookService.UpdateBook(request);

            return Ok(book);
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

    /*[HttpPut("image")]
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
    }*/
}