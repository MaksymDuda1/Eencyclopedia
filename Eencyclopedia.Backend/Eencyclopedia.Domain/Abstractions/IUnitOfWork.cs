namespace Eencyclopedia.Domain.Abstractions;

public interface IUnitOfWork
{
    IBookRepository Books { get; }
    IAuthorRepository Authors { get;}
    
    IPublisherRepository Publishers { get; }
    Task SaveAsync();
}