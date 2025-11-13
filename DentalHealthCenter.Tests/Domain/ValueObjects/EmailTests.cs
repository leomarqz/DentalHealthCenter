using DentalHealthCenter.Core.Domain.Exceptions;
using DentalHealthCenter.Core.Domain.ValueObjects;

namespace DentalHealthCenter.Tests.Domain.ValueObjects
{
    [TestClass]
    public class EmailTests
    {
        [TestMethod]
        [ExpectedException(typeof(BusinessRuleException))]
        // al pasar un email vacio se lanza una excepcion (ValueObject -> Email)
        public void CreateEmail_WithEmptyString_ShouldThrowBusinessRuleException()
        {
            string email = string.Empty;

            new Email(email: email);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessRuleException))]
        // al pasar un email invalido se lanza una excepcion (ValueObject -> Email)
        public void CreateEmail_WithInvalidEmail_ShouldThrowBusinessRuleException()
        {
            string email = "invalid-email";
            new Email(email: email);
        }

    }
}
