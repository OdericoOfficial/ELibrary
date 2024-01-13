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

namespace ELibrary.Services
{
    [GrpcService]
    internal class CommentService : Comment.CommentBase, ILoggerProxy<CommentService>
    {
        private readonly IRepository<Shared.Comment> _repository;
        private readonly IMapper _mapper;

        public ILogger<CommentService> Logger { get; }
        ILogger ILoggerProxy.Logger 
            => Logger;

        public CommentService(IRepository<Shared.Comment> repository, IMapper mapper,ILogger<CommentService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            Logger = logger;
        }

        [Authorize(AuthenticationSchemes = "Bearer"), ExLogging]
        public override async Task<Empty> UploadComment(UploadCommentRequest request, ServerCallContext context)
        {
            if (await _repository.AddAsync(request) <= 0)
                throw new ArgumentException("Comment add failed.");
            return ELibraryServicesModule.Empty;
        }

        [Authorize(AuthenticationSchemes = "Bearer"), ExLogging]
        public override async Task<Empty> DeleteComment(DeleteCommentRequest request, ServerCallContext context)
        {
            var entity = await _repository.AsQueryable()
                .FirstOrDefaultAsync(item => item.Id == request.Id);
            
            if (entity is null)
                throw new ArgumentNullException("Cannot find comment entity.");

            if (entity.BookId != request.BookId || entity.UserId != request.UserId || await _repository.DeleteAsync(entity.Id) <= 0)
                throw new ArgumentException("Comment delete failed.");
            return ELibraryServicesModule.Empty;
        }

        [Authorize(AuthenticationSchemes = "Bearer"), ExLogging]
        public override async Task GetComment(GetCommentRequest request, IServerStreamWriter<GetCommentResponse> responseStream, ServerCallContext context)
        {
            await _repository.AsQueryable()
                .Where(item => item.BookId == request.BookId)
                .Skip(request.Skip)
                .Take(request.Take)
                .ForEachAsync(async item
                    => await responseStream.WriteAsync(_mapper.Map<Shared.Comment, GetCommentResponse>(item)));
        }
    }
}
