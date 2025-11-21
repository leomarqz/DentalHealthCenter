
using NSubstitute;
using DentalHealthCenter.Core.Application.Contracts.Repositories;
using DentalHealthCenter.Core.Application.UseCases.DentalOffices.Queries.GetDentalOffice;
using DentalHealthCenter.Core.Domain.Entities;
using System;
using NSubstitute.ReturnsExtensions;
using DentalHealthCenter.Core.Application.Exceptions;

namespace DentalHealthCenter.Tests.Application.UseCases.DentalOffices
{
    [TestClass]
    public class UseCaseGetDentalOfficeTests
    {
        private IDentalOfficeRepository repository;
        private UseCaseGetDentalOffice useCase;

        [TestInitialize]
        public void Setup()
        {
            this.repository = Substitute.For<IDentalOfficeRepository>();
            this.useCase = new UseCaseGetDentalOffice(this.repository);
        }

        [TestMethod]
        public async Task Handle_ExistingDentalOffice_ReturnsDentalOfficeDTO()
        {
            //prepare
            var office = new DentalOffice("Dental Care #1");

            var id = office.Id;

            var query = new GetDentalOfficeQuery { Id = id };

            this.repository.GetById(id).Returns(office);

            // test
            var result = await this.useCase.Handle(query);

            // verificar
            Assert.IsNotNull(result);
            Assert.AreEqual(office.Id, result.Id);
            Assert.AreEqual(office.Name, result.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public async Task Handle_NonExistingDentalOffice_ThrowsNotFoundException()
        {
            //preparar
            var id = Guid.NewGuid();
            var query = new GetDentalOfficeQuery { Id = id };

            this.repository.GetById(id).ReturnsNull();

            await useCase.Handle(query);
        }
    }
}
