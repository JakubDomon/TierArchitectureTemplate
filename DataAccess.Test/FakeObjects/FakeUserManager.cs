using DataAccess.Logic.Entities.Membership;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;

namespace DataAccess.Tests.FakeObjects
{
    internal class FakeUserManager : UserManager<User>
    {
        internal FakeUserManager()
            : base(Mock.Of<IUserStore<User>>(),
                  Mock.Of<IOptions<IdentityOptions>>(),
                  Mock.Of<IPasswordHasher<User>>(),
                  [Mock.Of<IUserValidator<User>>()],
                  [Mock.Of<IPasswordValidator<User>>()],
                  Mock.Of<ILookupNormalizer>(),
                  Mock.Of<IdentityErrorDescriber>(),
                  Mock.Of<IServiceProvider>(),
                  Mock.Of<ILogger<UserManager<User>>>())
        { }
    }
}
