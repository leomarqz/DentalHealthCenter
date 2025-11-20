
using System.Threading.Tasks;

namespace DentalHealthCenter.Core.Application.Utilities.Mediator
{
    public interface IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        Task<TResponse> Handle(TRequest request);
    }
}
