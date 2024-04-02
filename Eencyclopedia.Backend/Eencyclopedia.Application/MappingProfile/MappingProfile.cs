using AutoMapper;
using Eencyclopedia.Domain.DTOs;
using Eencyclopedia.Domain.Entities;

namespace Eencyclopedia.Application.MappingProfile;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Book, BookDto>().ReverseMap();
        CreateMap<Author, AuthorDto>().ReverseMap();
        CreateMap<Publisher, PublisherDto>().ReverseMap();
    }
}