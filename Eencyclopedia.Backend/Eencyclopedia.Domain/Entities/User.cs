using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Eencyclopedia.Domain.Entities;

public class User: IdentityUser<Guid>
{
    [MaxLength(100)]
    public string FullName { get; set; } = null!;
        
    public List<Book>? FavoriteBooks { get; set; }
}