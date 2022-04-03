using Domain.Reports;
using Domain.Reports.Repository;
using Infrastructure.Utilities;

namespace Infrastructure.Persistent.EF.Reports
{
    public class ReportRepository : BaseRepository<Report>, IReportRepository
    {
        public ReportRepository(ClinicContext context) : base(context)
        {
        }
    }
}
