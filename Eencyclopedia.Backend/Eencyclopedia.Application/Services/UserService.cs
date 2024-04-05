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
    IMapper _mapper) : IUserService
{
    public async Task<List<UserDto>> GetAll()
    {
        var users = await _unitOfWork.Users.GetAllAsync(u => u.FavoriteBooks);

        return users.Select(_mapper.Map<UserDto>).ToList();
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

    public async Task AddBookToFavorite(AddBookToFavoritesDto addBookToFavoritesDto)
    {
        var user = await _unitOfWork.Users.GetSingleByConditionAsync(
            u => u.Id == addBookToFavoritesDto.UserId);

        var book = await _unitOfWork.Books.GetSingleByConditionAsync(
            b => b.Id == addBookToFavoritesDto.BookId);

        if (user == null)
            throw new Exception("User not found.");

        if (book == null)
            throw new Exception("Book not found.");

        var existingAssociation = await _unitOfWork.BooksUsers.GetSingleByConditionAsync(
            bu => bu.UserId == user.Id && bu.BookId == book.Id);

        if (existingAssociation != null)
            throw new Exception("The book is already in the user's favorite books list.");

        var newAssociation = new BookUser
        {
            UserId = user.Id,
            BookId = book.Id
        };

        await _unitOfWork.BooksUsers.InsertAsync(newAssociation);
        await _unitOfWork.SaveAsync();
    }
}