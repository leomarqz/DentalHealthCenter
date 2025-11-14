

using DentalHealthCenter.Core.Domain.Entities;
using DentalHealthCenter.Core.Domain.Exceptions;
using DentalHealthCenter.Core.Domain.ValueObjects;

namespace DentalHealthCenter.Tests.Domain.Entities
{
    [TestClass]
    public class PatientTests
    {

        [TestMethod]
        [ExpectedException(typeof(BusinessRuleException))]
        // Validamos que el nombre del paciente no sea nulo o vacio
        public void CreatePatient_WithEmptyName_ShouldThrowBusinessRuleException()
        {
            string emptyName = "";
            var email = new Email("example@email.com");

            new Patient(emptyName, email);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessRuleException))]
        // Validamos que el email del paciente no sea nulo
        public void CreatePatient_WithNullEmail_ShouldThrowBusinessRuleException()
        {
            string name = "John Doe";
            Email nullEmail = null!;
            new Patient(name, nullEmail);
        }

        [TestMethod]
        // Validamos la creación exitosa de un paciente con datos válidos
        public void CreatePatient_WithValidData_ShouldCreatePatientSuccessfully()
        {
            string name = "Leo Marqz";
            var email = new Email("leomarqz@gmail.com");

            var patient = new Patient(name, email);

            Assert.AreEqual(name, patient.Name);
            Assert.AreEqual(email, patient.Email);
        }
    }
}
