using DataAccess.Logic.Entities.Membership;

namespace DataAccess.Tests.DataHelpers
{
    internal static class MembershipContextDataHelper
    {
        public static IEnumerable<User> GetFakeUsersSet() => [
            new User
            {
                Id = new Guid("19feb8a7-3e1d-4970-a95e-f9e88c5e1559"),
                UserName = "TestUserName",
                Email = "testUserName@test.com",
                FirstName = "test",
                LastName = "test",
                PasswordHash = "testPasswordHash"
            },
            new User
            {
                Id = new Guid("709e2aeb-b511-45c1-acb8-f06ec574c95f"),
                UserName = "TestUserName2",
                Email = "testUserName2@test.com",
                FirstName = "test2",
                LastName = "test2",
                PasswordHash = "testPasswordHash2"
            }];
    }
}
