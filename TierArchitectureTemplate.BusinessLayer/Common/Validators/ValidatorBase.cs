using BusinessLayer.Communication;
using BusinessLayer.Models.Communication;

namespace BusinessLayer.Logic.Common.Validators
{
    internal abstract class ValidatorBase<Input> : IValidator<Input>
        where Input : RequestBase
    {
        public async IAsyncEnumerable<IMessage> Validate(Input input)
        {
            await foreach(IMessage message in ValidateInternal(input))
            {
                yield return message;
            };
        }

        protected abstract IAsyncEnumerable<IMessage> ValidateInternal(Input input);
    }
}
