using Domain.DTO.Common;
using Domain.Models.Handlers.Specific;
using Domain.Models.Validation.Specific;

namespace Domain.Logic.Common.Communication.UnifiedCommunicationBus.Helpers
{
    internal static class UnifiedCommunicationHelper
    {
        public static UnifiedResponse<Output> CreateValidationErrorResponse<Output>(ValidationResult validationResult)
            where Output : class => new()
            {
                Data = default,
                Messages = validationResult.Messages
            };

        public static UnifiedResponse<Output> CreateHandlerResponse<Output>(HandlerResult<Output> handlerResult)
            where Output : class => new()
            {
                Data = handlerResult.Data,
                Messages = handlerResult.Messages
            };
    }
}
