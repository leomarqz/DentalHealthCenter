

using FluentValidation;

namespace DentalHealthCenter.Core.Application.UseCases.DentalOffices.Commands.CreateDentalOffice
{
    public class CreateDentalOfficeCommandValidator : AbstractValidator<CreateDentalOfficeCommand>
    {
        public CreateDentalOfficeCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("The Name cannot be empty.")
                .MaximumLength(50).WithMessage("The Name cannot exceed 50 characters.");
        }
    }
}
