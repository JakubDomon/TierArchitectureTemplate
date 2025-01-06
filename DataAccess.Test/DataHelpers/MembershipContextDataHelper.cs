using DataAccess.Logic.Entities.Membership;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.Tests.DataHelpers
{
    internal static class MembershipContextDataHelper
    {
        public static IEnumerable<User> GetFakeUsersSet() => [
            new User
            {
                Id = Guid.NewGuid(),
                UserName = "TestUserName",
                Email = "testUserName@test.com",
                FirstName = "test",
                LastName = "test",
                PasswordHash = "testPasswordHash"
            },
            new User
            {
                Id = Guid.NewGuid(),
                UserName = "TestUserName2",
                Email = "testUserName2@test.com",
                FirstName = "test2",
                LastName = "test2",
                PasswordHash = "testPasswordHash2"
            }];
    }
}
