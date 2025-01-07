using Microsoft.Extensions.Configuration;

namespace DataAccess.Logic.Configuration.Helpers
{
    internal class ConnectionStringHelper(IConfiguration configuration)
    {
        private readonly IConfiguration _configuration = configuration;
        public string MembershipConnectionString
        {
            get => _configuration.GetConnectionString("MembershipConnectionString")
                ?? throw new ArgumentException("No connection string provided for 'MembershipConnectionString'");
        }
    }
}
