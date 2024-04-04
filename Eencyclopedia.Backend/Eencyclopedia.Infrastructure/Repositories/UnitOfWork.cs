using Eencyclopedia.Domain.Abstractions;
using Eencyclopedia.Infrastructure.Data;

namespace Eencyclopedia.Infrastructure.Repositories;

public class UnitOfWork(
    EencyclopediaDbContext context,
    Lazy<IBookRepository> bookRepository,
    Lazy<IAuthorRepository> authorRepository,
    Lazy<IPublisherRepository> publisherRepository,
    Lazy<IUserRepository> userRepository) : IUnitOfWork
{
    
    public IBookRepository Books => bookRepository.Value;
    public IAuthorRepository Authors => authorRepository.Value;
    public IPublisherRepository Publishers => publisherRepository.Value;
    public IUserRepository Users => userRepository.Value;
    public async Task SaveAsync() => await  context.SaveChangesAsync();
}