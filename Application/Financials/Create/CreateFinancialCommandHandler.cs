using Application.Utilities;
using Domain.Financials;
using Domain.Financials.Repository;
using Domain.People.Repository;

namespace Application.Financials.Create
{
    public class CreateFinancialCommandHandler : IBaseCommandHandler<CreateFinancialCommand, long>
    {
        private readonly IFinancialRepository repository;
        private readonly IPersonRepository personRepository;

        public CreateFinancialCommandHandler(IFinancialRepository repository, IPersonRepository personRepository)
        {
            this.repository = repository;
            this.personRepository = personRepository;
        }

        public async Task<OperationResult<long>> Handle(CreateFinancialCommand request, CancellationToken cancellationToken)
        {
            var financial = new Financial(request.Payment, request.PaymentAmount);
            var person = await personRepository.GetAsync(request.PersonId);
            if (person == null)
                return OperationResult<long>.NotFound();

            financial.AssignPerson(person);
            await repository.AddAsync(financial);
            await repository.SaveAsync();
            return OperationResult<long>.Success(financial.Id);
        }
    }
}
