using Microsoft.Extensions.Logging;

namespace TierArchitectureTemplate.API.Logging
{
    internal interface IExceptionLoggingService
    {
        public Task LogExceptionAsync(Exception exception, LogLevel logLevel);
    }
}
