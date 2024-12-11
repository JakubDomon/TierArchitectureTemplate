using Microsoft.Extensions.Logging;

namespace BusinessLayer.Logic.Modules.Logging
{
    public interface IExceptionLoggingService
    {
        public Task LogExceptionAsync(Exception exception, LogLevel logLevel);
    }
}
