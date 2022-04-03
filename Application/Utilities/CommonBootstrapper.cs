using Application.Utilities.Validation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Utilities
{
    public class CommonBootstrapper
    {
        public static void Init(IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommandValidationBehavior<,>));
        }
    }
}
