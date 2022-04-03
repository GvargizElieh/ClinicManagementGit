using Domain.People;
using Domain.Reports.Enums;
using Domain.Utilities;

namespace Domain.Reports
{
    public class Report : BaseEntity
    {
        internal Report()
        {

        }

        public Report(string issue, string content, ReportType type, DateTime reportDate)
        {
            Issue = issue;
            Content = content;
            ReportType = type;
            ReportDate = reportDate;
            Person = new Person();
        }

        public long PersonId { get; internal set; }
        public string Issue { get; private set; }
        public string Content { get; private set; }
        public ReportType ReportType { get; private set; }
        public DateTime ReportDate { get; private set; }
        public virtual Person Person { get; internal set; }

        public void AddContent(string content)
        {
            Content += content;
        }

        public void EditContent(string content)
        {
            Content = content;
        }
    }
}
