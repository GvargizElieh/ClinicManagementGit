using Application.Utilities;
using Domain.Financials.Repository;

namespace Application.Financials.Cancel
{
    public class CancelFinancialCommandHandler : IBaseCommandHandler<CancelFinancialCommand, long>
    {
        private readonly IFinancialRepository repository;

        public CancelFinancialCommandHandler(IFinancialRepository repository)
        {
            this.repository = repository;
        }

        public async Task<OperationResult<long>> Handle(CancelFinancialCommand request, CancellationToken cancellationToken)
        {
            var financial = await repository.GetTrackingAsync(request.FinancialId);
            if (financial == null)
                return OperationResult<long>.NotFound();

            financial.Cancel();
            await repository.SaveAsync();
            return OperationResult<long>.Success(financial.Id);
        }
    }
}
