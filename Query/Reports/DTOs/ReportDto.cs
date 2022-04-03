using Domain.Reports.Enums;
using Query.People.DTOs;
using Query.Utilities;

namespace Query.Reports.DTOs
{
    public class ReportDto : BaseDto
    {
        public long PersonId { get; set; }
        public string Issue { get; set; }
        public string Content { get; set; }
        public ReportType ReportType { get; set; }
        public DateTime ReportDate { get; set; }
        public virtual PersonDto Person { get; set; }
    }
}
