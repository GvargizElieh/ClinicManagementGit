using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Utilities
{
    public interface IBaseQuery<TResponse> : IRequest<TResponse> where TResponse : class
    {
    }
}
