
using System.Threading.Tasks;

namespace DentalHealthCenter.Core.Application.Contracts.Persistence
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        Task RollbackAsync();
    }
}
