using Eencyclopedia.Application.Abstractions;
using Eencyclopedia.Domain.DTOs;
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
        var books = await _bookService.GetAllBooksAsync();

        return books;
    }

    [HttpPost]
    public async Task<IActionResult> CreateBook([FromBody] BookDto request)
    {
        await _bookService.CreateBook(request);

        return Ok();
    }
}