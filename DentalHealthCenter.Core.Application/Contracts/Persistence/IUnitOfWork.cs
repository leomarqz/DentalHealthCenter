
using System.Threading.Tasks;

namespace DentalHealthCenter.Core.Application.Contracts.Persistence
{
    public interface IUnitOfWork
    {
        Task Commit();
        Task Rollback();
    }
}
