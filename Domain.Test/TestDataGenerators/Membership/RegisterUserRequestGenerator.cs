using Domain.DTO.Models.Membership;
using Domain.DTO.Requests.Specific.Membership;

namespace Domain.Tests.TestDataGenerators.Membership
{
    internal static class RegisterUserRequestGenerator
    {
        public static IEnumerable<object[]> GetUserRequestTestDataSet => new []
        {
            new object[] 
            { 
                new RegisterUserRequest()
                { 
                    UserData = new RegisterUserDto()
                    {
                        Login = "TestLogin",
                        Password = "PasswordTest",
                        Email = "EmailTest",
                        FirstName = "FirstName",
                        LastName = "LastName"
                    }
                } 
            }
        };
    }
}
