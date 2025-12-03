
using DentalHealthCenter.Core.Application.Contracts.Persistence;
using DentalHealthCenter.Core.Application.Contracts.Repositories;
using DentalHealthCenter.Core.Application.Exceptions;
using DentalHealthCenter.Core.Application.Utilities.Mediator;
using DentalHealthCenter.Core.Domain.Entities;
using FluentValidation;
using System;
using System.Threading.Tasks;

namespace DentalHealthCenter.Core.Application.UseCases.DentalOffices.Commands.CreateDentalOffice
{
    public class UseCaseCreateDentalOffice : IRequestHandler<CreateDentalOfficeCommand, Guid>
    {
        private readonly IDentalOfficeRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UseCaseCreateDentalOffice(
            IDentalOfficeRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateDentalOfficeCommand command)
        {
            try
            {
                var office = new DentalOffice(command.Name);
                var response = await _repository.Add(office);

                await _unitOfWork.CommitAsync();

                return response.Id;
            }catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }
    }
}
