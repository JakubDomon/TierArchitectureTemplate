using BusinessLayer.Logic.Common.Handlers.Providers;
using BusinessLayer.Logic.Common.Validators.Providers;
using BusinessLayer.Logic.Modules.Logging;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BusinessLayer.Logic.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterBusinessLogicDI(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddSingleton<IValidatorProvider>(provider => { return new ValidatorProvider(assembly); });
            services.AddSingleton<IHandlerProvider>(provider => { return new HandlerProvider(assembly); });
            services.AddSingleton<IExceptionLoggingService, ExceptionLoggingService>();
        }
    }
}
