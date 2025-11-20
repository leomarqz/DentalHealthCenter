
using DentalHealthCenter.Core.Application.Contracts.Persistence;
using DentalHealthCenter.Core.Application.Contracts.Repositories;
using DentalHealthCenter.Core.Application.Exceptions;
using DentalHealthCenter.Core.Application.UseCases.DentalOffices.Commands.CreateDentalOffice;
using DentalHealthCenter.Core.Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System;

namespace DentalHealthCenter.Tests.Application.UseCases.DentalOffices
{
    [TestClass]
    public class UseCaseCreateDentalOfficeTests
    {
        private IDentalOfficeRepository _repository;
        private IUnitOfWork _unitOfWork;
        private UseCaseCreateDentalOffice _useCase;

        [TestInitialize]
        public void Setup()
        {
            _repository = Substitute.For<IDentalOfficeRepository>();
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _useCase = new UseCaseCreateDentalOffice(_repository, _unitOfWork);
        }

        [TestMethod] // Test for successful creation of a dental office
        public async Task Handle_ShouldCreateDentalOffice_WhenCommandIsValid()
        {
            var command = new CreateDentalOfficeCommand { Name = "Healthy Smiles" };


            var officeCreated = new DentalOffice("Healthy Smiles");

            _repository.Add(Arg.Any<DentalOffice>()).Returns(officeCreated);

            var result = await _useCase.Handle(command);

            await _repository.Received(1).Add(Arg.Any<DentalOffice>());
            await _unitOfWork.Received(1).Commit();

            Assert.AreNotEqual(Guid.Empty, result);

        }

        [TestMethod] // throw 
        public async Task Handle_ShouldThrowException_WhenCommandIsNotValid()
        {
            var command = new CreateDentalOfficeCommand { Name = string.Empty };

            //Error Manual
            var inValidResult = new ValidationResult(new[]
            {
                new ValidationFailure("Name", "El Nombre es obligatorio")
            });

            //Validamos si lanza la excepcion personalida
            await Assert.ThrowsExceptionAsync<ErrorValidationException>(async () =>
            {
                await _useCase.Handle(command);
            });

            // no recibimos nada en el repositorio
            await _repository.DidNotReceive().Add(Arg.Any<DentalOffice>());

        }

        [TestMethod] //validamos que se haga un rollback cuando se genera un error al persistir en la base de datos
        public async Task Handle_ShouldRollback_WhenErrorOccursWhileSaving()
        {
            var command = new CreateDentalOfficeCommand { Name = "Broken Office" };

            // Simulamos un error en el repositorio
            _repository.Add(Arg.Any<DentalOffice>()).Throws<Exception>();

            //Ejecutamos el caso de uso y validamos que lance la excepcion
            await Assert.ThrowsExceptionAsync<Exception>(async () =>
            {
                await _useCase.Handle(command);
            });

            // Validamos que se haya llamado a Rollback
            await _unitOfWork.Received(1).Rollback();
        }

    }
}
