using BusinessLayer.Logic.Common.Handlers.Providers;
using BusinessLayer.Logic.Common.Validators.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer.Logic.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterBusinessLogicDI(this IServiceCollection services)
        {
            services.AddSingleton<IValidatorProvider, ValidatorProvider>();
            services.AddSingleton<IHandlerProvider, HandlerProvider>();
        }
    }
}
