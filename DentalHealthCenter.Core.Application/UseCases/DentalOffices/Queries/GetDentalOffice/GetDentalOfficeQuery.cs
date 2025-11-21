
using System;
using DentalHealthCenter.Core.Application.Utilities.Mediator;

namespace DentalHealthCenter.Core.Application.UseCases.DentalOffices.Queries.GetDentalOffice
{
    public class GetDentalOfficeQuery : IRequest<DentalOfficeDTO>
    {
        public Guid Id { get; set; }
    }
}
