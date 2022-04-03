using Query.Financials.DTOs;
using Query.Utilities;

namespace Query.Financials.GetById
{
    public record GertByIdFinancialQuery(long FinancialId) : IBaseQuery<FinancialDto>;
}
