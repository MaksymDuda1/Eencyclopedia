using System.ComponentModel.DataAnnotations;
using Eencyclopedia.Domain.Entities;

namespace Eencyclopedia.Domain.DTOs;

public class AuthorDto
{
    public Guid Id { get; set; }
    
    [MaxLength(100)]
    public string FullName { get; set; } = null!;
    
    public DateTime BirthDate { get; set; }

    public List<Book>? Books { get; set; }
}