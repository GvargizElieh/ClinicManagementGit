using Query.Schedules.DTOs;
using Query.Utilities;

namespace Query.Schedules.GetById
{
    public record GetByIdScheduleQuery(long ScheduleId) : IBaseQuery<ScheduleDto>;
}
