using Application.Utilities;

namespace Application.People.AssignReport
{
    public record AssingReportPersonCommand(long PesonId, long ReportId) : IBaseCommand;
}
