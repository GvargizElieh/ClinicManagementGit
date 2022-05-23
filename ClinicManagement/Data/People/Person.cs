using ClinicManagement.Data.Financials;
using ClinicManagement.Data.People.Enums;
using ClinicManagement.Data.Reports;
using ClinicManagement.Data.Schedules;

namespace ClinicManagement.Data.People
{
    public class Person
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string NationalId { get; set; }
        public string? ParentName { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public virtual ICollection<Financial?> Financials { get; set; }
        public virtual ICollection<Report?> Reports { get; set; }
        public virtual ICollection<Schedule?> Schedules { get; set; }
    }
}
