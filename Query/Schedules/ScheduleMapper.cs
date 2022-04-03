using Domain.Schedules;
using Query.People;
using Query.Schedules.DTOs;

namespace Query.Schedules
{
    public static class ScheduleMapper
    {
        public static ScheduleDto Map(this Schedule? schedule)
        {
            if(schedule == null)
                return new ScheduleDto();

            return new ScheduleDto()
            {
                Id = schedule.Id,
                CreationDate = schedule.CreationDate,
                PersonId = schedule.PersonId,
                Title = schedule.Title,
                Description = schedule.Description,
                StartTime = schedule.StartTime,
                EndTime = schedule.EndTime,
                Person = schedule.Person.Map(),
            };
        }

        public static ICollection<ScheduleDto> Map(this ICollection<Schedule> schedules)
        {
            var model = new List<ScheduleDto>();

            foreach (Schedule schedule in schedules)
            {
                model.Add(Map(schedule));
            }

            return model;
        }
    }
}
