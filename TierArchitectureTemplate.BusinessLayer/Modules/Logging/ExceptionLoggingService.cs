using Microsoft.Extensions.Logging;

namespace BusinessLayer.Logic.Modules.Logging
{
    public class ExceptionLoggingService() : IExceptionLoggingService
    {
        public async Task LogExceptionAsync(Exception exception, LogLevel logLevel)
        {
            throw new NotImplementedException();
        }
    }
}
