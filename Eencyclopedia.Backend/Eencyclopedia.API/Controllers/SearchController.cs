using Eencyclopedia.Application.Abstractions;
using Eencyclopedia.Application.Services;
using Eencyclopedia.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Eencyclopedia.API.Controllers;

[ApiController]
[Route("api/search")]
public class SearchController : ControllerBase
{
    private readonly ISearchEngineService _searchEngineService;

    public SearchController(ISearchEngineService searchEngineService)
    {
        _searchEngineService = searchEngineService;
    }

    [HttpGet]
    public async Task<ActionResult<List<BookDto>>> SearchBooks([FromQuery] SearchEngineDto searchEngineDto)
    {
        var books = await _searchEngineService.BookSearch(searchEngineDto);

        return Ok(books);
    }
}