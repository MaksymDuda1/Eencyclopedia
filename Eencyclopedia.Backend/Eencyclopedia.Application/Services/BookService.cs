using AutoMapper;
using Eencyclopedia.Application.Abstractions;
using Eencyclopedia.Domain.Abstractions;
using Eencyclopedia.Domain.DTOs;
using Eencyclopedia.Domain.Entities;

namespace Eencyclopedia.Application.Services;

public class BookService(IUnitOfWork unitOfWork, IMapper mapper) : IBookService
{
    public async Task<List<BookDto>> GetAllBooksAsync()
    {
        var books = await unitOfWork.Books.GetAllAsync();

        var result = books.Select(mapper.Map<BookDto>);

        return result.ToList();
    }

    public async Task CreateBook(BookDto book)
    {
        await unitOfWork.Books.InsertAsync(mapper.Map<Book>(book));
    }
}