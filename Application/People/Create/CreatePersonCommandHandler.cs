using Application.Utilities;
using Domain.People;
using Domain.People.Repository;
using Domain.People.Services;

namespace Application.People.Create
{
    public class CreatePersonCommandHandler : IBaseCommandHandler<CreatePersonCommand, long>
    {
        private readonly IPersonDomainService domainService;
        private readonly IPersonRepository repository;

        public CreatePersonCommandHandler(IPersonDomainService domainService, IPersonRepository repository)
        {
            this.domainService = domainService;
            this.repository = repository;
        }

        public async Task<OperationResult<long>> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = new Person(request.Name, request.Family, request.NationalId, request.Gender, request.BirthDate, domainService);
            await repository.AddAsync(person);
            await repository.SaveAsync();
            return OperationResult<long>.Success(person.Id);
        }
    }
}
