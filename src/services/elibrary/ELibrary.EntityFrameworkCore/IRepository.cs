using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.EntityFrameworkCore
{
    public interface IRepository<TEntity>
    {
        IDbContextTransaction Transaction { get; }
        Task<int> AddAsync<TRequest>(TRequest request);
        Task<int> UpdateAsync<TRequest>(TRequest request);
        Task<int> UpdateAsync(TEntity entity);
        Task<int> DeleteAsync(string id);
        IQueryable<TEntity> AsQueryable();
    }
}
