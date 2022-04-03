using Domain.People.Enums;
using Query.Financials.DTOs;
using Query.Reports.DTOs;
using Query.Schedules.DTOs;
using Query.Utilities;

namespace Query.People.DTOs
{
    public class PersonDto : BaseDto
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string NationalId { get; set; }
        public string? ParentName { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public virtual ICollection<FinancialDto> Financials { get; set; }
        public virtual ICollection<ReportDto> Reports { get; set; }
        public virtual ICollection<ScheduleDto> Schedules { get; set; }
    }
}
