
using DentalHealthCenter.Core.Application.Exceptions;
using System;
using System.Threading.Tasks;

namespace DentalHealthCenter.Core.Application.Utilities.Mediator
{
    public class SimpleMediator : IMediator
    {
        private readonly IServiceProvider _serviceProdiver;

        public SimpleMediator(IServiceProvider serviceProvider)
        {
            _serviceProdiver = serviceProvider;
        }

        public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
        {
            var useCaseType = typeof(IRequestHandler<,>)
                .MakeGenericType(request.GetType(), typeof(TResponse));

            var useCase = _serviceProdiver.GetService(useCaseType);

            if(useCase is null)
            {
                throw new MediatorException($"No se encontro un handler para {request.GetType().Name}");
            }

            var handlerMethod = useCaseType.GetMethod("Handle")!;

            return await (Task<TResponse>) handlerMethod.Invoke(useCase, new object[] { request })!;
        }
    }
}
