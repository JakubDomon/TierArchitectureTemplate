using BusinessLayer.Models.Communication.Messages.Requests;

namespace BusinessLayer.Models.Communication.Messages.Requests.Specific.Membership
{
    public class RegisterUserRequest : RequestBase
    {
        public required string UserName { get; set; }
        public required string FirstName { get; set; }
        public required string? LastName { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
    }
}
