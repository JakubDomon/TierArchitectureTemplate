namespace BusinessLayer.Communication.Concrete.Membership
{
    public class RegisterUserResponse : ResponseBase
    {
        public required Guid UserId { get; set; }
       
    }
}
