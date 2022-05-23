using ClinicManagement.Data.People;

namespace ClinicManagement.Data.Schedules
{
    public class Schedule : BaseData
    {
        public long PersonId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public virtual Person? Person { get; set; }
    }
}
