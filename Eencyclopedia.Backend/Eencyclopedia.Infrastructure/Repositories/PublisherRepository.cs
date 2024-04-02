using Eencyclopedia.Domain.Abstractions;
using Eencyclopedia.Domain.Entities;
using Eencyclopedia.Infrastructure.Data;

namespace Eencyclopedia.Infrastructure.Repositories;

public class PublisherRepository(EencyclopediaDbContext context)
    : BaseRepository<Publisher>(context), IPublisherRepository
{
    private readonly EencyclopediaDbContext _context;
}