using AutoMapper;
using Eencyclopedia.Application.Abstractions;
using Eencyclopedia.Domain.Abstractions;
using Eencyclopedia.Domain.DTOs;
using Eencyclopedia.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Eencyclopedia.Application.Services;

public class AuthorService(IFileService _fileService,IUnitOfWork _unitOfWork, IMapper _mapper) : IAuthorService
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

    public async Task<AuthorDto> CreateAuthor(CreateAuthorDto author)
    {
        var authorDto = _mapper.Map<AuthorDto>(author);

        if (author.Image != null)
            authorDto.Image = await _fileService.UploadImage(author.Image);
        
        await _unitOfWork.Authors.InsertAsync(_mapper.Map<Author>(authorDto));
        await _unitOfWork.SaveAsync();

        return authorDto;
    }

    public async Task<AuthorDto> UpdateAuthor(UpdateAuthorDto updateAuthorDto)
    {
        var authorDto = _mapper.Map<AuthorDto>(
            await _unitOfWork.Authors.GetSingleByConditionAsync(
                    a => a.Id == updateAuthorDto.Id));

        authorDto.FullName = updateAuthorDto.FullName;
        authorDto.Description = updateAuthorDto.Description;
        authorDto.BirthDate = updateAuthorDto.BirthDate;

        if (updateAuthorDto.Image != null)
            authorDto.Image = await _fileService.UploadImage(updateAuthorDto.Image);
            

        _unitOfWork.Authors.Update(_mapper.Map<Author>(authorDto));
        await _unitOfWork.SaveAsync();

        return authorDto;
    }

    public async Task Delete(Guid id)
    {
        await _unitOfWork.Authors.Delete(id);
        await _unitOfWork.SaveAsync();
    }
}