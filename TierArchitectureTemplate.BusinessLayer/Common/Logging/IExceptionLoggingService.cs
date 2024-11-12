using Microsoft.Extensions.Logging;

namespace BusinessLayer.Logic.Common.Logging
{
    internal interface IExceptionLoggingService
    {
        public Task LogExceptionAsync(Exception exception, LogLevel logLevel);
    }
}
