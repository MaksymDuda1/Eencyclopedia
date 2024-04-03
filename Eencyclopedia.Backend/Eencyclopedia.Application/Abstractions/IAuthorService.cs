using System.Linq.Expressions;
using Eencyclopedia.Domain.Entities;

namespace Eencyclopedia.Application.Services;

public interface IAuthorService
{
    Task<List<Book>> GetAllAsync(params Expression<Func<Book, object>>[] includes);
    Task InsertAsync(Book entity);
    Task Delete(Guid id);
}