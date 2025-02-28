using Domain.DTO.Commands.Specific.Membership;
using Domain.DTO.Models.Membership;
using Domain.Logic.Common.Handlers;
using Domain.Logic.Common.Handlers.Providers;
using Domain.Logic.Common.Validators;
using Domain.Logic.Common.Validators.Providers;
using Domain.Logic.Modules.Handlers.Specific.Membership;
using Domain.Logic.Modules.Validators.Membership;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Domain.Logic.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterBusinessLogicServices(this IServiceCollection services)
        {
            // Providers
            services.AddSingleton<IValidatorProvider, ValidatorProvider>();
            services.AddSingleton<IHandlerProvider, HandlerProvider>();

            // Validators
            services.AddScoped<IValidator<RegisterUserCommand>, RegisterUserValidator>();

            // Handlers
            services.AddScoped<IHandler<RegisterUserCommand, RegisterUserDto>, RegisterUserHandler>();
        }
    }
}
