using Lcb.Infrastructure.Configs;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;

namespace Lcb.BLL.MediatR.UploadImage;

public static partial class UploadImage
{
    public class Handler : IRequestHandler<Command, string>
    {
        private readonly string _staticFilesPath;

        private readonly ILogger<Handler> _logger;

        public Handler(IOptions<StaticConfig> options, ILogger<Handler> logger)
        {
            _staticFilesPath = options.Value.StaticFilesPath;
            _logger = logger;
        }

        public async Task<string> Handle(Command request, CancellationToken cancellationToken)
        {
            EnsureSubFolderExist(request.Folder);

            var guid = Guid.NewGuid()
                .ToString("N");
            var guidFileName = string.Concat(guid, request.FileName.AsSpan(request.FileName.LastIndexOf('.')));
            var folderPath = Path.Combine(_staticFilesPath, request.Folder);
            var filePath = Path.Combine(folderPath, guidFileName);

            await using var fileStream = new FileStream(filePath, FileMode.CreateNew);
            await fileStream.WriteAsync(request.Data.AsMemory(0, request.Data.Length), cancellationToken);
            return guidFileName;
        }


        private void EnsureSubFolderExist(string subfolder)
        {
            var path = Path.Combine(_staticFilesPath, subfolder);
            if (Directory.Exists(path)) return;
            _logger.LogWarning("SubFolder {subfolder} Is Missing, Creating", subfolder);
            Directory.CreateDirectory(path);
        }
    }
}