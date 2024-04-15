using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Eencyclopedia.Domain.DTOs;

public class UserDto
{
    public Guid Id { get; set; }
    
    public string FullName { get; set; } = null!;
    public bool  IsAdmin { get; set; }
    public List<BookDto>? FavoriteBooks { get; set; } = new();
}