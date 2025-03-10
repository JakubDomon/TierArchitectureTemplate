using Domain.DTO.Common.Enums;
using Domain.DTO.Common.Helpers;
using Domain.DTO.Messages;
using Domain.DTO.Messages.Enums;

namespace Domain.DTO.Common
{
    public record UnifiedResponse<Payload>
    {
        public Payload? Data { get; init; }
        public IEnumerable<IMessage> Messages { get; init; } = [];
        public OperationDetail OperationDetail { get; init; }
        public bool IsSuccess
        {
            get => !Messages.Any(x => x.Type == MessageType.Error)
                && OperationDetailHelper.IsSuccess(OperationDetail);
        }
    }
}
