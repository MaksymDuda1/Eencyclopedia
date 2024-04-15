using Eencyclopedia.Domain.DTOs;

namespace Eencyclopedia.Application.Abstractions;

public interface IUserService
{
    Task<List<UserDto>> GetAll();
    Task<List<BookDto>> GetFavoriteBooks(Guid id);
    Task AddBookToFavorite(FavoriteBooksDto addBookToFavoritesDto);
    Task<bool> IsInFavorite(FavoriteBooksDto favoriteBooksDto);
    Task Delete(Guid id);
}