using System.Net;

namespace API.Middleware.Exception.DTO
{
    public record ExceptionResponse(HttpStatusCode StatusCode, string Description);
}
