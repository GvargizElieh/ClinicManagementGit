using Application.Utilities;
using Domain.People.Repository;
using Domain.Schedules.Repository;

namespace Application.People.AssignSchedule
{
    public class AssignSchedulePersonCommandHandler : IBaseCommandHandler<AssignSchedulePersonCommand>
    {
        private readonly IPersonRepository personRepository;
        private readonly IScheduleRepository scheduleRepository;

        public AssignSchedulePersonCommandHandler(IPersonRepository personRepository, IScheduleRepository scheduleRepository)
        {
            this.personRepository = personRepository;
            this.scheduleRepository = scheduleRepository;
        }

        public async Task<OperationResult> Handle(AssignSchedulePersonCommand request, CancellationToken cancellationToken)
        {
            var person =  await personRepository.GetAsync(request.PersonId);
            if (person == null)
                return OperationResult.NotFound(OperationResult.NotFoundMessage);

            var schedule = await scheduleRepository.GetTrackingAsync(request.ScheduleId);
            if (schedule == null)
                return OperationResult.NotFound(OperationResult.NotFoundMessage);

            person.AssignSchedule(schedule);
            await scheduleRepository.SaveAsync();
            return OperationResult.Success();
        }
    }
}
