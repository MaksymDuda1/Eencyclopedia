using Eencyclopedia.Application.Abstractions;
using Eencyclopedia.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Eencyclopedia.API.Controllers;

[ApiController]
[Route("api/publishers")]
public class PublisherController : ControllerBase
{
    private readonly IPublisherService _publisherService;

    public PublisherController(IPublisherService publisherService)
    {
        _publisherService = publisherService;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<PublisherDto>>> GetAllPublishers()
    {
        try
        {
            var publishers = await _publisherService.GetAllPublishers();

            return Ok(publishers);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<PublisherDto>> GetSinglePublisher(Guid id)
    {
        try
        {
            var publisher = await _publisherService.GetSinglePublisher(id);

            return Ok(publisher);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<PublisherDto>> CreatePublisher([FromForm] CreatePublisherDto request)
    {
        try
        {
            var publisher = await _publisherService.CreatePublisher(request);

            return Ok(publisher);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult<PublisherDto>> UpdatePublisher([FromForm] UpdatePublisherDto updatePublisherDto)
    {
        try
        {
            var publisher = await _publisherService.UpdatePublisher(updatePublisherDto);

            return Ok(publisher);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeletePublisher(Guid id)
    {
        try
        {
            await _publisherService.DeletePublisher(id);

            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}