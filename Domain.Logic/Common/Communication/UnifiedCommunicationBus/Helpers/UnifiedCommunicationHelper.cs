using Domain.DTO.Common;
using Domain.DTO.Common.Enums;
using Domain.Models.Handlers.Specific;
using Domain.Models.Validation.Specific;

namespace Domain.Logic.Common.Communication.UnifiedCommunicationBus.Helpers
{
    internal static class UnifiedCommunicationHelper
    {
        public static UnifiedResponse<Output> CreateValidationErrorResponse<Output>(ValidationResult validationResult, OperationDetail operationDetail = default) => new()
            {
                Data = default,
                Messages = validationResult.Messages,
                OperationDetail = operationDetail
            };

        public static UnifiedResponse<Output> CreateHandlerResponse<Output>(HandlerResult<Output> handlerResult) => new()
            {
                Data = handlerResult.Data,
                Messages = handlerResult.Messages,
                OperationDetail = handlerResult.OperationDetail
            };
    }
}
