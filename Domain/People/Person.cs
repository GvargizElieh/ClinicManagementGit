using Domain.Financials;
using Domain.People.Enums;
using Domain.People.Services;
using Domain.Reports;
using Domain.Schedules;
using Domain.Utilities;

namespace Domain.People
{
    public class Person : BaseEntity
    {
        internal Person()
        {
            
        }

        public Person(string name, string family, string nationalId, Gender gender, DateTime birthDate, IPersonDomainService domainService)
        {
            Guard(nationalId, domainService);
            Name = name;
            Family = family;
            NationalId = nationalId;
            Gender = gender;
            BirthDate = birthDate;
            Financials = new List<Financial>();
            Reports = new List<Report>();
            Schedules = new List<Schedule>();
        }

        public string Name { get; private set; }
        public string Family { get; private set; }
        public string NationalId { get; private  set; }
        public string? ParentName { get; private set; }
        public Gender Gender { get; private set; }
        public DateTime BirthDate { get; private set; }
        public virtual ICollection<Financial> Financials { get; internal set; }
        public virtual ICollection<Report> Reports { get; internal set; }
        public virtual ICollection<Schedule> Schedules { get; internal set; }


        private async void Guard(string nationalId, IPersonDomainService domainService)
        {
            if (await domainService.IsNationalIdDuplicated(nationalId))
                throw new InvalidDataException($"NationalId {nationalId} is duplicated!");
        }

        public void AssingnFinancial(Financial financial)
        {
            financial.AssignPerson(this);
            Financials.Add(financial);
        }

        public void AssignReport(Report report)
        {
            report.AssignPerson(this);
            Reports.Add(report);
        }

        public void AssignSchedule(Schedule schedule)
        {
            schedule.AssignPerson(this);
            Schedules.Add(schedule);
        }
    }
}
