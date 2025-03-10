using Domain.DTO.Common.Enums;
using Domain.DTO.Common.Helpers;
using Domain.DTO.Messages;
using Domain.DTO.Messages.Enums;

namespace Domain.Models.Handlers.Specific
{
    public record HandlerResult<Output>
    {
        public IEnumerable<IMessage> Messages { get; init; } = [];
        public OperationDetail OperationDetail { get; init; }
        public Output? Data { get; init; }
        public bool IsSuccess => !Messages.Any(x => x.Type == MessageType.Error)
            && OperationDetailHelper.IsSuccess(OperationDetail);
    }
}
