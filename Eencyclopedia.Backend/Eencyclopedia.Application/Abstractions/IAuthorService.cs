using System.Linq.Expressions;
using Eencyclopedia.Domain.DTOs;
using Eencyclopedia.Domain.Entities;

namespace Eencyclopedia.Application.Abstractions;

public interface IAuthorService
{
    Task<List<AuthorDto>> GetAllAuthors();
    Task<AuthorDto> GetSingleAuthor(Guid id);
    Task CreateAuthor(CreateAuthorDto author);
    Task UpdateAuthor(UpdateAuthorDto author);
    Task Delete(Guid id);
}