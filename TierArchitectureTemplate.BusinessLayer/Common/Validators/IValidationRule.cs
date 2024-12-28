using BusinessLayer.Models.Communication.Messages.Messages;

namespace BusinessLayer.Logic.Common.Validators
{
    public interface IValidationRule
    {
        public Task<IMessage?> ValidateAsync();
    }
}
