using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using AutoMapper.Extensions.ExpressionMapping;
using DataAccess.Logic.Contexts;
using DataAccess.Logic.Entities.Membership;
using DataAccess.Logic.Configuration.Helpers;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Logic.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterDataAccessServices(this IServiceCollection services, bool isDevelopment)
        {
            // Automapper
            services.AddAutoMapper(config =>
            {
                config.AddExpressionMapping();
            }, Assembly.GetExecutingAssembly());


            services.AddDbContext<MembershipContext>();

            services.AddIdentityCore<User>()
                .AddRoles<Role>()
                .AddEntityFrameworkStores<MembershipContext>();

            // Services
            services.AddSingleton<ConnectionStringHelper>();
        }
    }
}
