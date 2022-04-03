using Application.Financials.Cancel;
using Application.Financials.Create;
using Application.Financials.Pay;
using Application.Utilities;
using MediatR;
using Query.Financials.DTOs;
using Query.Financials.GetAll;
using Query.Financials.GetById;

namespace Facade.Financials
{
    public class FinancialFacade : IFinancialFacade
    {
        private readonly IMediator mediator;

        public FinancialFacade(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<OperationResult<long>> AddFinancial(CreateFinancialCommand command)
        {
            return await mediator.Send(command);
        }

        public async Task<OperationResult<long>> Cancel(CancelFinancialCommand command)
        {
            return await mediator.Send(command);
        }

        public async Task<FinancialDto> GetFinancial(long id)
        {
            return await mediator.Send(new GertByIdFinancialQuery(id));
        }

        public async Task<ICollection<FinancialDto>> GetFinancials()
        {
            return await mediator.Send(new GetAllFinancialsQuery());
        }

        public async Task<OperationResult<long>> Pay(PayFinancialCommand command)
        {
            return await mediator.Send(command);
        }
    }
}
