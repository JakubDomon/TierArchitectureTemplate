using Domain.DTO.Commands.Specific.Membership;

namespace Domain.Tests.TestDataGenerators.Membership
{
    internal static class RegisterUserRequestGenerator
    {
        public static IEnumerable<object[]> GetUserRequestTestDataSet()
        {
            yield return new object[]
            {
                new RegisterUserCommand("TestLogin", "PasswordTest", "EmailTest", "FirstName", "LastName", null),
                false
            };

            yield return new object[]
            {
                new RegisterUserCommand("TestLogin2", "PasswordTest2", "EmailTest2", "FirstName2", "LastName2", null),
                true
            };
        }
    }
}
