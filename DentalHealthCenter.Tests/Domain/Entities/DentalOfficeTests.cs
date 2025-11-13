

using DentalHealthCenter.Core.Domain.Entities;
using DentalHealthCenter.Core.Domain.Exceptions;

namespace DentalHealthCenter.Tests.Domain.Entities
{
    [TestClass]
    public class DentalOfficeTests
    {
        [TestMethod]
        [ExpectedException(typeof(BusinessRuleException))]
        // Validamos que el nombre del consultorio no sea nulo o vacio
        public void CreateDentalOffice_WithEmptyName_ShouldThrowBusinessRuleException()
        {
            string name = string.Empty;
            new DentalOffice(name: name);
        }

        //validamos que se cree correctamente un consultorio dental con un nombre valido
        [TestMethod]
        public void CreateDentalOffice_WithValidName_ShouldCreateDentalOffice()
        {
            string name = "Consultorio Central";
            var dentalOffice = new DentalOffice(name: name);
            Assert.IsNotNull(dentalOffice);
            Assert.AreEqual(name, dentalOffice.Name);
        }
    }
}
