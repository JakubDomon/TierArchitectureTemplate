using API.Middleware.Exception.DTO;
using System.Net;

namespace API.Middleware.Exception
{
    public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (System.Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, System.Exception exception)
        {
            var loggingTask = LogExceptionAsync(exception);

            ExceptionResponse response = exception switch
            {
                ApplicationException => new ExceptionResponse(HttpStatusCode.BadRequest, "Application exception occured."),
                UnauthorizedAccessException => new ExceptionResponse(HttpStatusCode.Unauthorized, "Unauthorized."),
                _ => new ExceptionResponse(HttpStatusCode.InternalServerError, "Internal server error. Please retry later")
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)response.StatusCode;
            var writingContentTask = context.Response.WriteAsJsonAsync(response);

            await Task.WhenAll(loggingTask, writingContentTask);
        }

        private async Task LogExceptionAsync(System.Exception exception)
        {
            await Task.Run(() => logger.LogError(exception, "Exception occured"));
        }
    }
}
