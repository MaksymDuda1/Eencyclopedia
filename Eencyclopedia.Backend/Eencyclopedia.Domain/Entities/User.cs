using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace Eencyclopedia.Domain.Entities;

public class User: IdentityUser<Guid>
{
    [MaxLength(100)]
    public string FullName { get; set; } = null!;
    [JsonIgnore]
    public List<Book>? FavoriteBooks { get; set; }

    public List<BookUser>? BooksUsers { get; set; } = new List<BookUser>();
}