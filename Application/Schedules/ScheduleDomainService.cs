using Domain.Schedules.Repository;
using Domain.Schedules.Services;

namespace Application.Schedules
{
    public class ScheduleDomainService : IScheduleDomainServices
    {
        private readonly IScheduleRepository repository;

        public ScheduleDomainService(IScheduleRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> IsTimeDuplicated(DateTime time)
        {
            return await repository.ExistsAsync(schedule => schedule.StartTime == time);
        }
    }
}
