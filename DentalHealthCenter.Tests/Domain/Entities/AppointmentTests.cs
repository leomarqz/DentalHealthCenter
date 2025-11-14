

using DentalHealthCenter.Core.Domain.Entities;
using DentalHealthCenter.Core.Domain.Enums;
using DentalHealthCenter.Core.Domain.Exceptions;
using DentalHealthCenter.Core.Domain.ValueObjects;
using System;

namespace DentalHealthCenter.Tests.Domain.Entities
{
    [TestClass]
    public class AppointmentTests
    {
        private Guid _patientId = Guid.NewGuid();
        private Guid _dentistId = Guid.NewGuid();
        private Guid _officeId = Guid.NewGuid();
        private TimeInterval _interval = new TimeInterval(
                                                    DateTime.UtcNow, 
                                                    DateTime.UtcNow.AddDays(3)
                                                );

        [TestMethod]
        public void CreateAppointment_WithValidData_ShouldCreateAppointmentSuccessfully()
        {
            var appointment = new Appointment(_patientId, _dentistId, _officeId, _interval);

            Assert.AreEqual(_patientId, appointment.PatientId);
            Assert.AreEqual(_dentistId, appointment.DentistId);
            Assert.AreEqual(_officeId, appointment.OfficeId);
            Assert.AreEqual(_interval, appointment.TimeInterval);

            Assert.AreNotEqual(Guid.Empty, appointment.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessRuleException))]
        // Validamos si se lanza una excepción al crear una cita con un intervalo de tiempo inválido
        public void CreateAppointment_WithInvalidTimeInterval_ShouldThrowBusinessRuleException()
        {
            var invalidInterval = new TimeInterval(
                                            DateTime.UtcNow.AddDays(-1), 
                                            DateTime.UtcNow.AddDays(1)
                                        );
            
            new Appointment(_patientId, _dentistId, _officeId, invalidInterval);
        }

        [TestMethod]
        // Validamos que una cita se pueda cancelar correctamente
        public void CancelAppointment_ShouldSetStatusToCanceled()
        {
            var appointment = new Appointment(_patientId, _dentistId, _officeId, _interval);

            appointment.Cancel();

            Assert.AreEqual(AppointmentStatus.Canceled, appointment.Status);
        }

        [TestMethod]
        // Validamos que una cita se pueda completar correctamente
        public void CompleteAppointment_ShouldSetStatusToCompleted()
        {
            var appointment = new Appointment(_patientId, _dentistId, _officeId, _interval);

            appointment.Complete();

            Assert.AreEqual(AppointmentStatus.Completed, appointment.Status);
        }

    }
}
