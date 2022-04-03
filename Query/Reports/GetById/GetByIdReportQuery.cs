using Query.Reports.DTOs;
using Query.Utilities;

namespace Query.Reports.GetById
{
    public record GetByIdReportQuery(long ReportId) : IBaseQuery<ReportDto>;
}
