using AutoMapper;
using DataAccess.Logic.Contexts;
using DataAccess.Logic.Entities.Membership;
using DataAccess.Logic.Mapping.Membership;
using DataAccess.Logic.Repositories.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Moq;
using Microsoft.AspNetCore.Http;
using Moq.EntityFrameworkCore;
using DataAccess.Tests.DataHelpers;
using DataAccess.Logic.Configuration.Helpers;

namespace DataAccess.Tests.Repositories
{
    public class AuthRepositoryTests
    {
        [Theory]
        [InlineData("TestUserName", "testPasswordHash", true)]
        public async void ShouldAuthenticate(string login, string password, bool shouldAuthenticate)
        {
            // Arrange
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UserProfile>();
            }).CreateMapper();

            var mockMembershipContext = new Mock<MembershipContext>(
                Mock.Of<ConnectionStringHelper>());
            var mockUserManager = GetMockUserManager();
            var mockSignInManager = GetMockSignInManager(mockUserManager);

            mockMembershipContext
                .Setup(x => x.Users)
                .ReturnsDbSet(MembershipContextDataHelper.GetFakeUsersSet());

            var testUser = mockMembershipContext.Object.Users.FirstOrDefault(u => u.UserName == login);
            mockSignInManager
                .Setup(x => x.PasswordSignInAsync(login, password, false, false))
                .ReturnsAsync((testUser != null && testUser.PasswordHash == password)
                    ? SignInResult.Success 
                    : SignInResult.Failed);

            var authRepository = new AuthRepository(mockUserManager.Object, mockSignInManager.Object, mapper);

            // Act
            var result = await authRepository.AuthenticateAsync(login, password);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.IsSuccess);
        }

        private Mock<UserManager<User>> GetMockUserManager() => new Mock<UserManager<User>>(
                Mock.Of<IUserStore<User>>(),
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null);

        private Mock<SignInManager<User>> GetMockSignInManager(Mock<UserManager<User>> mockUserManager) => new Mock<SignInManager<User>>(
            mockUserManager.Object,
            Mock.Of<IHttpContextAccessor>(),
            Mock.Of<IUserClaimsPrincipalFactory<User>>(),
            null,
            Mock.Of<ILogger<SignInManager<User>>>(),
            null,
            null);
    }
}
