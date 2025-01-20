using DataAccess.Logic.Entities.Membership;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;

namespace DataAccess.Tests.FakeObjects
{
    internal class FakeSignInManager : SignInManager<User>
    {
        public FakeSignInManager()
            : base(Mock.Of<FakeUserManager>(),
                  Mock.Of<IHttpContextAccessor>(),
                  Mock.Of<IUserClaimsPrincipalFactory<User>>(),
                  Mock.Of<IOptions<IdentityOptions>>(),
                  Mock.Of<ILogger<SignInManager<User>>>(),
                  Mock.Of<IAuthenticationSchemeProvider>()) { }
    }
}
