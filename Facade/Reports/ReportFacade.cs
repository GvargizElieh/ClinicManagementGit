using Application.Reports.AddContent;
using Application.Reports.Create;
using Application.Reports.EditContent;
using Application.Utilities;
using MediatR;
using Query.Reports.DTOs;
using Query.Reports.GetAll;
using Query.Reports.GetById;

namespace Facade.Reports
{
    public class ReportFacade : IReportFacade
    {
        private readonly IMediator mediator;

        public ReportFacade(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<OperationResult<long>> AddContentToReportAsync(AddContentReportCommand command)
        {
            return await mediator.Send(command);
        }

        public async Task<OperationResult<long>> AddRepotAsync(CreateReportCommand command)
        {
            return await mediator.Send(command);
        }

        public async Task<OperationResult<long>> EditContentOfReportAsync(EditContentReportCommand command)
        {
            return await mediator.Send(command);
        }

        public async Task<ReportDto> GetReportAsync(long id)
        {
            return await mediator.Send(new GetByIdReportQuery(id));
        }

        public async Task<ICollection<ReportDto>> GetReportsAsync()
        {
            return await mediator.Send(new GetAllReportQuery());
        }
    }
}
