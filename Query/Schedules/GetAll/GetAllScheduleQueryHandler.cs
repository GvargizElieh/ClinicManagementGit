using Infrastructure.Persistent.EF;
using Microsoft.EntityFrameworkCore;
using Query.Schedules.DTOs;
using Query.Utilities;

namespace Query.Schedules.GetAll
{
    public class GetAllScheduleQueryHandler : IBaseQueryHandler<GetAllScheduleQuery, ICollection<ScheduleDto>>
    {
        private readonly ClinicContext context;

        public GetAllScheduleQueryHandler(ClinicContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<ScheduleDto>> Handle(GetAllScheduleQuery request, CancellationToken cancellationToken)
        {
            var model = await context.Schedules.ToListAsync(cancellationToken);
            return model.Map();
        }
    }
}
