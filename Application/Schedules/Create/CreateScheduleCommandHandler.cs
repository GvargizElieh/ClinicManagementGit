using Application.Utilities;
using Domain.People.Repository;
using Domain.Schedules;
using Domain.Schedules.Repository;
using Domain.Schedules.Services;

namespace Application.Schedules.Create
{
    public class CreateScheduleCommandHandler : IBaseCommandHandler<CreateScheduleCommand, long>
    {
        private readonly IScheduleDomainServices domainServices;
        private readonly IScheduleRepository repository;
        private readonly IPersonRepository personRepository;

        public CreateScheduleCommandHandler(IScheduleDomainServices domainServices, IScheduleRepository repository, IPersonRepository personRepository)
        {
            this.domainServices = domainServices;
            this.repository = repository;
            this.personRepository = personRepository;
        }

        public async Task<OperationResult<long>> Handle(CreateScheduleCommand request, CancellationToken cancellationToken)
        {
            var schedule = new Schedule(request.Title, request.Description, request.StartTime, request.EndTime, domainServices);
            var person = await personRepository.GetAsync(request.PersonId);
            if (person == null)
                return OperationResult<long>.NotFound();

            schedule.AssignPerson(person);
            await repository.AddAsync(schedule);
            await repository.SaveAsync();
            return OperationResult<long>.Success(schedule.Id);
        }
    }
}
