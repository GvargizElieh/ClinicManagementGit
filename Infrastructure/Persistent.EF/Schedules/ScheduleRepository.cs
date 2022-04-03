using Domain.Schedules;
using Domain.Schedules.Repository;
using Infrastructure.Utilities;

namespace Infrastructure.Persistent.EF.Schedules
{
    public class ScheduleRepository : BaseRepository<Schedule>, IScheduleRepository
    {
        public ScheduleRepository(ClinicContext context) : base(context)
        {
        }
    }
}
