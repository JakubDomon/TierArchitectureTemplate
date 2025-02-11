using Domain.DTO.Messages;

namespace Domain.Logic.Common.Validators.Rules
{
    internal interface IValidationRule
    {
        Task<IEnumerable<IMessage>> ValidateAsync();
    }
}
