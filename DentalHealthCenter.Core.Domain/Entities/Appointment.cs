
using DentalHealthCenter.Core.Domain.Enums;
using System;

namespace DentalHealthCenter.Core.Domain.Entities
{
    public class Appointment
    {
        public Guid Id { get; private set; }
        public Guid PatientId { get; private set; }
        public Guid DentistId { get; private set; }
        public Guid OfficeId { get; private set; }
        public AppointmentStatus Status { get; private set; } //Estado de la cita
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public Patient? Patient { get; private set; } //Propiedad de navegación (Paciente)
        public Dentist? Dentist { get; private set; } //Propiedad de navegación (Dentista)
        public DentalOffice? Office { get; private set; } //Propiedad de navegación (Consultorio Dental)
    }
}
