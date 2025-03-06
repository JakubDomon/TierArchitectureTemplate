using AutoMapper;
using Azure.Core;
using DataAccess.Logic.Repositories.Membership;
using Domain.DTO.Commands.Specific.Membership;
using Domain.DTO.Interfaces.UnifiedBus;
using Domain.DTO.Models.Membership;
using Domain.Logic.Common.Communication.UnifiedCommunicationBus;
using Domain.Logic.Common.Handlers;
using Domain.Logic.Common.Handlers.Providers;
using Domain.Logic.Common.Validators;
using Domain.Logic.Common.Validators.Providers;
using Domain.Logic.Modules.Handlers.Specific.Membership;
using Domain.Logic.Modules.Validators.Membership;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Logic.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterBusinessLogicServices(this IServiceCollection services)
        {
            // Providers
            services.AddSingleton<IValidatorProvider>(provider => new ValidatorProvider(provider));
            services.AddSingleton<IHandlerProvider>(provider => new HandlerProvider(provider));

            // Unified bus
            services.AddSingleton<IUnifiedBus>(provider =>
            {
                var validatorProvider = provider.GetRequiredService<IValidatorProvider>();
                var handlerProvider = provider.GetRequiredService<IHandlerProvider>();
                return new UnifiedBus(validatorProvider, handlerProvider);
            });

            // Validators
            services.AddScoped<IValidator<RegisterUserCommand>>(provider =>
            {
                var userRepository = provider.GetRequiredService<IUserRepository>();
                return new RegisterUserValidator(userRepository);
            });

            // Handlers
            services.AddScoped<IHandler<RegisterUserCommand, RegisterUserDto>>(provider =>
            {
                var userRepository = provider.GetRequiredService<IUserRepository>();
                var mapper = provider.GetRequiredService<IMapper>();
                return new RegisterUserHandler(userRepository, mapper);
            });
        }
    }
}
