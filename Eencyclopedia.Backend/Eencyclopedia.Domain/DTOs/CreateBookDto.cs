using Eencyclopedia.Domain.Entities;
using Eencyclopedia.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace Eencyclopedia.Domain.DTOs;

public class CreateBookDto
{
    public string Name { get; set; } = null!;

    public string Path { get; set; } = null!;
    
    public string Description { get; set; } = null!;
    
    public Genre Genre { get; set; }
    
    public int YearOfEdition { get; set; }
    
    public int PageAmount { get; set; }
   
    public IFormFile? Image { get; set; }
    
    public Guid? PublisherId { get; set; }

    public List<Guid> Authors { get; set; } = null!;
}