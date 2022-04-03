using Query.Reports.DTOs;
using Query.Utilities;

namespace Query.Reports.GetAll
{
    public record GetAllReportQuery : IBaseQuery<ICollection<ReportDto>>;
}
