using AutoMapper;
using Eencyclopedia.Application.Abstractions;
using Eencyclopedia.Domain.Abstractions;
using Eencyclopedia.Domain.DTOs;
using Eencyclopedia.Domain.Entities;

namespace Eencyclopedia.Application.Services;

public class BookService(IFileService _fileService, IUnitOfWork _unitOfWork, IMapper _mapper) : IBookService
{
    public async Task<List<BookDto>> GetAllBooks()
    {
        var books = await _unitOfWork.Books.GetAllAsync(
            b => b.Author,
            b => b.Publisher,
            b => b.Users);

        return books.Select(_mapper.Map<BookDto>).ToList();
    }

    public async Task<BookDto> GetSingleBook(Guid id)
    {
        return _mapper.Map<BookDto>(
            await _unitOfWork.Books.GetSingleByConditionAsync(
                b => b.Id == id,
                b => b.Author,
                b => b.Publisher,
                b => b.Users));
    }

    public async Task<List<BookDto>> GetByConditionals(GetByGenreDto getByGenreDto)
    {
        var books = await _unitOfWork.Books.GetByConditionsAsync(
            b => b.Genre == getByGenreDto.Genre,
            b => b.Author,
            b => b.Publisher,
            b => b.Users);

        return books.Select(_mapper.Map<BookDto>).ToList();
    }

    public async Task CreateBook(CreateBookDto createBookDto)
    {
        var book = _mapper.Map<BookDto>(createBookDto);

        if (book.PublisherId != null)
        {
            book.Publisher = _mapper.Map<PublisherDto>(
                await _unitOfWork.Publishers.GetSingleByConditionAsync(
                    p => p.Id == book.PublisherId));
        }

        if (book.AuthorId != null)
        {
            book.Author = _mapper.Map<AuthorDto>(
                await _unitOfWork.Authors.GetSingleByConditionAsync(
                    a => a.Id == book.AuthorId));
        }

        await _unitOfWork.Books.InsertAsync(_mapper.Map<Book>(book));
        await _unitOfWork.SaveAsync();
    }

    public async Task UpdateBook(UpdateBookDto updateBookDto)
    {
        var book = _mapper.Map<BookDto>(await _unitOfWork.Books.GetSingleByConditionAsync(
            b => b.Id == updateBookDto.Id,
            b => b.Author,
            b => b.Publisher));

        book.Name = updateBookDto.Name;
        book.Path = updateBookDto.Path;
        book.Description = updateBookDto.Description;
        book.Genre = updateBookDto.Genre;
        book.YearOfEdition = updateBookDto.YearOfEdition;
        book.PageAmount = updateBookDto.PageAmount;
        book.Image = updateBookDto.Image;

        _unitOfWork.Books.Update(_mapper.Map<Book>(book));
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteBook(Guid id)
    {
        await _unitOfWork.Books.Delete(id);
        await _unitOfWork.SaveAsync();
    }

    public async Task AddBookImage(AddBookImageDto addBookImageDto)
    {
        var book = _mapper.Map<BookDto>(await _unitOfWork.Books
            .GetByConditionsAsync(b => b.Id == addBookImageDto.Id));

        book.Image = _fileService.UploadImage(addBookImageDto.Image).ToString();
        await _unitOfWork.SaveAsync();
    }
}