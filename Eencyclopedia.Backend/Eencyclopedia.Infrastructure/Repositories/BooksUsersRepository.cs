using Eencyclopedia.Domain.Abstractions;
using Eencyclopedia.Domain.Entities;
using Eencyclopedia.Infrastructure.Data;

namespace Eencyclopedia.Infrastructure.Repositories;

public class BooksUsersRepository(EencyclopediaDbContext context) 
    : BaseRepository<BookUser>(context), IBooksUsersRepository
{
}