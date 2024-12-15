using BusinessLayer.Logic.Common.Communication.UnifiedCommunicationBus.Helpers;
using BusinessLayer.Logic.Common.Handlers.Providers;
using BusinessLayer.Logic.Common.Validators.Providers;
using BusinessLayer.Models.Communication.Messages.Requests;
using BusinessLayer.Models.Communication.Messages.Requests.Common;
using BusinessLayer.Models.Communication.Messages.Responses;
using BusinessLayer.Models.Communication.Messages.Responses.Common;
using BusinessLayer.Models.Communication.Validation.Specific;

namespace BusinessLayer.Logic.Common.Communication.UnifiedCommunicationBus
{
    public class UnifiedCommunicationBus
    {
        private IValidatorProvider _validatorProvider;
        private IHandlerProvider _handlerProvider;

        internal UnifiedCommunicationBus(IValidatorProvider validatorProvider, IHandlerProvider handlerProvider)
        {
            _validatorProvider = validatorProvider;
            _handlerProvider = handlerProvider;
        }

        public async Task<UnifiedResponse<Output>> ExecuteAsync<Input, Output>(UnifiedRequest<Input> request)
            where Input : RequestBase
            where Output : ResponseBase, new()
        {
            ValidationResult validationResult = await _validatorProvider.GetValidator<Input>().ValidateAsync(request.Data);

            if (!validationResult.IsSucceded)
            {
                return UnifiedCommunicationHelper.CreateValidationErrorResponse<Output>(validationResult);
            }

            return new UnifiedResponse<Output>
            {
                Data = new Output(),
            };
        }
    }
}
