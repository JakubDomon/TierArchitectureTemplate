namespace TierArchitectureTemplate.API.Logging
{
    public class ExceptionLoggingService() : IExceptionLoggingService
    {
        public async Task LogExceptionAsync(Exception exception, LogLevel logLevel)
        {
            throw new NotImplementedException();
        }
    }
}
