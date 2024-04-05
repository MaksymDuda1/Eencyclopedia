namespace Eencyclopedia.Domain.DTOs;

public class AddBookToFavoritesDto
{
    public Guid UserId { get; set; }

    public Guid BookId { get; set; }
}