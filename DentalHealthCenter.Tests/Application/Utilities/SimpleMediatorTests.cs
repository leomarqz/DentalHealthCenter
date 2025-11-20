

using DentalHealthCenter.Core.Application.Exceptions;
using DentalHealthCenter.Core.Application.Utilities.Mediator;
using FluentValidation;
using NSubstitute;
using System;

namespace DentalHealthCenter.Tests.Application.Utilities
{
    [TestClass]
    public class SimpleMediatorTests
    {
        //comando
        public class FalseRequest : IRequest<string>
        {
            public required string Name { get; set; }
        }

        // manejador de las request y su comando
        public class HandlerTest : IRequestHandler<FalseRequest, string>
        {
            public Task<string> Handle(FalseRequest command)
            {
                return Task.FromResult("Handled");
            }
        }

        public class FalseValidatorTest : AbstractValidator<FalseRequest>
        {
            public FalseValidatorTest()
            {
                RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty");
            }
        }

        [TestMethod]
        public async Task Send_InvokeHandlerMethod_ReturnsExpectedResponse()
        {
            var commandRequest = new FalseRequest { Name = "Test" };

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
            var commandRequest = new FalseRequest() { Name = "Test 2" };

            var useCase = Substitute.For<IRequestHandler<FalseRequest, string>>();

            var serviceProvider = Substitute.For<IServiceProvider>();


            var mediator = new SimpleMediator(serviceProvider);

            var result = await mediator.Send(commandRequest);

        }

        [TestMethod]
        //[ExpectedException(typeof(ErrorValidationException))]
        public async Task Send_InValidCommand_ThrowsErrorValidationException()
        {
            var commandRequest = new FalseRequest { Name = "" };
            var serviceProvider = Substitute.For<IServiceProvider>();
            var validator = new FalseValidatorTest();

            serviceProvider
                .GetService(typeof(IValidator<FalseRequest>))
                .Returns(validator);

            var mediator = new SimpleMediator(serviceProvider);

            await Assert.ThrowsExceptionAsync<ErrorValidationException>(async () =>
            {
                await mediator.Send(commandRequest);
            });
        }


    }
}
