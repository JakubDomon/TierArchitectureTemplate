using DataAccessLayer.Configuration.Helpers;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Contexts
{
    internal class LoggingContext(ConnectionStringHelper connectionStringHelper) : DbContext
    {
    }
}
