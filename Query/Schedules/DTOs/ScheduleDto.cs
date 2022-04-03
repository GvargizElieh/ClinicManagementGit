using Query.People.DTOs;
using Query.Utilities;

namespace Query.Schedules.DTOs
{
    public class ScheduleDto : BaseDto
    {
        public long PersonId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public virtual PersonDto Person { get; set; }
    }
}
