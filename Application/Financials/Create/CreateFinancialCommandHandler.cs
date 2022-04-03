using Application.Utilities;
using Domain.Financials;
using Domain.Financials.Repository;

namespace Application.Financials.Create
{
    public class CreateFinancialCommandHandler : IBaseCommandHandler<CreateFinancialCommand, long>
    {
        private readonly IFinancialRepository repository;

        public CreateFinancialCommandHandler(IFinancialRepository repository)
        {
            this.repository = repository;
        }

        public async Task<OperationResult<long>> Handle(CreateFinancialCommand request, CancellationToken cancellationToken)
        {
            var financial = new Financial(request.Payment, request.PaymentAmount);
            await repository.AddAsync(financial);
            await repository.SaveAsync();
            return OperationResult<long>.Success(financial.Id);
        }
    }
}
