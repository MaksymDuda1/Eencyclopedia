using Eencyclopedia.Domain.DTOs;

namespace Eencyclopedia.Application.Abstractions;

public interface IBookService
{
    Task<List<BookDto>> GetAllBooks();
    Task<BookDto> GetSingleBook(Guid id);
    Task<List<BookDto>> GetByConditionals(GetByGenreDto getByGenreDto);
    Task CreateBook(CreateBookDto book);
    Task UpdateBook(UpdateBookDto updateBookDto);
    Task DeleteBook(Guid id);
}