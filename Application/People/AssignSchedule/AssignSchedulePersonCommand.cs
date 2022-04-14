using Application.Utilities;

namespace Application.People.AssignSchedule
{
    public record AssignSchedulePersonCommand(long PersonId, long ScheduleId) : IBaseCommand;
}
