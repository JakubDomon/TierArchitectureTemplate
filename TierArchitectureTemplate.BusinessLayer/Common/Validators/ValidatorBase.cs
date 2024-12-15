using BusinessLayer.Models.Communication.Messages.Messages;
using BusinessLayer.Models.Communication.Messages.Requests;
using BusinessLayer.Models.Communication.Validation.Specific;

namespace BusinessLayer.Logic.Common.Validators
{
    internal abstract class ValidatorBase<Input> : IValidator<Input>
        where Input : RequestBase
    {
        public async Task<ValidationResult> ValidateAsync(Input input)
        {
            var validationResult = new ValidationResult();
            var messages = new List<IMessage>();

            await foreach(IMessage message in ValidateInternal(input))
            {
                messages.Add(message);
            };

            validationResult.Messages = messages;

            return validationResult;
        }

        protected abstract IAsyncEnumerable<IMessage> ValidateInternal(Input input);
    }
}
