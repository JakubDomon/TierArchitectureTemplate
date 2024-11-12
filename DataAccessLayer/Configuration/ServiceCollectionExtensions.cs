using DataAccessLayer.Configuration.Helpers;
using DataAccessLayer.Entities.Membership;
using Microsoft.Extensions.DependencyInjection;
using DataAccessLayer.Contexts;
using System.Reflection;

namespace DataAccessLayer.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterBusinessLogicDI(this IServiceCollection services)
        {
            // Automapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Database contexts
            services.AddIdentityCore<User>()
                .AddRoles<Role>()
                .AddEntityFrameworkStores<MembershipContext>();
            
            // Services
            services.AddSingleton<ConnectionStringHelper>();
        } 
    }
}
