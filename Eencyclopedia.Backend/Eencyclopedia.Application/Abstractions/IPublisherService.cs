using Eencyclopedia.Domain.DTOs;

namespace Eencyclopedia.Application.Services;

public interface IPublisherService
{
    Task<List<PublisherDto>> GetAllPublishers();
    Task<PublisherDto> GetSinglePublisher(Guid id);
    Task CreatePublisher(CreatePublisherDto createPublisherDto);
    Task UpdatePublisher(UpdatePublisherDto updatePublisherDto);
    Task DeletePublisher(Guid id);
}