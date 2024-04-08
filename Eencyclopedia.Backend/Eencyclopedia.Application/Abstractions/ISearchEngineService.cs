using Eencyclopedia.Domain.DTOs;

namespace Eencyclopedia.Application.Abstractions;

public interface ISearchEngineService
{
    Task<List<BookDto>> BookSearch(SearchEngineDto searchEngineDto);
}