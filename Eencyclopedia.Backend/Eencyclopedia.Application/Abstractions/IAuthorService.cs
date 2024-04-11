using System.Linq.Expressions;
using Eencyclopedia.Domain.DTOs;
using Eencyclopedia.Domain.Entities;

namespace Eencyclopedia.Application.Abstractions;

public interface IAuthorService
{
    Task<List<AuthorDto>> GetAllAuthors();
    Task<AuthorDto> GetSingleAuthor(Guid id);
    Task<AuthorDto> CreateAuthor(CreateAuthorDto author);
    Task<AuthorDto> UpdateAuthor(UpdateAuthorDto author);
    Task Delete(Guid id);
}