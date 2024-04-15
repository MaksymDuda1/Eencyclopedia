namespace Eencyclopedia.Domain.Entities;

public class BookUser
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }

    public User? User { get; set; }

    public Guid BookId { get; set; }

    public Book? Book { get; set; }
}