using ELibrary.EntityFrameworkCore;
using ELibrary.Protos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using ModuleDistributor.Grpc;
using ModuleDistributor.Logging;

namespace ELibrary.Services
{
    [GrpcService]
    internal class BookService : Book.BookBase, ILoggerProxy<BookService>
    {
        private readonly IRepository<Shared.Book> _repository;

        public ILogger<BookService> Logger { get; }
        ILogger ILoggerProxy.Logger 
            => Logger;

        public BookService(IRepository<Shared.Book> repository, ILogger<BookService> logger)
        {
            _repository = repository;
            Logger = logger;
        }

        [Authorize(AuthenticationSchemes = "Bearer"), ExLogging]
        public override async Task<Empty> UploadBook(UploadBookRequest request, ServerCallContext context)
        {
            if (await _repository.AddAsync(request) <= 0)
                throw new ArgumentException("Book add failed.");
            return ELibraryServicesModule.Empty;
        }

        [Authorize(AuthenticationSchemes = "Bearer"), ExLogging]
        public override async Task<Empty> UpdateBook(UpdateBookRequest request, ServerCallContext context)
        {
            if (await _repository.UpdateAsync(request) <= 0)
                throw new ArgumentException("Book update failed.");
            return ELibraryServicesModule.Empty;
        }

        [Authorize(AuthenticationSchemes = "Bearer"), ExLogging]
        public override async Task<Empty> DeleteBook(DeleteBookRequest request, ServerCallContext context)
        {
            if (await _repository.DeleteAsync(request.Id) <= 0)
                throw new ArgumentException("Book delete failed.");
            return ELibraryServicesModule.Empty;
        }
    }
}
