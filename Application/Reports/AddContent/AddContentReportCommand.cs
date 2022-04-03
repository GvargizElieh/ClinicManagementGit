using Application.Utilities;

namespace Application.Reports.AddContent
{
    public record AddContentReportCommand(long ReportId, string Content) : IBaseCommand<long>;
}
