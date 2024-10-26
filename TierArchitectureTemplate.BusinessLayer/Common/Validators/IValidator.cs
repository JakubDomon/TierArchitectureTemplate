using BusinessLayer.Communication;
using BusinessLayer.Models.Communication;

namespace BusinessLayer.Logic.Common.Validators
{
    internal interface IValidator<Input>
        where Input : RequestBase
    {
        public IAsyncEnumerable<IMessage> Validate(Input input);
    }
}
