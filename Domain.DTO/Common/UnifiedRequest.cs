namespace Domain.DTO.Common
{
    public record UnifiedRequest<Action>
        where Action : IAction
    {
        public required Action Data { get; set; }
    }
}
