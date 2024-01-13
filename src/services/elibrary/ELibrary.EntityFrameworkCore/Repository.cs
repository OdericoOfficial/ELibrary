using AutoMapper;
using Azure.Core;
using ELibrary.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace ELibrary.EntityFrameworkCore
{
    internal class Repository<TEntity> : IRepository<TEntity>
        where TEntity : Entity
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public IDbContextTransaction Transaction
            => _context.Database.BeginTransaction();

        public Repository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddAsync<TRequest>(TRequest request)
        {
            var set = _context.Set<TEntity>();
            var entity = _mapper.Map<TRequest, TEntity>(request);
            entity.Id = Guid.NewGuid().ToString();
            entity.CreateTime = DateTime.UtcNow;
            await set.AddAsync(entity).ConfigureAwait(false);
            return await _context.SaveChangesAsync();
        }

        public IQueryable<TEntity> AsQueryable()
            => _context.Set<TEntity>().AsNoTracking();

        public Task<int> DeleteAsync(string id)
        {
            var set = _context.Set<TEntity>();
            return set.Where(item => item.Id == id)
                .ExecuteDeleteAsync();
        }

        public Task<int> UpdateAsync<TRequest>(TRequest request)
        {
            var entity = _mapper.Map<TRequest, TEntity>(request);
            entity.CreateTime = DateTime.UtcNow;
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }

        public Task<int> UpdateAsync(TEntity entity)
        {
            entity.CreateTime = DateTime.UtcNow;
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }
    }
}
