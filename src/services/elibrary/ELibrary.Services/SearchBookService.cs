using AutoMapper;
using Dapr.Client;
using ELibrary.EntityFrameworkCore;
using ELibrary.Protos;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ModuleDistributor.Dapr;
using ModuleDistributor.Grpc;
using ModuleDistributor.Logging;

namespace ELibrary.Services
{
    [GrpcService]
    internal class SearchBookService : SearchBook.SearchBookBase, ILoggerProxy<SearchBookService>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Shared.Book> _repository;

        public ILogger<SearchBookService> Logger { get; }
        ILogger ILoggerProxy.Logger
            => Logger;

        public SearchBookService(IMapper mapper, IRepository<Shared.Book> repository, ILogger<SearchBookService> logger)
        {
            _mapper = mapper;
            _repository = repository;
            Logger = logger;
        }

        [Authorize(AuthenticationSchemes = "Bearer"), ExLogging]
        public override async Task GetBookOrderByPublishYear(GetBookRequest request, IServerStreamWriter<GetBookResponse> responseStream, ServerCallContext context)
        {
            var query = _repository.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.Title))
                query = query.Where(item => item.Title.Contains(request.Title));

            if (!string.IsNullOrWhiteSpace(request.Language))
                query = query.Where(item => item.Language.Contains(request.Language));

            if (!string.IsNullOrWhiteSpace(request.Classification))
                query = query.Where(item => item.Classification.Contains(request.Classification));

            if (!string.IsNullOrWhiteSpace(request.Press))
                query = query.Where(item => item.Press.Contains(request.Press));

            if (!string.IsNullOrWhiteSpace(request.Writer))
                query = query.Where(item => item.Writer.Contains(request.Writer));

            if (request.IsDesc)
                query = query.OrderByDescending(item => item.PublishYear);
            else
                query = query.OrderBy(item => item.PublishYear);

            await query.ForEachAsync(async item => await responseStream.WriteAsync(_mapper.Map<Shared.Book, GetBookResponse>(item)));
        }

        [Authorize(AuthenticationSchemes = "Bearer"), ExLogging]
        public override async Task GetBookOrderByScore(GetBookRequest request, IServerStreamWriter<GetBookResponse> responseStream, ServerCallContext context)
        {
            var query = _repository.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.Title))
                query = query.Where(item => item.Title.Contains(request.Title));

            if (!string.IsNullOrWhiteSpace(request.Language))
                query = query.Where(item => item.Language.Contains(request.Language));

            if (!string.IsNullOrWhiteSpace(request.Classification))
                query = query.Where(item => item.Classification.Contains(request.Classification));

            if (!string.IsNullOrWhiteSpace(request.Press))
                query = query.Where(item => item.Press.Contains(request.Press));

            if (!string.IsNullOrWhiteSpace(request.Writer))
                query = query.Where(item => item.Writer.Contains(request.Writer));

            if (request.IsDesc)
                query = query.OrderByDescending(item 
                    => item.Scores.Sum(score => score.Value));
            else
                query = query.OrderBy(item 
                    => item.Scores.Sum(score => score.Value));

            await query.ForEachAsync(async item => await responseStream.WriteAsync(_mapper.Map<Shared.Book, GetBookResponse>(item)));

        }
        
        [Authorize(AuthenticationSchemes = "Bearer"), ExLogging]
        public override async Task GetBookOrderByTime(GetBookRequest request, IServerStreamWriter<GetBookResponse> responseStream, ServerCallContext context)
        {
            var query = _repository.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.Title))
                query = query.Where(item => item.Title.Contains(request.Title));

            if (!string.IsNullOrWhiteSpace(request.Language))
                query = query.Where(item => item.Language.Contains(request.Language));

            if (!string.IsNullOrWhiteSpace(request.Classification))
                query = query.Where(item => item.Classification.Contains(request.Classification));

            if (!string.IsNullOrWhiteSpace(request.Press))
                query = query.Where(item => item.Press.Contains(request.Press));

            if (!string.IsNullOrWhiteSpace(request.Writer))
                query = query.Where(item => item.Writer.Contains(request.Writer));

            if (request.IsDesc)
                query = query.OrderByDescending(item => item.CreateTime);
            else
                query = query.OrderBy(item => item.CreateTime);

            await query.ForEachAsync(async item => await responseStream.WriteAsync(_mapper.Map<Shared.Book, GetBookResponse>(item)));
        }

        [Authorize(AuthenticationSchemes = "Bearer"), ExLogging]
        public override async Task<GetBookDetailResponse> GetBookDetail(GetBookDetailRequest request, ServerCallContext context)
        {
            var book = await _repository.AsQueryable().FirstOrDefaultAsync(item => item.Id == request.Id);
            if (book is null)
                throw new ArgumentNullException("Cannot find book.");
            return _mapper.Map<Shared.Book, GetBookDetailResponse>(book);
        }

        [Authorize(AuthenticationSchemes = "Bearer"), ExLogging]
        public override async Task GetBookOrderByUser(GetBookByUserRequest request, IServerStreamWriter<GetBookResponse> responseStream, ServerCallContext context)
        {
            var query = _repository.AsQueryable().Where(item => item.UserId == request.UserId);
            await query.ForEachAsync(async item => await responseStream.WriteAsync(_mapper.Map<Shared.Book, GetBookResponse>(item)));
        }
    }
}
