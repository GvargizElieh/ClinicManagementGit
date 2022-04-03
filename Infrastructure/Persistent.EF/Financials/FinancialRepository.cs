using Domain.Financials;
using Domain.Financials.Repository;
using Infrastructure.Utilities;

namespace Infrastructure.Persistent.EF.Financials
{
    public class FinancialRepository : BaseRepository<Financial>, IFinancialRepository
    {
        public FinancialRepository(ClinicContext context) : base(context)
        {
        }
    }
}
