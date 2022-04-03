using MediatR;

namespace Query.Utilities
{
    public interface IBaseQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse> where TQuery : IBaseQuery<TResponse> where TResponse : class
    {
    }
}
