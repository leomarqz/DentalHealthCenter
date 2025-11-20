

using DentalHealthCenter.Core.Application.Utilities.Mediator;
using System;

namespace DentalHealthCenter.Core.Application.UseCases.DentalOffices.Commands.CreateDentalOffice
{
    public class CreateDentalOfficeCommand : IRequest<Guid>
    {
        public required string Name { get; set; }
    }
}
