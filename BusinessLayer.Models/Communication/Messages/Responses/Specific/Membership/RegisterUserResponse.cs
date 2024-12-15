using BusinessLayer.Models.Communication.Messages.Responses;

namespace BusinessLayer.Models.Communication.Messages.Responses.Specific.Membership
{
    public class RegisterUserResponse : ResponseBase
    {
        public required Guid UserId { get; set; }

    }
}
