using Eencyclopedia.Domain.DTOs;
using Eencyclopedia.Domain.Enums;

namespace Eencyclopedia.Application.Abstractions;

public interface IBookService
{
    Task<List<BookDto>> GetAllBooks();
    Task<BookDto> GetSingleBook(Guid id);
    Task<List<BookDto>> GetByConditionals(int genre);
    Task<BookDto> CreateBook(CreateBookDto book);
    Task<BookDto> UpdateBook(UpdateBookDto updateBookDto);
    Task DeleteBook(Guid id);
}