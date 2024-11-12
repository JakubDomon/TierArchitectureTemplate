using Microsoft.Extensions.Logging;

namespace BusinessLayer.Logic.Common.Logging
{
    public class ExceptionLoggingService() : IExceptionLoggingService
    {
        public async Task LogExceptionAsync(Exception exception, LogLevel logLevel)
        {

        }
    }
}
