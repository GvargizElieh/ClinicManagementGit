using Application.Utilities;

namespace Application.Schedules.Create
{
    public record CreateScheduleCommand(long PersonId, string Title, string Description, DateTime StartTime, DateTime EndTime) : IBaseCommand<long>;
}
