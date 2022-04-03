using Application.Reports.AddContent;
using Application.Reports.Create;
using Application.Reports.EditContent;
using Application.Utilities;
using Query.Reports.DTOs;

namespace Facade.Reports
{
    public interface IReportFacade
    {
        Task<OperationResult<long>> AddRepotAsync(CreateReportCommand command);
        Task<OperationResult<long>> AddContentToReportAsync(AddContentReportCommand command);
        Task<OperationResult<long>> EditContentOfReportAsync(EditContentReportCommand command);

        Task<ICollection<ReportDto>> GetReportsAsync();
        Task<ReportDto> GetReportAsync(long id);
    }
}
