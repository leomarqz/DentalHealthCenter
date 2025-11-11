
using DentalHealthCenter.Core.Domain.Enums;
using DentalHealthCenter.Core.Domain.ValueObjects;
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
        public TimeInterval TimeInterval { get; private set; }

        public Patient? Patient { get; private set; } //Propiedad de navegación (Paciente)
        public Dentist? Dentist { get; private set; } //Propiedad de navegación (Dentista)
        public DentalOffice? Office { get; private set; } //Propiedad de navegación (Consultorio Dental)

        public Appointment(Guid patientId, Guid dentistId, Guid officeId, TimeInterval timeInterval)
        {
            // regla propia de este caso de uso
            if (timeInterval.Start < DateTime.Now)
            {
                // Lanzar una excepción si la fecha de inicio es en el pasado
                throw new ArgumentException("Start date cannot be in the past.");
            }

            Id = Guid.NewGuid();
            PatientId = patientId;
            DentistId = dentistId;
            OfficeId = officeId;
            Status = AppointmentStatus.Scheduled; //Estado inicial de la cita
            TimeInterval = timeInterval; //Intervalo de tiempo de la cita
        }

        public void Cancel()
        {
            if(Status != AppointmentStatus.Scheduled)
            {
                // Lanzar una excepción si la cita no está en estado "Programada"
                // Status: Scheduled, Completed, Canceled
                throw new InvalidOperationException("Only scheduled appointments can be canceled.");
            }

            Status = AppointmentStatus.Canceled;
        }

        public void Complete()
        {
            if(Status != AppointmentStatus.Scheduled)
            {
                // Lanzar una excepción si la cita no está en estado "Programada"
                throw new InvalidOperationException("Only scheduled appointments can be completed.");
            }

            Status = AppointmentStatus.Completed;
        }

    }
}
