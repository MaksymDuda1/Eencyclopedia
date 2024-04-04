using System.ComponentModel.DataAnnotations;
using Eencyclopedia.Domain.Entities;

namespace Eencyclopedia.Domain.DTOs;

public class AuthorDto
{
    public Guid Id { get; set; }
    
    [MaxLength(100)]
    public string FullName { get; set; } = null!;
    
    public DateOnly BirthDate { get; set; }
    
    [MaxLength(1000)]
    public string Description { get; set; } = null!;

    [MaxLength(200)]
    public string? Image { get; set; }

    public List<Book>? Books { get; set; }
}