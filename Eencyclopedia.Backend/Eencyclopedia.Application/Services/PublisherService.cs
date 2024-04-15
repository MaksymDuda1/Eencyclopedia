using AutoMapper;
using Eencyclopedia.Application.Abstractions;
using Eencyclopedia.Domain.Abstractions;
using Eencyclopedia.Domain.DTOs;
using Eencyclopedia.Domain.Entities;

namespace Eencyclopedia.Application.Services;

public class PublisherService(IFileService _fileService,IUnitOfWork _unitOfWork,IMapper _mapper) : IPublisherService
{
    public async Task<List<PublisherDto>> GetAllPublishers()
    {
        var publishers = await _unitOfWork.Publishers.GetAllAsync(
            p => p.PublishedBooks);

        var result = publishers.Select(_mapper.Map<PublisherDto>);
        return result.ToList();
    }

    public async Task<PublisherDto> GetSinglePublisher(Guid id)
    {
        return _mapper.Map<PublisherDto>(await _unitOfWork.Publishers
            .GetSingleByConditionAsync(
                p => p.Id == id,
                b => b.PublishedBooks));
    }

    public async Task<PublisherDto> CreatePublisher(CreatePublisherDto createPublisherDto)
    {
        var publisherDto = _mapper.Map<PublisherDto>(createPublisherDto);

        if (createPublisherDto.Image != null)
            publisherDto.Image = await _fileService.UploadImage(createPublisherDto.Image);

        await _unitOfWork.Publishers.InsertAsync(_mapper.Map<Publisher>(publisherDto));
        await _unitOfWork.SaveAsync();

        return publisherDto;
    }

    public async Task<PublisherDto> UpdatePublisher(UpdatePublisherDto updatePublisherDto)
    {
        var publisherDto = _mapper.Map<PublisherDto>(await _unitOfWork.Publishers
            .GetSingleByConditionAsync(p => p.Id == updatePublisherDto.Id));

        publisherDto.Name = updatePublisherDto.Name;
        publisherDto.Description = updatePublisherDto.Description;

        if (updatePublisherDto.Image != null)
            publisherDto.Image = await _fileService.UploadImage(updatePublisherDto.Image);
            
        _unitOfWork.Publishers.Update(_mapper.Map<Publisher>(publisherDto));
        await _unitOfWork.SaveAsync();

        return publisherDto;
    }

    public async Task DeletePublisher(Guid id)
    {
        await _unitOfWork.Publishers.Delete(id);
        await _unitOfWork.SaveAsync();
    }
}