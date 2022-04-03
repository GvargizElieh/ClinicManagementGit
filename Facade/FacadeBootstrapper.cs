using Facade.Financials;
using Facade.People;
using Facade.Reports;
using Facade.Schedules;
using Microsoft.Extensions.DependencyInjection;

namespace Facade
{
    public static class FacadeBootstrapper
    {
        public static void InitFacadeDependency(this IServiceCollection services)
        {
            services.AddScoped<IFinancialFacade, FinancialFacade>();
            services.AddScoped<IPersonFacade, PersonFacade>();
            services.AddScoped<IReportFacade, ReportFacade>();
            services.AddScoped<IScheduleFacade, ScheduleFacade>();
        }
    }
}