using AutoMapper;
using Eencyclopedia.Application.Abstractions;
using Eencyclopedia.Domain.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;

namespace Eencyclopedia.Application.Services;

public class FileService(IUnitOfWork _unitOfWork, IMapper _mapper) : IFileService
{
    public async Task<string> UploadImage(IFormFile file)
    {
        try
        {
            var folderName = Path.Combine( "Images");
            var pathToSave = "/Studying/Eencyclopedia/Web-layer/src/assets";
            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim().Split(new[] { '.' });
            var newFileName = new string(Guid.NewGuid() + "." + fileName.Last());
            var fullPath = Path.Combine(pathToSave, newFileName);
            var dbPath = Path.Combine(folderName, newFileName);
            await using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return dbPath;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}