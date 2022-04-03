using Application.Schedules.Create;
using Application.Utilities;
using Query.Schedules.DTOs;

namespace Facade.Schedules
{
    public interface IScheduleFacade
    {
        Task<OperationResult<long>> AddSchedule(CreateScheduleCommand command);

        Task<ICollection<ScheduleDto>> GetSchedules();
        Task<ScheduleDto> GetSchedule(long id);
    }
}
