using Domain.People;
using Domain.Schedules.Services;
using Domain.Utilities;

namespace Domain.Schedules
{
    public class Schedule : BaseEntity
    {
        internal Schedule()
        {
            
        }

        public Schedule(string title, string description, DateTime startTime, DateTime endTime, IScheduleDomainServices domainServices)
        {
            Guard(startTime, domainServices);
            Title = title;
            Description = description;
            StartTime = startTime;
            EndTime = endTime;
            Person = new Person();
        }

        public long PersonId { get; internal set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime? EndTime { get; private set; }
        public virtual Person Person { get; internal set; }

        private async void Guard(DateTime startTime, IScheduleDomainServices domainServices)
        {
            if(await  domainServices.IsTimeDuplicated(startTime))
                throw new InvalidDataException($"{nameof(StartTime)} is duplicated.");
        }

        public void AssignPerson(Person person)
        {
            PersonId = person.Id;
            Person = person;
        }
    }
}
