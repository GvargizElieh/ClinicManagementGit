using Infrastructure.Persistent.EF;
using Microsoft.EntityFrameworkCore;
using Query.Reports.DTOs;
using Query.Utilities;

namespace Query.Reports.GetById
{
    public class GetByIdReportQueryHandler : IBaseQueryHandler<GetByIdReportQuery, ReportDto>
    {
        private readonly ClinicContext context;

        public GetByIdReportQueryHandler(ClinicContext context)
        {
            this.context = context;
        }

        public async Task<ReportDto> Handle(GetByIdReportQuery request, CancellationToken cancellationToken)
        {
            var model = await context.Reports.Include(report => report.Person).FirstOrDefaultAsync(report => report.Id == request.ReportId, cancellationToken);
            return model.Map();
        }
    }
}
