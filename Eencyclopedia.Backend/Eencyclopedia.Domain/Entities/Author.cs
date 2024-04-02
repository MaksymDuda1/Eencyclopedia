using System.ComponentModel.DataAnnotations;

namespace Eencyclopedia.Domain.Entities;

public class Author
{
    public Guid Id { get; set; }
    
    [MaxLength(100)]
    public string FullName { get; set; } = null!;
    
    public DateTime BirthDate { get; set; }

    public List<Book>? Books { get; set; }
}