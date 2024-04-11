using AutoMapper;
using Eencyclopedia.Domain.DTOs;
using Eencyclopedia.Domain.Entities;

namespace Eencyclopedia.Application.MappingProfile;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<BookDto, Book>().ReverseMap();
        CreateMap<CreateAuthorDto, AuthorDto>().ReverseMap();
        CreateMap<UpdateAuthorDto, AuthorDto>().ReverseMap();
        CreateMap<Author, AuthorDto>().ReverseMap();
        CreateMap<CreatePublisherDto, PublisherDto>().ReverseMap();
        CreateMap<UpdatePublisherDto, PublisherDto>().ReverseMap();
        CreateMap<Publisher, PublisherDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
    }
}