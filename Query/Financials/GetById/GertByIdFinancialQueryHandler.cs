using Infrastructure.Persistent.EF;
using Microsoft.EntityFrameworkCore;
using Query.Financials.DTOs;
using Query.Utilities;

namespace Query.Financials.GetById
{
    public class GertByIdFinancialQueryHandler : IBaseQueryHandler<GertByIdFinancialQuery, FinancialDto>
    {
        private readonly ClinicContext context;

        public GertByIdFinancialQueryHandler(ClinicContext context)
        {
            this.context = context;
        }

        public async Task<FinancialDto> Handle(GertByIdFinancialQuery request, CancellationToken cancellationToken)
        {
            var model = await context.Financials
                .Include(financial => financial.Person).FirstOrDefaultAsync(financial => financial.Id == request.FinancialId, cancellationToken);

            return model.Map();
        }
    }
}
