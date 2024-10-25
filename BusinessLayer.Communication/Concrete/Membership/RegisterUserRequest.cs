namespace BusinessLayer.Communication.Concrete.Membership
{
    public class RegisterUserRequest : RequestBase
    {
        public required string UserName { get; set; }
        public required string FirstName { get; set; }
        public required string? LastName { get; set; }
        public required string Password { get; set; }
    }
}
