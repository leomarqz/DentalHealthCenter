
using System.Threading.Tasks;

namespace DentalHealthCenter.Core.Application.Utilities.Mediator
{
    public interface IMediator
    {
        Task<TResponse> Send<TResponse>(IRequest<TResponse> request);
    }
}
