

using DentalHealthCenter.Core.Application.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DentalHealthCenter.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DentalHealthCenterDbContext context;

        public Repository(DentalHealthCenterDbContext context)
        {
            this.context = context;
        }

        public Task<TEntity> Add(TEntity entity)
        {
            context.Add(entity);
            return Task.FromResult(entity);
        }

        public Task Delete(TEntity entity)
        {
            this.context.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<List<TEntity>> ToListAsync()
        {
            return await this.context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await this.context.Set<TEntity>().FindAsync(id);
        }

        public Task Update(TEntity entity)
        {
            this.context.Update(entity);
            return Task.CompletedTask;
        }
    }
}
