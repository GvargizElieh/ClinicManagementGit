using Application.Utilities;
using Domain.Reports.Repository;

namespace Application.Reports.AddContent
{
    public class AddContentReportCommandHandler : IBaseCommandHandler<AddContentReportCommand, long>
    {
        private readonly IReportRepository repository;

        public AddContentReportCommandHandler(IReportRepository repository)
        {
            this.repository = repository;
        }

        public async Task<OperationResult<long>> Handle(AddContentReportCommand request, CancellationToken cancellationToken)
        {
            var report = await repository.GetTrackingAsync(request.ReportId);
            if (report == null)
                return OperationResult<long>.NotFound();

            report.AddContent(request.Content);
            await repository.SaveAsync();
            return OperationResult<long>.Success(report.Id);

        }
    }
}
