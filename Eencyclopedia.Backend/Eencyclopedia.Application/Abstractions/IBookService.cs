using Eencyclopedia.Domain.DTOs;

namespace Eencyclopedia.Application.Abstractions;

public interface IBookService
{
    Task<List<BookDto>> GetAllBooksAsync();
    Task CreateBook(BookDto book);
}