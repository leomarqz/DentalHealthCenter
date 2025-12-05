

using DentalHealthCenter.Core.Application.Contracts.Repositories;
using DentalHealthCenter.Core.Application.UseCases.DentalOffices.Queries.GetAllDentalOffices;
using DentalHealthCenter.Core.Domain.Entities;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;

namespace DentalHealthCenter.Tests.Application.UseCases.DentalOffices
{
    [TestClass]
    public class UseCaseGetAllDentalOfficesTests
    {
        private IDentalOfficeRepository repository;
        private UseCaseGetListDentalOffices usecase;

        [TestInitialize]
        public void Setup()
        {
            this.repository = Substitute.For<IDentalOfficeRepository>();
            this.usecase = new UseCaseGetListDentalOffices(this.repository);
        }

        [TestMethod]
        public async Task Handle_WhenThereAreDentalOffices_ReturnListOfDentalOfficeDTO()
        {
            var offices = new List<DentalOffice>();
            
            offices.Add( new DentalOffice("Office #1") );
            offices.Add( new DentalOffice("Office #2") );

            this.repository.ToListAsync().Returns( offices );

            var expected = offices.Select((c) => new DentalOfficeDTO
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();

            var result = await this.usecase.Handle(new GetListDentalOfficesQuery());

            Assert.AreEqual(expected.Count, result.Count);

            for(int i=0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].Name, result[i].Name);
            }

        }

        [TestMethod]
        public async Task Handle_WhenThereAreNotDentalOffices_ReturnAnEmptyList()
        {
            this.repository.ToListAsync().Returns(new List<DentalOffice>());

            var result = await this.usecase.Handle( new GetListDentalOfficesQuery() );

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);

        }


    }
}
