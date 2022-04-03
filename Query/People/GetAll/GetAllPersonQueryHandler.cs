using Infrastructure.Persistent.EF;
using Microsoft.EntityFrameworkCore;
using Query.People.DTOs;
using Query.Utilities;

namespace Query.People.GetAll
{
    public class GetAllPersonQueryHandler : IBaseQueryHandler<GetAllPersonQuery, ICollection<PersonDto>>
    {
        private readonly ClinicContext context;

        public GetAllPersonQueryHandler(ClinicContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<PersonDto>> Handle(GetAllPersonQuery request, CancellationToken cancellationToken)
        {
            var model = await context.People
                .Include(person => person.Financials)
                .Include(person => person.Reports)
                .Include(person => person.Schedules)
                .ToListAsync(cancellationToken);
            return model.Map();
        }
    }
}
