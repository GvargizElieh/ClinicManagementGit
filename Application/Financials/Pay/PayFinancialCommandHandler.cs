using Application.Utilities;
using Domain.Financials.Repository;

namespace Application.Financials.Pay
{
    public class PayFinancialCommandHandler : IBaseCommandHandler<PayFinancialCommand, long>
    {
        private readonly IFinancialRepository repository;

        public PayFinancialCommandHandler(IFinancialRepository repository)
        {
            this.repository = repository;
        }

        public async Task<OperationResult<long>> Handle(PayFinancialCommand request, CancellationToken cancellationToken)
        {
            var financial = await repository.GetTrackingAsync(request.FinancialId);
            if (financial == null)
                return OperationResult<long>.NotFound();

            financial.Pay(request.PayAmount);
            await repository.SaveAsync();
            return OperationResult<long>.Success(financial.Id);
        }
    }
}
