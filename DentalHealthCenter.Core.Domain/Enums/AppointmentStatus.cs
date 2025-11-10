
namespace DentalHealthCenter.Core.Domain.Enums
{
    // Estado de la cita
    public enum AppointmentStatus
    {
        /// <summary>
        /// Indicates that the operation or event is scheduled to occur but has not yet started.
        /// </summary>
        Scheduled = 1, //Programada

        /// <summary>
        /// Indicates that the operation has completed successfully.
        /// </summary>
        Completed = 2, //Completada

        /// <summary>
        /// Indicates that the operation was canceled before completion.
        /// </summary>
        Canceled = 3 //Cancelada
    }
}
