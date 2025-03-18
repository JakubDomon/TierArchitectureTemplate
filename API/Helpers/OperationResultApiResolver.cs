using Domain.DTO.Common.Enums;
using Microsoft.AspNetCore.Mvc;

namespace API.Helpers
{
    public static class OperationResultApiResolver
    {
        public static IActionResult Resolve(OperationDetail operationDetail, object? data = default, string? localization = default, object[]? messages = default)
        {
            return operationDetail switch
            {
                OperationDetail.Ok => new OkObjectResult(data),
                OperationDetail.Created => new CreatedResult(localization, data),
                OperationDetail.NoContent => new NoContentResult(),
                OperationDetail.Error => new StatusCodeResult(500),
                OperationDetail.BadRequest => new BadRequestObjectResult(messages),
                OperationDetail.Conflict => new ConflictObjectResult(messages),
                OperationDetail.NotFound => new NotFoundResult(),
                OperationDetail.Unauthorized => new UnauthorizedResult(),
                _ => new StatusCodeResult(500)
            };
        }
    }
}
