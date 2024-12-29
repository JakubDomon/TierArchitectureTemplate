using Domain.DTO.Messages;
using Domain.DTO.Messages.Specific;
using Domain.Models.Validation.Enums;
using EnumStringValues;

namespace Domain.Logic.Common.Validators
{
    internal abstract class ValidationRuleBase(ValidationScope scope) : IValidationRule
    {
        private ValidationScope _validationScope { get; } = scope;

        public abstract Task<IMessage?> ValidateAsync();

        protected ErrorMessage CreateError(string errorMessage) => new(_validationScope.GetStringValue(), errorMessage);
        protected WarningMessage CreateWarning(string warningMessage) => new(_validationScope.GetStringValue(), warningMessage);
    }
}
