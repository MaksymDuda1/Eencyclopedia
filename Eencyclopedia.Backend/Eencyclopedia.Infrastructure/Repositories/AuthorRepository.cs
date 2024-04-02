using Eencyclopedia.Domain.Abstractions;
using Eencyclopedia.Domain.Entities;
using Eencyclopedia.Infrastructure.Data;

namespace Eencyclopedia.Infrastructure.Repositories;

public class AuthorRepository(EencyclopediaDbContext context) 
    : BaseRepository<Author>(context), IAuthorRepository
{
    private readonly EencyclopediaDbContext _context;
}