using AutoMapper;
using Eencyclopedia.Application.Abstractions;
using Eencyclopedia.Domain.Abstractions;
using Eencyclopedia.Domain.DTOs;

namespace Eencyclopedia.Application.Services;

public class SearchEngineService(IUnitOfWork _unitOfWork, IMapper _mapper) : ISearchEngineService
{
    public async Task<List<BookDto>> BookSearch(SearchEngineDto searchEngineDto)
    {
        var books = await _unitOfWork.Books
            .GetAllAsync(b => b.Authors,
                b => b.Publisher,
                b => b.Users);

        var matchingBooks = _mapper.Map<List<BookDto>>(books.Where(b =>
            b.Name.Contains(searchEngineDto.SearchQuery, StringComparison.InvariantCultureIgnoreCase)));
        
        return matchingBooks;
    }
}