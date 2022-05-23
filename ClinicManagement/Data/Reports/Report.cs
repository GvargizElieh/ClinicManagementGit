using ClinicManagement.Data.People;
using ClinicManagement.Data.Reports.Enums;

namespace ClinicManagement.Data.Reports
{
    public class Report : BaseData
    {
        public long PersonId { get; set; }
        public string Issue { get; set; }
        public string Content { get; set; }
        public ReportType ReportType { get; set; }
        public DateTime ReportDate { get; set; }
        public virtual Person? Person { get; set; }
    }
}
