using Microsoft.AspNetCore.Identity;

namespace Eencyclopedia.Domain.Entities;

public class User: IdentityUser<Guid>
{
    public List<Book>? FavoriteBooks { get; set; }
}