using Domain.DTO.Common;
using Domain.DTO.Common.Enums;
using Domain.DTO.Interfaces.UnifiedBus;
using Domain.Logic.Common.Communication.UnifiedCommunicationBus.Helpers;
using Domain.Logic.Common.Handlers.Providers;
using Domain.Logic.Common.Validators.Providers;
using Domain.Models.Handlers.Specific;
using Domain.Models.Validation.Specific;

namespace Domain.Logic.Common.Communication.UnifiedCommunicationBus
{
    public class UnifiedBus : IUnifiedBus
    {
        private IValidatorProvider _validatorProvider;
        private IHandlerProvider _handlerProvider;

        internal UnifiedBus(IValidatorProvider validatorProvider, IHandlerProvider handlerProvider)
        {
            _validatorProvider = validatorProvider;
            _handlerProvider = handlerProvider;
        }

        public async Task<UnifiedResponse<Output>> ExecuteAsync<Input, Output>(UnifiedRequest<Input> request, CancellationToken ct)
            where Input : IAction
        {
            ValidationResult validationResult = await _validatorProvider.GetValidator<Input>().ValidateAsync(request.Data);

            if (!validationResult.IsSucceeded)
            {
                return UnifiedCommunicationHelper.CreateValidationErrorResponse<Output>(validationResult, OperationDetail.BadRequest);
            }

            HandlerResult<Output> handlerResult = await _handlerProvider.GetHandler<Input, Output>().HandleAsync(request.Data, ct);

            return UnifiedCommunicationHelper.CreateHandlerResponse(handlerResult);
        }
    }
}
