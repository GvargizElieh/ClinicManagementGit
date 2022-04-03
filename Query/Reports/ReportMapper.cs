using Domain.Reports;
using Query.People;
using Query.Reports.DTOs;

namespace Query.Reports
{
    public static class ReportMapper
    {
        public static ReportDto Map(this Report? report)
        {
            if (report == null)
                return new ReportDto();

            return new ReportDto()
            {
                Id = report.Id,
                CreationDate = report.CreationDate,
                PersonId = report.PersonId,
                Issue = report.Issue,
                Content = report.Content,
                ReportDate = report.ReportDate,
                ReportType = report.ReportType,
                Person = report.Person.Map(),
            };
        }

        public static ICollection<ReportDto> Map(this ICollection<Report> reports)
        {
            var model = new List<ReportDto>();

            foreach (Report report in reports)
            {
                model.Add(Map(report));
            }

            return model;
        }
    }
}
