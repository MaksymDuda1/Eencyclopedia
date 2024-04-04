namespace Eencyclopedia.Domain.DTOs;

public class CreatePublisherDto
{
    public string Name { get; set; } = null!;
    
    public string Description { get; set; } = null!;
    
    public string? Image { get; set; }
}