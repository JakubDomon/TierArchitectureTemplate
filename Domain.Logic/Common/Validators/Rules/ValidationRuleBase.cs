using AutoMapper;
using Domain.DTO.Messages;
using Domain.Models.Validation.Specific;
using fv = FluentValidation;

namespace Domain.Logic.Common.Validators.Rules
{
    internal abstract class ValidationRuleBase<T>(IMapper mapper, T input) 
        : fv.AbstractValidator<T>, IValidationRule
    {
        public async Task<IEnumerable<IMessage>> ValidateAsync()
        {
            PrepareSubRules();
            fv.Results.ValidationResult result = await base.ValidateAsync(input);

            return mapper.Map<List<IMessage>>(result.Errors);
        }

        protected abstract void PrepareSubRules();
    }
}
