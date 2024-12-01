
namespace TierArchitectureTemplate.API.Logging
{
    public interface IExceptionLoggingService
    {
        public Task LogExceptionAsync(Exception exception, LogLevel logLevel);
    }
}
