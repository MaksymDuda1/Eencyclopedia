using Eencyclopedia.Domain.DTOs;

namespace Eencyclopedia.Application.Abstractions;

public interface IUserService
{
    Task<List<UserDto>> GetAll();
    Task<List<BookDto>> GetFavoriteBooks(Guid id);
    Task AddBookToFavorite(AddBookToFavoritesDto addBookToFavoritesDto);
}