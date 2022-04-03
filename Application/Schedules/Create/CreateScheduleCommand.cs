using Application.Utilities;
using Domain.Schedules;
using Domain.Schedules.Repository;
using Domain.Schedules.Services;

namespace Application.Schedules.Create
{
    public record CreateScheduleCommand(string Title, string Description, DateTime StartTime, DateTime EndTime) : IBaseCommand<long>;
    public class CreateScheduleCommandHandler : IBaseCommandHandler<CreateScheduleCommand, long>
    {
        private readonly IScheduleDomainServices domainServices;
        private readonly IScheduleRepository repository;

        public CreateScheduleCommandHandler(IScheduleDomainServices domainServices, IScheduleRepository repository)
        {
            this.domainServices = domainServices;
            this.repository = repository;
        }

        public async Task<OperationResult<long>> Handle(CreateScheduleCommand request, CancellationToken cancellationToken)
        {
            var schedule = new Schedule(request.Title, request.Description, request.StartTime, request.EndTime, domainServices);
            await repository.AddAsync(schedule);
            await repository.SaveAsync();
            return OperationResult<long>.Success(schedule.Id);
        }
    }
}
