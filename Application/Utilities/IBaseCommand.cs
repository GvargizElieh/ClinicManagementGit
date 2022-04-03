using MediatR;

namespace Application.Utilities
{
    public interface IBaseCommand : IRequest<OperationResult>
    {
    }

    public interface IBaseCommand<TData> : IRequest<OperationResult<TData>>
    {
    }

}
