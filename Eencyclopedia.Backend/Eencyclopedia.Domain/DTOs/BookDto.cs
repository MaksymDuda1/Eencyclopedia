using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Eencyclopedia.Domain.Entities;
using Eencyclopedia.Domain.Enums;

namespace Eencyclopedia.Domain.DTOs;

public class BookDto
{
    public Guid Id { get; set; }
    
    [MaxLength(100)]
    public string Name { get; set; } = null!;   

    public string Path { get; set; } = null!;
    
    [MaxLength(700)]
    public string Description { get; set; } = null!;
    
    public Genre Genre { get; set; }
    
    public int YearOfEdition { get; set; }
    
    public int PageAmount { get; set; }
    
    [MaxLength(200)]
    public string? Image { get; set; }
    
    public Guid? PublisherId { get; set; }
    
    public PublisherDto? Publisher { get; set; }

    public List<AuthorDto> Authors { get; set; } = null!;

    [JsonIgnore] public List<UserDto>? Users { get; set; } 
}