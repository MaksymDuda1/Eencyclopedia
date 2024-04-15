namespace Eencyclopedia.Domain.DTOs;

public class FavoriteBooksDto
{
    public Guid UserId { get; set; }

    public Guid BookId { get; set; }
}