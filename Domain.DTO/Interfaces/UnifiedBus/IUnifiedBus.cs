using Domain.DTO.Common;

namespace Domain.DTO.Interfaces.UnifiedBus
{
    public interface IUnifiedBus
    {
        public Task<UnifiedResponse<Output>> ExecuteAsync<Input, Output>(UnifiedRequest<Input> request, CancellationToken ct)
            where Input : IAction;
    }
}
