using BusinessLayer.Models.Communication.Messages.Messages;
using BusinessLayer.Models.Communication.Messages.Requests;
using BusinessLayer.Models.Communication.Validation.Specific;
using System.Data;

namespace BusinessLayer.Logic.Common.Validators
{
    internal abstract class ValidatorBase<Input> : IValidator<Input>
        where Input : RequestBase
    {
        private HashSet<IValidationRule> _validationRules { get; set; } = [];

        public async Task<ValidationResult> ValidateAsync(Input input)
        {
            PrepareValidationRules(input);
            var validationResult = new ValidationResult();

            var results = await Task.WhenAll(_validationRules
                .Select(rule => rule.ValidateAsync()));

            if(results.Length > 0)
                validationResult.Messages = results.Where(x => x != null).Cast<IMessage>();

            return validationResult;
        }

        protected void AddValidationRule(IValidationRule rule) => _validationRules.Add(rule);
        protected abstract void PrepareValidationRules(Input input);
    }
}
