using Domain.DTO.Messages;
using Domain.DTO.Requests;
using Domain.Logic.Common.Validators.Rules;
using Domain.Models.Validation.Specific;
using System.Data;

namespace Domain.Logic.Common.Validators
{
    internal abstract class ValidatorBase<Input> : IValidator<Input>
        where Input : RequestBase
    {
        private HashSet<IValidationRule> _validationRules { get; set; } = [];

        public async Task<ValidationResult> ValidateAsync(Input input)
        {
            PrepareValidationRules(input);
            IEnumerable<IMessage> validationMessages = [];

            var results = (await Task.WhenAll(_validationRules
                .Select(rule => rule.ValidateAsync())))
                .SelectMany(m => m);

            return new(results ?? []);
        }

        protected void AddValidationRule(IValidationRule rule) => _validationRules.Add(rule);
        protected abstract void PrepareValidationRules(Input input);
    }
}
