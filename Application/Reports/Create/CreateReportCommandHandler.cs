using Application.Utilities;
using Domain.Reports;
using Domain.Reports.Repository;

namespace Application.Reports.Create
{
    public class CreateReportCommandHandler : IBaseCommandHandler<CreateReportCommand, long>
    {
        private readonly IReportRepository repository;

        public CreateReportCommandHandler(IReportRepository repository)
        {
            this.repository = repository;
        }

        public async Task<OperationResult<long>> Handle(CreateReportCommand request, CancellationToken cancellationToken)
        {
            var report=new Report(request.Issue, request.Content, request.Type, request.ReportDate);
            await repository.AddAsync(report);
            await repository.SaveAsync();
            return OperationResult<long>.Success(report.Id);
        }
    }
}
