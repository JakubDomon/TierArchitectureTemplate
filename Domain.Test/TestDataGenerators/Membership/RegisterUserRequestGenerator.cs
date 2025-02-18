using Domain.DTO.Models.Membership;
using Domain.DTO.Requests.Specific.Membership;

namespace Domain.Tests.TestDataGenerators.Membership
{
    internal static class RegisterUserRequestGenerator
    {
        public static IEnumerable<object[]> GetUserRequestTestDataSet()
        {
            yield return new object[]
            {
                new RegisterUserRequest(new RegisterUserDto()
                    {
                        Login = "TestLogin",
                        Password = "PasswordTest",
                        Email = "EmailTest",
                        FirstName = "FirstName",
                        LastName = "LastName"
                    }),
                false
            };

            yield return new object[]
            {
                new RegisterUserRequest(new RegisterUserDto()
                    {
                        Login = "TestLogin2",
                        Password = "PasswordTest2",
                        Email = "EmailTes2t",
                        FirstName = "FirstName2",
                        LastName = "LastName2"
                    }),
                true
            };
        }
    }
}
