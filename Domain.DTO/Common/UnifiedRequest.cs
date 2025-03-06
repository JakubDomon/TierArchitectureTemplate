namespace Domain.DTO.Common
{
    public record UnifiedRequest<Action>(Action Data)
        where Action : IAction;
}
