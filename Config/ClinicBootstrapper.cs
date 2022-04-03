using Application.People;
using Application.Schedules;
using Application.Utilities;
using Domain.People.Services;
using Domain.Schedules.Services;
using Facade;
using FluentValidation;
using Infrastructure;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Query.Utilities;

namespace Config
{
    public static class ClinicBootstrapper
    {
        public static void RegisterClinicDependency(this IServiceCollection services, string connectionString)
        {
            InfrastructureBootstrapper.Init(services, connectionString);

            services.AddMediatR(typeof(OperationResult).Assembly);
            services.AddMediatR(typeof(BaseDto).Assembly);

            services.AddTransient<IPersonDomainService, PersonDomainService>();
            services.AddTransient<IScheduleDomainServices, ScheduleDomainService>();

            services.AddValidatorsFromAssembly(typeof(OperationResult).Assembly);

            services.InitFacadeDependency();
        }
    }
}