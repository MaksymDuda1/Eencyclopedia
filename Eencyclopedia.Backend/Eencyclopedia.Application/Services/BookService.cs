using AutoMapper;
using Eencyclopedia.Application.Abstractions;
using Eencyclopedia.Domain.Abstractions;
using Eencyclopedia.Domain.DTOs;
using Eencyclopedia.Domain.Entities;
using Eencyclopedia.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace Eencyclopedia.Application.Services;

public class BookService(IFileService _fileService, IUnitOfWork _unitOfWork, IMapper _mapper) : IBookService
{
    public async Task<List<BookDto>> GetAllBooks()
    {
        var books = await _unitOfWork.Books.GetAllAsync(
            b => b.Authors,
            b => b.Publisher,
            b => b.Users);

        return books.Select(_mapper.Map<BookDto>).ToList();
    }

    public async Task<BookDto> GetSingleBook(Guid id)
    {
        return _mapper.Map<BookDto>(
            await _unitOfWork.Books.GetSingleByConditionAsync(
                b => b.Id == id,
                b => b.Authors,
                b => b.Publisher,
                b => b.Users));
    }

    public async Task<List<BookDto>> GetByConditionals(int genre)
    {
        var books = await _unitOfWork.Books.GetByConditionsAsync(
            b => b.Genre == (Genre)genre,
            b => b.Authors,
            b => b.Publisher,
            b => b.Users);

        return books.Select(_mapper.Map<BookDto>).ToList();
    }

    public async Task<BookDto> CreateBook(CreateBookDto createBookDto)
    {
        var book = new BookDto()
        {
            Id = Guid.NewGuid(),
            Name = createBookDto.Name,
            Path = createBookDto.Path,
            Description = createBookDto.Description,
            Genre = createBookDto.Genre,
            YearOfEdition = createBookDto.YearOfEdition,
            PageAmount = createBookDto.PageAmount,
        };
        
        book.Image =  _fileService.UploadImage(createBookDto.Image).ToString();
        book.Publisher =_mapper.Map<PublisherDto>(await _unitOfWork.Publishers
            .GetSingleByConditionAsync(p => p.Id == createBookDto.PublisherId));
        
        var bookEntity = _mapper.Map<Book>(book);
        
        foreach (var authorId in createBookDto.Authors)
        {
            await _unitOfWork.AuthorsBooks.InsertAsync(new AuthorBook
            {
                Book = bookEntity,
                AuthorId = authorId
                
            });
        }

        await _unitOfWork.SaveAsync();

        return book;
    }

    public async Task<BookDto> UpdateBook(UpdateBookDto updateBookDto)
    {
        var bookDto = _mapper.Map<BookDto>(await _unitOfWork.Books.GetSingleByConditionAsync(
            b => b.Id == updateBookDto.Id));

        bookDto.Name = updateBookDto.Name;
        bookDto.Path = updateBookDto.Path;
        bookDto.Description = updateBookDto.Description;
        bookDto.Genre = updateBookDto.Genre;
        bookDto.YearOfEdition = updateBookDto.YearOfEdition;
        bookDto.PageAmount = updateBookDto.PageAmount;
        
        if(updateBookDto.Image != null)
            bookDto.Image = await _fileService.UploadImage(updateBookDto.Image);
        
        if (updateBookDto.PublisherId != null)
        {
            var publisher = _mapper.Map<PublisherDto>(await _unitOfWork.Publishers
                .GetSingleByConditionAsync(p => p.Id == updateBookDto.PublisherId));

            if (publisher != null)
            {
                bookDto.Publisher = publisher;
            }
            else
            {
                throw new Exception("Publisher doesn't exist");
            }
        }

        _unitOfWork.Books.Update(_mapper.Map<Book>(bookDto));
        await _unitOfWork.SaveAsync();

        return bookDto;
    }

    public async Task DeleteBook(Guid id)
    {
        await _unitOfWork.Books.Delete(id);
        await _unitOfWork.SaveAsync();
    }
}