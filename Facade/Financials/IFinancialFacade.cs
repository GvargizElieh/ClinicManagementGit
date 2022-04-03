using Application.Financials.Cancel;
using Application.Financials.Create;
using Application.Financials.Pay;
using Application.Utilities;
using Query.Financials.DTOs;

namespace Facade.Financials
{
    public interface IFinancialFacade
    {
        Task<OperationResult<long>> AddFinancial(CreateFinancialCommand command);
        Task<OperationResult<long>> Pay(PayFinancialCommand command);
        Task<OperationResult<long>> Cancel(CancelFinancialCommand command);

        Task<ICollection<FinancialDto>> GetFinancials();
        Task<FinancialDto> GetFinancial(long id);
    }
}
