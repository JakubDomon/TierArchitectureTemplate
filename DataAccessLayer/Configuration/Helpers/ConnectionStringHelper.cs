using Microsoft.Extensions.Configuration;

namespace DataAccess.Configuration.Helpers
{
    internal class ConnectionStringHelper(IConfiguration configuration)
    {
        public string MembershipConnectionString
        {
            get => configuration.GetConnectionString("MembershipConnectionString")
                ?? throw new ArgumentException("No connection string provided for 'MembershipConnectionString'");
        }
    }
}
