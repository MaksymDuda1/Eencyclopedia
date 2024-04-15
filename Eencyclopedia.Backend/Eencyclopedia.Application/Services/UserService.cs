using AutoMapper;
using Eencyclopedia.Application.Abstractions;
using Eencyclopedia.Domain.Abstractions;
using Eencyclopedia.Domain.DTOs;
using Eencyclopedia.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace Eencyclopedia.Application.Services;

public class UserService(
    IUnitOfWork _unitOfWork,
    IMapper _mapper, UserManager<User> _userManager) : IUserService
{
    public async Task<List<UserDto>> GetAll()
    {
        var users = await _unitOfWork.Users.GetAllAsync(u => u.FavoriteBooks);
        var usersDto = users.Select(_mapper.Map<UserDto>).ToList();
        
        foreach (var user in usersDto)
        {
            var role =  await _userManager.GetRolesAsync(_mapper.Map<User>(user));

            user.IsAdmin = role.Contains("Admin");
        }

        return usersDto;
    }
    
    public async Task<List<BookDto>> GetFavoriteBooks(Guid id)
    {
        var user = _mapper.Map<UserDto>(await _unitOfWork.Users
            .GetSingleByConditionAsync(u => u.Id == id,
                u => u.FavoriteBooks,
                u => u.BooksUsers));
        
        var favoriteBooks = user.FavoriteBooks;

        if (favoriteBooks == null)
            throw new Exception("Your favorite books list is empty");
        
        return favoriteBooks;
    }

    public async Task AddBookToFavorite(FavoriteBooksDto addBookToFavoritesDto)
    {
        var user = await _unitOfWork.Users.GetSingleByConditionAsync(
            u => u.Id == addBookToFavoritesDto.UserId,
            u => u.FavoriteBooks);

        var book = await _unitOfWork.Books.GetSingleByConditionAsync(
            b => b.Id == addBookToFavoritesDto.BookId);

        if (user == null)
            throw new Exception("User not found.");

        if (book == null)
            throw new Exception("Book not found.");

        var existingAssociation = await _unitOfWork.BooksUsers.GetSingleByConditionAsync(
            bu => bu.UserId == user.Id && bu.BookId == book.Id);

        if (existingAssociation != null)
        {
            await _unitOfWork.BooksUsers.Delete(existingAssociation);
        }
        else
        {
            var newAssociation = new BookUser
            {
                UserId = user.Id,
                BookId = book.Id
            };

            await _unitOfWork.BooksUsers.InsertAsync(newAssociation);            
        }

        await _unitOfWork.SaveAsync();
    }

    public async Task<bool> IsInFavorite(FavoriteBooksDto favoriteBooksDto)
    {
        var book = await _unitOfWork.Books
            .GetSingleByConditionAsync(b => b.Id == favoriteBooksDto.BookId,
                b => b.Users);
        
        return book.Users.Any(u => u.Id == favoriteBooksDto.UserId);
    }

    public async Task Delete(Guid id)
    {
        await _unitOfWork.Users.Delete(id);
        await _unitOfWork.SaveAsync();
    }
}