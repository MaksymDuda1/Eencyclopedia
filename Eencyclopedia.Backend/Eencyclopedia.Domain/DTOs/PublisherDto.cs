using System.ComponentModel.DataAnnotations;
using Eencyclopedia.Domain.Entities;

namespace Eencyclopedia.Domain.DTOs;

public class PublisherDto
{
    public Guid Id { get; set; }
    
    [MaxLength(100)]
    public string Name { get; set; } = null!;
    
    [MaxLength(1000)]
    public string Description { get; set; } = null!;
    
    [MaxLength(200)]
    public string? Image { get; set; }
    
    public List<Book>? PublishedBooks { get; set; }
}