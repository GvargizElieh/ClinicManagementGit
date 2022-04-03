using Application.Utilities;

namespace Application.Reports.EditContent
{
    public record EditContentReportCommand(long ReportId, string Content) : IBaseCommand<long>;
}
