

using DentalHealthCenter.Core.Application.Exceptions;
using DentalHealthCenter.Core.Application.Utilities.Mediator;
using NSubstitute;
using System;

namespace DentalHealthCenter.Tests.Application.Utilities
{
    [TestClass]
    public class SimpleMediatorTests
    {
        //comando
        public class FalseRequest : IRequest<string> { }

        // manejador de las request y su comando
        public class HandlerTest : IRequestHandler<FalseRequest, string>
        {
            public Task<string> Handle(FalseRequest command)
            {
                return Task.FromResult("Handled");
            }
        }

        [TestMethod]
        public async Task Send_InvokeHandlerMethod_ReturnsExpectedResponse()
        {
            var commandRequest = new FalseRequest();

            var useCase = Substitute.For<IRequestHandler<FalseRequest, string>>();

            var serviceProvider = Substitute.For<IServiceProvider>();

            serviceProvider
                .GetService(typeof(IRequestHandler<FalseRequest, string>))
                .Returns(useCase);

            var mediator = new SimpleMediator(serviceProvider);

            var result = await mediator.Send(commandRequest);

            await useCase.Received(1).Handle(commandRequest);
        }

        [TestMethod]
        [ExpectedException(typeof(MediatorException))]
        public async Task Send_NoHandlerFound_ThrowsMediatorException()
        {
            var commandRequest = new FalseRequest();

            var useCase = Substitute.For<IRequestHandler<FalseRequest, string>>();

            var serviceProvider = Substitute.For<IServiceProvider>();


            var mediator = new SimpleMediator(serviceProvider);

            var result = await mediator.Send(commandRequest);


        }
    }
}
