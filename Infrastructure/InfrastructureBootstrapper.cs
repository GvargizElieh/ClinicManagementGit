using Domain.Financials.Repository;
using Domain.People.Repository;
using Domain.Reports.Repository;
using Domain.Schedules.Repository;
using Infrastructure.Persistent.EF;
using Infrastructure.Persistent.EF.Financials;
using Infrastructure.Persistent.EF.People;
using Infrastructure.Persistent.EF.Reports;
using Infrastructure.Persistent.EF.Schedules;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public class InfrastructureBootstrapper
    {
        public static void Init(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IFinancialRepository, FinancialRepository>();
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<IReportRepository, ReportRepository>();
            services.AddTransient<IScheduleRepository, ScheduleRepository>();

            services.AddDbContext<ClinicContext>(option =>
            {
                option.UseSqlServer(connectionString);
            });
        }
    }
}