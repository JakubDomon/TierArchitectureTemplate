using BusinessLayer.Models.Communication.Messages.Messages;
using BusinessLayer.Models.Communication.Messages.Messages.Enums;

namespace BusinessLayer.Models.Communication.Validation.Specific
{
    public record ValidationResult(IEnumerable<IMessage> Messages)
    {
        public IEnumerable<IMessage> Messages { get; init; } = Messages ?? [];
        public bool IsSucceeded
        {
            get => !Messages.Any(m => m.Type == MessageType.Error);
        }
    }
}
