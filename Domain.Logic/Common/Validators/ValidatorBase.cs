using Domain.DTO.Common;
using Domain.Logic.Common.Validators.Rules;
using Domain.Models.Validation.Specific;
using System.Data;

namespace Domain.Logic.Common.Validators
{
    internal abstract class ValidatorBase<Action> : IValidator<Action>
        where Action : IAction
    {
        private HashSet<IValidationRule> _validationRules { get; set; } = [];

        public async Task<ValidationResult> ValidateAsync(Action input)
        {
            PrepareValidationRules(input);

            var results = (await Task.WhenAll(_validationRules
                .Select(rule => rule.ValidateAsync())))
                .SelectMany(m => m);

            return new(results ?? []);
        }

        protected void AddValidationRule(IValidationRule rule) => _validationRules.Add(rule);
        protected abstract void PrepareValidationRules(Action input);
    }
}
