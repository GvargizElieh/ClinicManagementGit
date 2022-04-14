using Application.Utilities;
using Domain.Reports.Enums;

namespace Application.Reports.Create
{
    public record CreateReportCommand(long PersonId, string Issue, string Content, ReportType Type, DateTime ReportDate) : IBaseCommand<long>;
}
