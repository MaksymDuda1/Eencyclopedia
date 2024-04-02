using Eencyclopedia.Domain.Abstractions;
using Eencyclopedia.Infrastructure.Data;

namespace Eencyclopedia.Infrastructure.Repositories;

public class UnitOfWork(
    EencyclopediaDbContext context,
    Lazy<IBookRepository> bookRepository,
    Lazy<IAuthorRepository> authorRepository,
    Lazy<IPublisherRepository> publisherRepository) : IUnitOfWork
{
    
    private readonly Lazy<IBookRepository> _bookRepository = bookRepository;
    private readonly Lazy<IAuthorRepository> _authorRepository = authorRepository;
    private readonly Lazy<IPublisherRepository> _publisherRepository = publisherRepository;

    public IBookRepository Books => bookRepository.Value;
    public IAuthorRepository Authors => authorRepository.Value;
    public IPublisherRepository Publishers => publisherRepository.Value;
    
    public async Task SaveAsync() => await  context.SaveChangesAsync();
}