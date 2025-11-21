
using DentalHealthCenter.Core.Application.UseCases.DentalOffices.Commands.CreateDentalOffice;
using DentalHealthCenter.Core.Application.UseCases.DentalOffices.Queries.GetDentalOffice;
using DentalHealthCenter.Core.Application.Utilities.Mediator;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DentalHealthCenter.Core.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IMediator, SimpleMediator>();

            //======================================================
            // COMMANDS ============================================
            //======================================================

            services.AddScoped<IRequestHandler<CreateDentalOfficeCommand, Guid>, UseCaseCreateDentalOffice>();


            //======================================================
            // QUERIES =============================================
            //======================================================

            services.AddScoped<IRequestHandler<GetDentalOfficeQuery, DentalOfficeDTO>, UseCaseGetDentalOffice>();



            return services;
        }
    }
}
