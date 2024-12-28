namespace BusinessLayer.Models.Communication.Messages.Responses.Specific.Membership
{
    public record RegisterUserResponse : ResponseBase
    {
        public required Guid UserId { get; set; }
    }
}
