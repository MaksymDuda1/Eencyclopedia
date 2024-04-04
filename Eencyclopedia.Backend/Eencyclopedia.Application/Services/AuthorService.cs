using AutoMapper;
using Eencyclopedia.Application.Abstractions;
using Eencyclopedia.Domain.Abstractions;
using Eencyclopedia.Domain.DTOs;
using Eencyclopedia.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Eencyclopedia.Application.Services;

public class AuthorService(IUnitOfWork _unitOfWork, IMapper _mapper) : IAuthorService
{
    public async Task<List<AuthorDto>> GetAllAuthors()
    {
        var authors = await _unitOfWork.Authors.GetAllAsync(a => a.Books);
        
        var result = authors.Select(_mapper.Map<AuthorDto>);
        return result.ToList();
    }
    
    public async Task<AuthorDto> GetSingleAuthor(Guid id)
    {
        return  _mapper.Map<AuthorDto>(
            await _unitOfWork.Authors.GetSingleByConditionAsync(
                a => a.Id == id,
                a => a.Books));
    }

    public async Task CreateAuthor(CreateAuthorDto author)
    {
        var newAuthor = _mapper.Map<AuthorDto>(author);

        await _unitOfWork.Authors.InsertAsync(_mapper.Map<Author>(newAuthor));
        await _unitOfWork.SaveAsync();
    }

    public async Task UpdateAuthor(UpdateAuthorDto updateAuthorDto)
    {
        var author = _mapper.Map<AuthorDto>(
            await _unitOfWork.Authors.GetSingleByConditionAsync(
                a => a.Id == updateAuthorDto.Id,
                    a => a.Books));

        author.FullName = updateAuthorDto.FullName;
        author.Description = updateAuthorDto.Description;
        author.BirthDate = updateAuthorDto.BirthDate;
        author.Image = updateAuthorDto.Image; // add service for image uploading

        _unitOfWork.Authors.Update(_mapper.Map<Author>(author));
        await _unitOfWork.SaveAsync();

    }

    public async Task Delete(Guid id)
    {
        await _unitOfWork.Authors.Delete(id);
        await _unitOfWork.SaveAsync();
    }
}