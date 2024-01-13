using ELibrary.Protos;
using Google.Protobuf;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using ModuleDistributor.Grpc;
using ModuleDistributor.Logging;

namespace ELibrary.Services
{
    [GrpcService]
    internal class FileService : Protos.File.FileBase, ILoggerProxy<FileService>
    {
        private static readonly string _directory = Path.Combine(Directory.GetCurrentDirectory(), "ELibraryFile");

        public ILogger<FileService> Logger { get; }
        ILogger ILoggerProxy.Logger
            => Logger;

        public FileService(ILogger<FileService> logger)
        {
            Logger = logger;
        }

        [Authorize(AuthenticationSchemes = "Bearer"), ExLogging]
        public override async Task<UploadResponse> Upload(IAsyncStreamReader<UploadRequest> requestStream, ServerCallContext context)
        {
            if (!Directory.Exists(_directory))
                Directory.CreateDirectory(_directory);

            string? fullFileName = null;
            FileStream? fileStream = null;
            bool firstEnter = false;
            long length = 0;
            
            await foreach (var request in requestStream.ReadAllAsync())
            {
                if (!firstEnter)
                {
                    fullFileName = $"{Guid.NewGuid()}{Path.GetExtension(request.FullFileName)}";
                    fileStream = new FileStream(Path.Combine(_directory, fullFileName), FileMode.Create, FileAccess.Write);
                    firstEnter = true;
                }

                if (fileStream is null)
                    throw new RpcException(Status.DefaultCancelled, "FileStream create failed.");

                try
                {
                    fileStream.Seek(length, SeekOrigin.Begin);
                    await fileStream.WriteAsync(request.FileStream.Memory);
                    length += request.FileStream.Length;
                }
                catch (Exception ex)
                {
                    await fileStream.DisposeAsync();
                    throw new RpcException(Status.DefaultCancelled, ex.Message);
                }
            }

            await fileStream!.DisposeAsync();

            return new UploadResponse
            {
                FullFileName = fullFileName
            };
        }

        [Authorize(AuthenticationSchemes = "Bearer"), ExLogging]
        public override async Task Download(DownloadRequest request, IServerStreamWriter<DownloadResponse> responseStream, ServerCallContext context)
        {
            string path = Path.Combine(_directory, request.FullFileName);
            if (!System.IO.File.Exists(path))
                throw new RpcException(Status.DefaultCancelled, "File cannot find.");

            using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                var length = 0;
                var totalLength = fileStream.Length;
                var buffer = new byte[1024 * 1024];

                while (length < totalLength)
                {
                    length += await fileStream.ReadAsync(buffer);
                    await responseStream.WriteAsync(new DownloadResponse
                    {
                        FileStream = ByteString.CopyFrom(buffer)
                    });
                }
            }
        }
    }
}
