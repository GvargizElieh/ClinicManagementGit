using Infrastructure.Persistent.EF;
using Microsoft.EntityFrameworkCore;
using Query.People.DTOs;
using Query.Utilities;

namespace Query.People.GetById
{
    public class GetByIdPersonQueryHandler : IBaseQueryHandler<GetByIdPersonQuery, PersonDto>
    {
        private readonly ClinicContext context;

        public GetByIdPersonQueryHandler(ClinicContext context)
        {
            this.context = context;
        }

        public async Task<PersonDto> Handle(GetByIdPersonQuery request, CancellationToken cancellationToken)
        {
            var model = await context.People
                .Include(person => person.Financials)
                .Include(person => person.Reports)
                .Include(person => person.Schedules)
                .FirstOrDefaultAsync(person => person.Id == request.PersonId, cancellationToken);

            return model.Map();
        }
    }
}
