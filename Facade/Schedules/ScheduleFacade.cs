using Application.Schedules.Create;
using Application.Utilities;
using MediatR;
using Query.Schedules.DTOs;
using Query.Schedules.GetAll;
using Query.Schedules.GetById;

namespace Facade.Schedules
{
    public class ScheduleFacade : IScheduleFacade
    {
        private readonly IMediator mediator;

        public ScheduleFacade(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<OperationResult<long>> AddSchedule(CreateScheduleCommand command)
        {
            return await mediator.Send(command);
        }

        public async Task<ScheduleDto> GetSchedule(long id)
        {
            return await mediator.Send(new GetByIdScheduleQuery(id));
        }

        public async Task<ICollection<ScheduleDto>> GetSchedules()
        {
            return await mediator.Send(new GetAllScheduleQuery());
        }
    }
}
