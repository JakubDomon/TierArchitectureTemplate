using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using AutoMapper.Extensions.ExpressionMapping;
using DataAccess.Entities.Membership;
using DataAccess.Configuration.Helpers;
using DataAccess.Contexts;

namespace DataAccess.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterDataAccessServices(this IServiceCollection services)
        {
            // Automapper
            services.AddAutoMapper(config =>
            {
                config.AddExpressionMapping();
            }, Assembly.GetExecutingAssembly());

            // Database contexts
            services.AddDbContext<MembershipContext>();
            services.AddIdentityCore<User>()
                .AddRoles<Role>()
                .AddEntityFrameworkStores<MembershipContext>();

            // Services
            services.AddSingleton<ConnectionStringHelper>();
        }
    }
}
