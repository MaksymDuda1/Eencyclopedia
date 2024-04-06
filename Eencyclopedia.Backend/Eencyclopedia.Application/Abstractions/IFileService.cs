using Microsoft.AspNetCore.Http;

namespace Eencyclopedia.Application.Abstractions;

public interface IFileService
{
    Task<string> UploadImage(IFormFile file);
}