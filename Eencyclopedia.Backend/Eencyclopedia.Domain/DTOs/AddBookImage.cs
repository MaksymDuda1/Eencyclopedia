using Microsoft.AspNetCore.Http;

namespace Eencyclopedia.Domain.DTOs;

public class AddBookImageDto
{
    public Guid Id { get; set; }
    public IFormFile? Image { get; set; } 
}