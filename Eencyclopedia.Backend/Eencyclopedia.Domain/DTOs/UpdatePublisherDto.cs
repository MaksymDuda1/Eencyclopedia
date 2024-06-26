using Microsoft.AspNetCore.Http;

namespace Eencyclopedia.Domain.DTOs;

public class UpdatePublisherDto
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = null!;
    
    public string Description { get; set; } = null!;
    
    public IFormFile? Image { get; set; }
}