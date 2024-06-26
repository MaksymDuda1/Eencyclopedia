using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Eencyclopedia.Domain.Enums;

namespace Eencyclopedia.Domain.Entities;

public class Book
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
    
    [JsonIgnore]
    public Publisher? Publisher { get; set; }
    
    [JsonIgnore]
    public List<Author> Authors { get; set; } = new List<Author>();

    public List<AuthorBook>? AuthorsBooks { get; set; } = new List<AuthorBook>();
    
    [JsonIgnore]
    public List<User>? Users { get; set; } = new List<User>();

    public List<BookUser>? BooksUsers { get; set; } = new List<BookUser>();
}