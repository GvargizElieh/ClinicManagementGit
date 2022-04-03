using Infrastructure.Persistent.EF;
using Microsoft.EntityFrameworkCore;
using Query.Financials.DTOs;
using Query.Utilities;

namespace Query.Financials.GetAll
{
    public class GetAllFinancialsQueryHandler : IBaseQueryHandler<GetAllFinancialsQuery, ICollection<FinancialDto>>
    {
        private readonly ClinicContext context;

        public GetAllFinancialsQueryHandler(ClinicContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<FinancialDto>> Handle(GetAllFinancialsQuery request, CancellationToken cancellationToken)
        {
            var model = await context.Financials.ToListAsync(cancellationToken);
            return  model.Map();
        }
    }
}
