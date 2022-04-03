using Query.Financials;
using Query.Financials.DTOs;
using Query.Utilities;

namespace Query.Financials.GetAll
{
    public record GetAllFinancialsQuery : IBaseQuery<ICollection<FinancialDto>>;
}
