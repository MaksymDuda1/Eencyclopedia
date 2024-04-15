using System.ComponentModel.DataAnnotations;

namespace Eencyclopedia.Domain.Entities;

public class Publisher
{
    public Guid Id { get; set; }
    
    [MaxLength(100)]
    public string Name { get; set; } = null!;
    
    [MaxLength(1000)]
    public string Description { get; set; } = null!;
    
    [MaxLength(200)]
    public string? Image { get; set; }

    public List<Book>? PublishedBooks { get; set; } = new List<Book>();
}   
