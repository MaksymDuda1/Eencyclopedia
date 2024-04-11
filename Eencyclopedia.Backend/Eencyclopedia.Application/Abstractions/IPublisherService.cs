using Eencyclopedia.Domain.DTOs;

namespace Eencyclopedia.Application.Abstractions;

public interface IPublisherService
{
    Task<List<PublisherDto>> GetAllPublishers();
    Task<PublisherDto> GetSinglePublisher(Guid id);
    Task<PublisherDto> CreatePublisher(CreatePublisherDto createPublisherDto);
    Task<PublisherDto> UpdatePublisher(UpdatePublisherDto updatePublisherDto);
    Task DeletePublisher(Guid id);
}