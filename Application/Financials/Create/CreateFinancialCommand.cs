using Application.Utilities;

namespace Application.Financials.Create
{
    public record CreateFinancialCommand(string Payment, decimal PaymentAmount) : IBaseCommand<long>;
}
