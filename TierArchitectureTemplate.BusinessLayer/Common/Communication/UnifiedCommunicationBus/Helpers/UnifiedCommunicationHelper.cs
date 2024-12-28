using BusinessLayer.Models.Communication.Handlers.Specific;
using BusinessLayer.Models.Communication.Messages.Responses;
using BusinessLayer.Models.Communication.Messages.Responses.Common;
using BusinessLayer.Models.Communication.Validation.Specific;

namespace BusinessLayer.Logic.Common.Communication.UnifiedCommunicationBus.Helpers
{
    internal static class UnifiedCommunicationHelper
    {
        public static UnifiedResponse<Output> CreateValidationErrorResponse<Output>(ValidationResult validationResult)
            where Output : ResponseBase => new()
            {
                Data = default,
                Messages = validationResult.Messages
            };

        public static UnifiedResponse<Output> CreateHandlerResponse<Output>(HandlerResult<Output> handlerResult)
            where Output : ResponseBase => new()
            {
                Data = handlerResult.Data,
                Messages = handlerResult.Messages
            };
    }
}
