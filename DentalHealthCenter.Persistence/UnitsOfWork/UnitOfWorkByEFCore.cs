

using DentalHealthCenter.Core.Application.Contracts.Persistence;
using System.Threading.Tasks;

namespace DentalHealthCenter.Persistence.UnitsOfWork
{
    /// <summary>
    /// Unidad  de Trabajo dedicada a funcionar con Entity Framework Core
    /// </summary>
    public class UnitOfWorkByEFCore : IUnitOfWork
    {
        private readonly DentalHealthCenterDbContext context;

        public UnitOfWorkByEFCore(DentalHealthCenterDbContext context)
        {
            this.context = context;
        }

        public async Task CommitAsync()
        {
            await this.context.SaveChangesAsync();
        }

        public Task RollbackAsync()
        {
            return Task.CompletedTask;
        }
    }
}
