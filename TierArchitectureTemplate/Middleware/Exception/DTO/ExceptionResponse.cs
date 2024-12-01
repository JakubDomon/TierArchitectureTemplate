using System.Net;

namespace TierArchitectureTemplate.API.Middleware.Exception.DTO
{
    public record ExceptionResponse(HttpStatusCode StatusCode, string Description);
}
