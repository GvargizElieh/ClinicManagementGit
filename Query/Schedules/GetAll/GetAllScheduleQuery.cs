using Query.Schedules.DTOs;
using Query.Utilities;

namespace Query.Schedules.GetAll
{
    public record GetAllScheduleQuery : IBaseQuery<ICollection<ScheduleDto>>;
}
