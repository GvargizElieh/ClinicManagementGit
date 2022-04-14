using Application.Utilities;
using Domain.Financials.Repository;
using Domain.People.Repository;

namespace Application.People.AssignFinancial
{
    public class AssingnFinancialPersonCommandHandler : IBaseCommandHandler<AssingnFinancialPersonCommand>
    {
        private readonly IPersonRepository personRepository;
        private readonly IFinancialRepository financialRepository;

        public AssingnFinancialPersonCommandHandler(IPersonRepository personRepository, IFinancialRepository financialRepository)
        {
            this.personRepository = personRepository;
            this.financialRepository = financialRepository;
        }

        public async Task<OperationResult> Handle(AssingnFinancialPersonCommand request, CancellationToken cancellationToken)
        {
            var person = await personRepository.GetAsync(request.PersonId);
            if (person == null)
                return OperationResult.NotFound(OperationResult.NotFoundMessage);

            var financial = await financialRepository.GetTrackingAsync(request.FinancialId);
            if (financial == null)
                return OperationResult.NotFound(OperationResult.NotFoundMessage);

            person.AssingnFinancial(financial);
            await financialRepository.SaveAsync();
            return OperationResult.Success();
        }
    }
}
