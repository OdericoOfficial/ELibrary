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
    internal class ScoreService : Score.ScoreBase, ILoggerProxy<ScoreService>
    {
        private readonly IRepository<Shared.Score> _repository;
        private readonly DaprClient _daprClient;
        private readonly DaprOptions _daprOptions;

        public ILogger<ScoreService> Logger { get; }
        ILogger ILoggerProxy.Logger 
            => Logger;

        public ScoreService(IRepository<Shared.Score> repository, DaprClient daprClient, IOptions<DaprOptions> daprOptions, ILogger<ScoreService> logger)
        {
            _repository = repository;
            _daprClient = daprClient;
            _daprOptions = daprOptions.Value;
            Logger = logger;
        }

        [Authorize(AuthenticationSchemes = "Bearer"), ExLogging]
        public override async Task<Empty> UploadScore(UploadScoreRequest request, ServerCallContext context)
        {
            using var transaction = _repository.Transaction;

            try
            {
                if (await _repository.AddAsync(request) <= 0)
                    throw new ArgumentException("Score add failed.");

                var status = await _daprClient.GetStateAsync<Shared.ScoreStatus>(_daprOptions.StateStore, request.BookId);
                if (status is null)
                    await _daprClient.SaveStateAsync(_daprOptions.StateStore, request.BookId, new Shared.ScoreStatus
                    {
                        TotalScore = request.Value,
                        Count = 1
                    });
                else
                {
                    status.TotalScore += request.Value;
                    status.Count++;
                    await _daprClient.SaveStateAsync(_daprOptions.StateStore, request.BookId, status);
                }

                var bookUser = await _daprClient.GetStateAsync<Shared.BookUserStatus>(_daprOptions.StateStore, $"{request.BookId}-{request.UserId}");
                if (bookUser is null)
                    await _daprClient.SaveStateAsync(_daprOptions.StateStore, $"{request.BookId}-{request.UserId}", new Shared.BookUserStatus
                    {
                        IsCollected = false,
                        IsScore = true,
                        Value = request.Value
                    });
                else
                {
                    bookUser.IsScore = true;
                    bookUser.Value = request.Value;
                    await _daprClient.SaveStateAsync(_daprOptions.StateStore, $"{request.BookId}-{request.UserId}", bookUser);
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
        public override async Task<Empty> UpdateScore(UpdateScoreRequest request, ServerCallContext context)
        {
            using var transaction = _repository.Transaction;
            
            try
            {
                var entity = await _repository.AsQueryable()
                    .FirstOrDefaultAsync(item 
                        => item.UserId == request.UserId 
                            && item.BookId == request.BookId);
                if (entity is null)
                    throw new ArgumentNullException("Cannot find score entity.");

                var status = await _daprClient.GetStateAsync<Shared.ScoreStatus>(_daprOptions.StateStore, entity.BookId);
                if (status is null)
                    throw new ArgumentNullException("Cannot find score cache.");

                var bookUser = await _daprClient.GetStateAsync<Shared.BookUserStatus>(_daprOptions.StateStore, $"{request.BookId}-{request.UserId}");
                if (bookUser is null)
                    throw new ArgumentNullException("Cannot find BookUser cache.");

                var value = entity.Value;
                entity.Value = request.Value;

                if (await _repository.UpdateAsync(entity) <= 0)
                    throw new ArgumentException("Score update failed.");

                status.TotalScore -= value;
                status.TotalScore += request.Value;
                bookUser.Value = request.Value;

                await _daprClient.SaveStateAsync(_daprOptions.StateStore, entity.BookId, status);
                await _daprClient.SaveStateAsync(_daprOptions.StateStore, $"{request.BookId}-{request.UserId}", bookUser);

                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new RpcException(Status.DefaultCancelled, ex.Message);
            }
            return ELibraryServicesModule.Empty;
        }

        [Authorize(AuthenticationSchemes = "Bearer"), ExLogging]
        public override async Task<GetBookScoreResponse> GetBookScore(GetBookScoreRequest request, ServerCallContext context)
        {
            var status = await _daprClient.GetStateAsync<Shared.ScoreStatus>(_daprOptions.StateStore, request.BookId);
            if (status is null)
                return new GetBookScoreResponse
                { 
                    TotalScore = 0,
                    Count = 0 
                };
            return new GetBookScoreResponse
            {
                TotalScore = status.TotalScore,
                Count = status.Count
            };
        }

        [Authorize(AuthenticationSchemes = "Bearer"), ExLogging]
        public override async Task<IsScoreResponse> IsScore(IsScoreRequest request, ServerCallContext context)
        {
            var bookUser = await _daprClient.GetStateAsync<Shared.BookUserStatus>(_daprOptions.StateStore, $"{request.BookId}-{request.UserId}");
            
            return new IsScoreResponse
            {
                IsScore = bookUser?.IsScore ?? false,
                Value = bookUser?.Value ?? 0
            };
        }
    }
}
