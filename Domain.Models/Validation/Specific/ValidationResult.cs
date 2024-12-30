using Domain.DTO.Messages;
using Domain.DTO.Messages.Enums;

namespace Domain.Models.Validation.Specific
{
    public record ValidationResult(IEnumerable<IMessage> Messages)
    {
        public IEnumerable<IMessage> Messages { get; set; } = Messages ?? [];
        public bool IsSucceeded
        {
            get => !Messages.Any(m => m.Type == MessageType.Error);
        }
    }
}
