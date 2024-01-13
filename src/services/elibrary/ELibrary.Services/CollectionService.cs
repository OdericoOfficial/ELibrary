using AutoMapper;
using ELibrary.EntityFrameworkCore;
using ELibrary.Protos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ModuleDistributor.Grpc;
using ModuleDistributor.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Services
{
    [GrpcService]
    internal class CollectionService : Collection.CollectionBase, ILoggerProxy<CollectionService>
    {
        private readonly IRepository<Shared.Collection> _repository;
        private readonly IMapper _mapper;

        public ILogger<CollectionService> Logger { get; }
        ILogger ILoggerProxy.Logger
            => Logger;

        public CollectionService(IMapper mapper, IRepository<Shared.Collection> repository, ILogger<CollectionService> logger)
        {
            _mapper = mapper;
            _repository = repository;
            Logger = logger;
        }

        [Authorize(AuthenticationSchemes = "Bearer"), ExLogging]
        public override async Task<Empty> UploadCollection(UploadCollectionRequest request, ServerCallContext context)
        {
            if (await _repository.AddAsync(request) <= 0)
                throw new ArgumentException("Collection add failed.");
            return ELibraryServicesModule.Empty;

        }

        [Authorize(AuthenticationSchemes = "Bearer"), ExLogging]
        public override async Task<Empty> UpdateCollection(UpdateCollectionRequest request, ServerCallContext context)
        {
            if (await _repository.UpdateAsync(request) <= 0)
                throw new ArgumentException("Collection update failed.");
            return ELibraryServicesModule.Empty;
        }

        [Authorize(AuthenticationSchemes = "Bearer"), ExLogging]
        public override async Task<Empty> DeleteCollection(DeleteCollectionRequest request, ServerCallContext context)
        {
            if (await _repository.DeleteAsync(request.Id) <= 0)
                throw new ArgumentException("Collection delete failed.");
            return ELibraryServicesModule.Empty;
        }

        [Authorize(AuthenticationSchemes = "Bearer"), ExLogging]
        public override async Task GetCollection(GetCollectionRequest request, IServerStreamWriter<GetCollectionResponse> responseStream, ServerCallContext context)
            => await _repository.AsQueryable()
                .Where(item => item.UserId == request.UserId)
                .OrderBy(item => item.CreateTime)
                .Skip(request.Skip)
                .Take(request.Take)
                .ForEachAsync(async entity 
                    => await responseStream.WriteAsync(_mapper.Map<Shared.Collection, GetCollectionResponse>(entity)));
    }
}
