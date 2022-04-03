using Application.Utilities;

namespace Application.Financials.Pay
{
    public record PayFinancialCommand(long FinancialId, decimal PayAmount) : IBaseCommand<long>;
}
