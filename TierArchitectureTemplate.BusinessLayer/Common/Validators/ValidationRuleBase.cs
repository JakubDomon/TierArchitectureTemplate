using BusinessLayer.Models.Communication.Messages.Messages;
using BusinessLayer.Models.Communication.Messages.Messages.Specific;
using BusinessLayer.Models.Communication.Validation.Enums;
using EnumStringValues;

namespace BusinessLayer.Logic.Common.Validators
{
    internal abstract class ValidationRuleBase(ValidationScope scope) : IValidationRule
    {
        private ValidationScope _validationScope { get; } = scope;

        public abstract Task<IMessage?> ValidateAsync();

        protected ErrorMessage CreateError(string errorMessage) => new(_validationScope.GetStringValue(), errorMessage);
        protected WarningMessage CreateWarning(string warningMessage) => new(_validationScope.GetStringValue(), warningMessage);
    }
}
