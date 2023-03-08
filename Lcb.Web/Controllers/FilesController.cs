using System.ComponentModel.DataAnnotations;
using Lcb.BLL;
using Lcb.Infrastructure.Configs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Options;
using Services;

namespace Lcb.Web.Controllers;

public class FilesController : LcbController
{
    private readonly IMediator _mediator;
    private readonly IOptions<StaticConfig> _staticConfig;

    private const string UserUploadsFolder = "user-upload";
    
    public FilesController(IMediator mediator, IOptions<StaticConfig> staticConfig)
    {
        _mediator = mediator;
        _staticConfig = staticConfig;
    }

    [HttpPost]
    public async Task<ActionResult<string>> UploadImage(IFormFile image)
    {
        image.EnsureNotNullHandled("image is missing");

        await using var ms = new MemoryStream();
        await image.CopyToAsync(ms);

        if (ms.Length == 0)
        {
            throw new BusinessException("image was empty");
        }

        // if (ms.Length > MaxBannerImageSizeInMegabytes * 1024 * 1024)
        // {
        //     throw new BusinessException($"Размер изображения превышает максимальный ({MaxBannerImageSizeInMegabytes} Мб)");
        // }

        ms.Position = 0;

        var imageName = await _mediator.Send(new BLL.MediatR.UploadImage.UploadImage.Command(UserUploadsFolder, image.FileName, ms.ToArray()));

        // var file = await _baseImageService.Create(filename, "Uploaded", ms.ToArray());

        return Ok(imageName);
    }
    
    private static readonly FileExtensionContentTypeProvider FileExtensionContentTypeProvider = new();

    [HttpGet("{name}")]
    public FileStreamResult Get([Required] string name)
    {
        var folderPath = Path.Combine(_staticConfig.Value.StaticFilesPath, UserUploadsFolder);
        var filePath = Path.Combine(folderPath, name);

        var fileStream = new FileStream(filePath, FileMode.Open);

        if (FileExtensionContentTypeProvider.TryGetContentType(filePath, out var contentType))
        {
            return new FileStreamResult(fileStream, contentType);
        }

        return new FileStreamResult(fileStream, "application/octet-stream");
    }
}