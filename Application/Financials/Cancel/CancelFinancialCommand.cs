using Application.Utilities;

namespace Application.Financials.Cancel
{
    public record CancelFinancialCommand(long FinancialId) : IBaseCommand<long>;
}
