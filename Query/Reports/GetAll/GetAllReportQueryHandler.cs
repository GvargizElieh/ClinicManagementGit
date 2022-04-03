using Infrastructure.Persistent.EF;
using Microsoft.EntityFrameworkCore;
using Query.Reports.DTOs;
using Query.Utilities;

namespace Query.Reports.GetAll
{
    public class GetAllReportQueryHandler : IBaseQueryHandler<GetAllReportQuery, ICollection<ReportDto>>
    {
        private readonly ClinicContext context;

        public GetAllReportQueryHandler(ClinicContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<ReportDto>> Handle(GetAllReportQuery request, CancellationToken cancellationToken)
        {
            var model = await  context.Reports.ToListAsync(cancellationToken);
            return model.Map();
        }
    }
}
