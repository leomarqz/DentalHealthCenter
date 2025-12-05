
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DentalHealthCenter.Core.Application.Contracts.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> ToListAsync();
        Task<TEntity> GetByIdAsync(Guid id);
        Task<TEntity> Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
    }
}
