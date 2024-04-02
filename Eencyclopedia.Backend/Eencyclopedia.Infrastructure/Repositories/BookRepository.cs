using Eencyclopedia.Domain.Abstractions;
using Eencyclopedia.Domain.Entities;
using Eencyclopedia.Infrastructure.Data;

namespace Eencyclopedia.Infrastructure.Repositories;

public class BookRepository(EencyclopediaDbContext context) 
    : BaseRepository<Book>(context), IBookRepository
{
    private readonly EencyclopediaDbContext _context;
}