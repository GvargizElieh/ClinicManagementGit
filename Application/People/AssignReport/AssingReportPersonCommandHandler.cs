using Application.Utilities;
using Domain.People.Repository;
using Domain.Reports.Repository;

namespace Application.People.AssignReport
{
    public class AssingReportPersonCommandHandler : IBaseCommandHandler<AssingReportPersonCommand>
    {
        private readonly IPersonRepository personRepository;
        private readonly IReportRepository reportRepository;

        public AssingReportPersonCommandHandler(IPersonRepository personRepository, IReportRepository reportRepository)
        {
            this.personRepository = personRepository;
            this.reportRepository = reportRepository;
        }

        public async Task<OperationResult> Handle(AssingReportPersonCommand request, CancellationToken cancellationToken)
        {
            var person = await personRepository.GetAsync(request.PesonId);
            if (person == null)
                return OperationResult.NotFound(OperationResult.NotFoundMessage);

            var report = await reportRepository.GetTrackingAsync(request.ReportId);
            if (report == null)
                return OperationResult.NotFound(OperationResult.NotFoundMessage);

            person.AssignReport(report);
            await reportRepository.SaveAsync();
            return OperationResult.Success();
        }
    }
}
