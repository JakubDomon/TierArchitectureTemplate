using Domain.DTO.Messages;

namespace Domain.Logic.Common.Validators
{
    public interface IValidationRule
    {
        public Task<IMessage?> ValidateAsync();
    }
}
