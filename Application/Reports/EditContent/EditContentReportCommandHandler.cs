using Application.Utilities;
using Domain.Reports.Repository;

namespace Application.Reports.EditContent
{
    public class EditContentReportCommandHandler : IBaseCommandHandler<EditContentReportCommand, long>
    {
        private readonly IReportRepository repository;

        public EditContentReportCommandHandler(IReportRepository repository)
        {
            this.repository = repository;
        }

        public async Task<OperationResult<long>> Handle(EditContentReportCommand request, CancellationToken cancellationToken)
        {
            var report = await repository.GetTrackingAsync(request.ReportId);
            if (report == null)
                return OperationResult<long>.NotFound();

            report.EditContent(request.Content);
            await repository.SaveAsync();
            return OperationResult<long>.Success(report.Id);
        }
    }
}
