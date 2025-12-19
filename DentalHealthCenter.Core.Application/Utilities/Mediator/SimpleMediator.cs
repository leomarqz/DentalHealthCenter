
using DentalHealthCenter.Core.Application.Exceptions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
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

            await HandleValidations(request);

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

        public async Task Send(IRequest request)
        {
            await HandleValidations(request);

            var useCaseType = typeof(IRequestHandler<>).MakeGenericType( request.GetType() );
            var useCase = _serviceProdiver.GetService(useCaseType);
            if(useCase is null)
            {
                throw new MediatorException($"No se encontro un handler para {request.GetType().Name}");
            }
            var method = useCaseType.GetMethod("Handle")!;
            await (Task)method.Invoke(useCase, new object[] { request })!;
        }

        private async Task HandleValidations(object request)
        {
            var validatorType = typeof(IValidator<>).MakeGenericType(request.GetType());

            var validator = _serviceProdiver.GetService(validatorType);

            if (validator is not null)
            {
                var validateAsyncMethod = validatorType.GetMethod("ValidateAsync");
                var validatorTask = (Task)validateAsyncMethod!
                    .Invoke(validator, new object[] { request, CancellationToken.None })!;

                await validatorTask.ConfigureAwait(false);

                var result = validatorTask.GetType().GetProperty("Result");

                var validationResult = (ValidationResult)result!.GetValue(validatorTask)!;

                if (!validationResult.IsValid)
                {
                    throw new ErrorValidationException(validationResult);
                }

            }
        }
    }
}
