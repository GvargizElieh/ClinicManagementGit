using Application.Utilities;
using Domain.Reports.Enums;

namespace Application.Reports.Create
{
    public record CreateReportCommand(string Issue, string Content, ReportType Type, DateTime ReportDate) : IBaseCommand<long>;
}
