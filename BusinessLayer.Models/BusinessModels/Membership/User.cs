namespace BusinessLayer.Models.Entities.Membership
{
    public class User : ModelBase
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
    }
}
