using Infrastructure.Persistent.EF;
using Microsoft.EntityFrameworkCore;
using Query.Schedules.DTOs;
using Query.Utilities;

namespace Query.Schedules.GetById
{
    public class GetByIdScheduleQueryHandler : IBaseQueryHandler<GetByIdScheduleQuery, ScheduleDto>
    {
        private readonly ClinicContext context;

        public GetByIdScheduleQueryHandler(ClinicContext context)
        {
            this.context = context;
        }

        public async Task<ScheduleDto> Handle(GetByIdScheduleQuery request, CancellationToken cancellationToken)
        {
            var model = await context.Schedules.Include(schedule => schedule.Person).FirstOrDefaultAsync(schedule => schedule.Id == request.ScheduleId, cancellationToken);
            return model.Map();
        }
    }
}
