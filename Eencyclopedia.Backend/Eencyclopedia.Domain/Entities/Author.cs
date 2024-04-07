using System.ComponentModel.DataAnnotations;

namespace Eencyclopedia.Domain.Entities;

public class Author
{
    public Guid Id { get; set; }
    
    [MaxLength(100)]
    public string FullName { get; set; } = null!;
    
    public DateOnly BirthDate { get; set; }

    [MaxLength(1000)]
    public string Description { get; set; } = null!;

    [MaxLength(200)]
    public string? Image { get; set; }
    public List<Book>? Books { get; set; } = new List<Book>();
    
    public List<AuthorBook>? AuthorsBooks { get; set; } = new List<AuthorBook>();
}