
using DentalHealthCenter.Core.Domain.Entities;
using DentalHealthCenter.Core.Domain.Exceptions;
using DentalHealthCenter.Core.Domain.ValueObjects;

namespace DentalHealthCenter.Tests.Domain.Entities
{
    [TestClass]
    public class DentistTests
    {
        [TestMethod]
        [ExpectedException(typeof(BusinessRuleException))]
        // Validamos que el nombre del dentista no sea nulo o vacio
        public void CreateDentist_WithEmptyName_ShouldThrowBusinessRuleException()
        {
            string name = string.Empty;
            Email email = new Email("leomarqz@gmail.com");

            new Dentist(name: name, email: email );
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessRuleException))]
        // Validamos que el email del dentista no sea nulo
        public void CreateDentist_WithNullEmail_ShouldThrowBusinessRuleException()
        {
            string name = "Leomar Qz";
            Email email = null!;
            new Dentist(name: name, email: email);
        }

    }
}
