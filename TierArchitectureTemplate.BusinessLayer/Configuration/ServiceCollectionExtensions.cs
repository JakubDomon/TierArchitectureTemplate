using BusinessLayer.Logic.Common.Handlers;
using BusinessLayer.Logic.Common.Handlers.Providers;
using BusinessLayer.Logic.Common.Validators;
using BusinessLayer.Logic.Common.Validators.Providers;
using BusinessLayer.Logic.Modules.Handlers.Specific.Membership;
using BusinessLayer.Logic.Modules.Validators.Membership;
using BusinessLayer.Models.Communication.Messages.Requests.Specific.Membership;
using BusinessLayer.Models.Communication.Messages.Responses.Specific.Membership;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BusinessLayer.Logic.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterBusinessLogicServices(this IServiceCollection services)
        {
            // Providers
            services.AddSingleton<IValidatorProvider, ValidatorProvider>();
            services.AddSingleton<IHandlerProvider, HandlerProvider>();

            // Validators
            services.AddScoped<IValidator<RegisterUserRequest>, RegisterUserValidator>();

            // Handlers
            services.AddScoped<IHandler<RegisterUserRequest, RegisterUserResponse>, RegisterUserHandler>();
        }
    }
}
