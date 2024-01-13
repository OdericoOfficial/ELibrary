using AutoMapper;
using Dapr.Client;
using ELibrary.EntityFrameworkCore;
using ELibrary.Protos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ModuleDistributor.Dapr;
using ModuleDistributor.Grpc;
using ModuleDistributor.Logging;

namespace ELibrary.Services
{
    [GrpcService]
    internal class CollectedBookService : CollectedBook.CollectedBookBase, ILoggerProxy<CollectedBookService>
    {
        private readonly IRepository<Shared.CollectedBook> _repository;
        private readonly IMapper _mapper;
        private readonly DaprOptions _daprOptions;
        private readonly DaprClient _daprClient;

        public ILogger<CollectedBookService> Logger { get; }
        ILogger ILoggerProxy.Logger 
            => Logger;

        public CollectedBookService(IRepository<Shared.CollectedBook> repository, IMapper mapper,
            IOptions<DaprOptions> daprOptions, DaprClient daprClient, ILogger<CollectedBookService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _daprOptions = daprOptions.Value;
            _daprClient = daprClient;
            Logger = logger;
        }

        [Authorize(AuthenticationSchemes = "Bearer"), ExLogging]
        public override async Task<Empty> UploadCollected(UploadCollectedRequest request, ServerCallContext context)
        {
            using var transaction = _repository.Transaction;

            try
            {
                if (await _repository.AddAsync(request) <= 0)
                    throw new ArgumentException("Collected add failed.");

                var status = await _daprClient.GetStateAsync<Shared.BookUserStatus>(_daprOptions.StateStore, $"{request.BookId}-{request.UserId}");
                if (status is null)
                    await _daprClient.SaveStateAsync(_daprOptions.StateStore, $"{request.BookId}-{request.UserId}", new Shared.BookUserStatus
                    {
                        IsCollected = true,
                        IsScore = false,
                        CollectionId = request.CollectionId
                    });
                else
                {
                    status.IsCollected = true;
                    status.CollectionId = request.CollectionId;  
                    await _daprClient.SaveStateAsync(_daprOptions.StateStore, $"{request.BookId}-{request.UserId}", status);
                }

                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new RpcException(Status.DefaultCancelled, ex.Message);
            }

            return ELibraryServicesModule.Empty;
        }

        [Authorize(AuthenticationSchemes = "Bearer"), ExLogging]
        public override async Task<Empty> DeleteCollected(DeleteCollectedRequest request, ServerCallContext context)
        {
            using var transaction = _repository.Transaction;

            try
            {
                var status = await _daprClient.GetStateAsync<Shared.BookUserStatus>(_daprOptions.StateStore, $"{request.BookId}-{request.UserId}");
                if (status is null)
                    throw new ArgumentNullException("Cannot find bookuser cache.");

                var entity = await _repository.AsQueryable()
                    .FirstOrDefaultAsync(item
                        => item.CollectionId == status.CollectionId
                            && item.BookId == request.BookId);

                if (entity is null)
                    throw new ArgumentNullException("Cannot find collected entity.");

                if (await _repository.DeleteAsync(entity.Id) <= 0)
                    throw new ArgumentException("Collected delete failed.");

                status.CollectionId = null;
                status.IsCollected = false;
                await _daprClient.SaveStateAsync(_daprOptions.StateStore, $"{request.BookId}-{request.UserId}", status);

                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new RpcException(Status.DefaultCancelled, ex.Message);
            }
            return ELibraryServicesModule.Empty;
        }

        [Authorize(AuthenticationSchemes = "Bearer"), ExLogging]
        public override async Task GetCollectedBook(GetCollectedBookRequest request, IServerStreamWriter<GetCollectedBookResponse> responseStream, ServerCallContext context)
        {
            await _repository.AsQueryable()
                .Where(item => item.CollectionId == request.CollectionId)
                .ForEachAsync(async item 
                    => await responseStream.WriteAsync(new GetCollectedBookResponse { BookId = item.BookId, Title = item.Book.Title }));
        }

        [Authorize(AuthenticationSchemes = "Bearer"), ExLogging]
        public override async Task<IsCollectedResponse> IsCollected(IsCollectedRequest request, ServerCallContext context)
        {
            var status = await _daprClient.GetStateAsync<Shared.BookUserStatus>(_daprOptions.StateStore, $"{request.BookId}-{request.UserId}");
            
            return new IsCollectedResponse
            {
                IsCollected = status?.IsCollected ?? false
            };
        }
    }
}
