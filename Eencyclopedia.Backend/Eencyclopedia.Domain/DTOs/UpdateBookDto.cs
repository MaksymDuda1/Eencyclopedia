using System.ComponentModel.DataAnnotations;
using Eencyclopedia.Domain.Entities;
using Eencyclopedia.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace Eencyclopedia.Domain.DTOs;

public class UpdateBookDto
{
    public Guid Id { get; set; }
    [MaxLength(100)]
    public string Name { get; set; } = null!;
    public string Path { get; set; } = null!;
    [MaxLength(700)]
    public string Description { get; set; } = null!;
    public Genre Genre { get; set; }
    public int YearOfEdition { get; set; }
    public int PageAmount { get; set; }
    public IFormFile? Image { get; set; }
    public Guid? PublisherId { get; set; }
    public List<AuthorDto>? Authors { get; set; }
    public Publisher? Publisher { get; set; }
}