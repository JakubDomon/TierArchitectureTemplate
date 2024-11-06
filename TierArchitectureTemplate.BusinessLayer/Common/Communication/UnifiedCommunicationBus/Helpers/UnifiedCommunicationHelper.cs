using BusinessLayer.Logic.Common.Communication.Common;
using BusinessLayer.Models.Communication.Concrete.Validation;

namespace BusinessLayer.Logic.Common.Communication.UnifiedCommunicationBus.Helpers
{
    internal static class UnifiedCommunicationHelper
    {
        public static UnifiedResponse<Output> CreateValidationErrorResponse<Output>(ValidationResult validationResult)
            where Output : ResponseBase
        {
            return new UnifiedResponse<Output>
            {
                Data = default,
                Messages = validationResult.Messages
            };
        }
    }
}
