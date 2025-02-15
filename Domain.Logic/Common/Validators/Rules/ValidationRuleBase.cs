using AutoMapper;
using Domain.DTO.Messages;
using Domain.DTO.Messages.Specific;
using Fv = FluentValidation;

namespace Domain.Logic.Common.Validators.Rules
{
    internal abstract class ValidationRuleBase<T>(T input) 
        : Fv.AbstractValidator<T>, IValidationRule
    {
        public async Task<IEnumerable<IMessage>> ValidateAsync()
        {
            PrepareSubRules();
            Fv.Results.ValidationResult result = await base.ValidateAsync(input);

            return result.Errors.Select(x => new ErrorMessage(x.ErrorCode, x.ErrorMessage));
        }

        protected abstract void PrepareSubRules();
    }
}
