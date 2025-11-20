
using DentalHealthCenter.Core.Application.Contracts.Persistence;
using DentalHealthCenter.Core.Application.Contracts.Repositories;
using DentalHealthCenter.Core.Application.Exceptions;
using DentalHealthCenter.Core.Domain.Entities;
using FluentValidation;
using System;
using System.Threading.Tasks;

namespace DentalHealthCenter.Core.Application.UseCases.Office.Commands.CreateDentalOffice
{
    public class UseCaseCreateDentalOffice
    {
        private readonly IDentalOfficeRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<CreateDentalOfficeCommand> _validator;

        public UseCaseCreateDentalOffice(
            IDentalOfficeRepository repository, IUnitOfWork unitOfWork, 
            IValidator<CreateDentalOfficeCommand> validator)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<Guid> Handle(CreateDentalOfficeCommand command)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(command);

                if (!validationResult.IsValid)
                {
                    throw new ErrorValidationException(validationResult);
                }

                var office = new DentalOffice(command.Name);
                var response = await _repository.Add(office);

                await _unitOfWork.Commit();

                return response.Id;
            }catch (Exception ex)
            {
                await _unitOfWork.Rollback();
                throw;
            }
        }
    }
}
