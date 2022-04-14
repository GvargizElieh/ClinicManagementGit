using Application.Utilities;
using Domain.People.Repository;
using Domain.Reports;
using Domain.Reports.Repository;

namespace Application.Reports.Create
{
    public class CreateReportCommandHandler : IBaseCommandHandler<CreateReportCommand, long>
    {
        private readonly IReportRepository repository;
        private readonly IPersonRepository personRepository;

        public CreateReportCommandHandler(IReportRepository repository, IPersonRepository personRepository)
        {
            this.repository = repository;
            this.personRepository = personRepository;
        }

        public async Task<OperationResult<long>> Handle(CreateReportCommand request, CancellationToken cancellationToken)
        {
            var report= new Report(request.Issue, request.Content, request.Type, request.ReportDate);
            var person = await personRepository.GetAsync(request.PersonId);
            if (person == null)
                return OperationResult<long>.NotFound();

            report.AssignPerson(person);
            await repository.AddAsync(report);
            await repository.SaveAsync();
            return OperationResult<long>.Success(report.Id);
        }
    }
}
