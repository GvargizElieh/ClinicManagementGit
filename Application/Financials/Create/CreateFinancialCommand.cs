using Application.Utilities;

namespace Application.Financials.Create
{
    public record CreateFinancialCommand(long PersonId, string Payment, decimal PaymentAmount) : IBaseCommand<long>;
}
