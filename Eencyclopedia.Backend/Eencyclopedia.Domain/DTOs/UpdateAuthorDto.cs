using Microsoft.AspNetCore.Http;

namespace Eencyclopedia.Domain.DTOs;

public class UpdateAuthorDto
{
    public Guid Id { get; set; }
    
    public string FullName { get; set; } = null!;
    
    public DateOnly BirthDate { get; set; }
    
    public string Description { get; set; } = null!;

    public IFormFile? Image { get; set; }
}