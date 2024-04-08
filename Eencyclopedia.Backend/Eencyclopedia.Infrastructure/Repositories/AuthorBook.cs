using Eencyclopedia.Domain.Abstractions;
using Eencyclopedia.Domain.Entities;
using Eencyclopedia.Infrastructure.Data;

namespace Eencyclopedia.Infrastructure.Repositories;

public class AuthorsBooksRepository(EencyclopediaDbContext context) 
    : BaseRepository<AuthorBook>(context), IAuthorsBooksRepository
{
    
}