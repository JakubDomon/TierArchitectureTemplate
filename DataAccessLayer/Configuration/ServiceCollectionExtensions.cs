using DataAccessLayer.Configuration.Helpers;
using DataAccessLayer.Entities.Membership;
using Microsoft.Extensions.DependencyInjection;
using DataAccessLayer.Contexts;
using System.Reflection;
using AutoMapper.Extensions.ExpressionMapping;

namespace DataAccessLayer.Configuration
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
