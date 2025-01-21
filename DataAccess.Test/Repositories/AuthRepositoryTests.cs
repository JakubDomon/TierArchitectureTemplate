using AutoMapper;
using DataAccess.Logic.Entities.Membership;
using DataAccess.Logic.Mapping.Membership;
using DataAccess.Logic.Repositories.Authentication;
using Microsoft.AspNetCore.Identity;
using Moq;
using DataAccess.Tests.DataHelpers;
using DataAccess.Tests.FakeObjects;
using DataAccess.DTO.CommunicationObjects;
using DataAccess.DTO.Authentication;

namespace DataAccess.Tests.Repositories
{
    public class AuthRepositoryTests
    {
        [Theory]
        [InlineData("TestUserName", "testPasswordHash", true)]
        [InlineData("TestUserName", "IncorrectPassword", false)]
        [InlineData("TestUserNameNotExist", "IncorrectPasstword", false)]
        public async void Authenticate_ShouldReturnDataOperationResult(string login, string password, bool shouldAuthenticate)
        {
            // Arrange
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UserProfile>();
            }).CreateMapper();

            var fakeMockUserManager = new Mock<FakeUserManager>();
            var fakeMockSignInManager = new Mock<FakeSignInManager>();

            var testUser = MembershipContextDataHelper.GetFakeUsersSet().FirstOrDefault(u => u.UserName == login);
            var wouldAuthenticate = testUser != null
                ? testUser.PasswordHash == password
                : false;

            fakeMockUserManager
                .Setup(x => x.FindByNameAsync(login))
                .ReturnsAsync(testUser);

            fakeMockSignInManager
                .Setup(x => x.CheckPasswordSignInAsync(It.IsAny<User>(), password, false))
                .ReturnsAsync(wouldAuthenticate
                    ? SignInResult.Success
                    : SignInResult.Failed);

            IAuthRepository authRepository = new AuthRepository(fakeMockUserManager.Object, fakeMockSignInManager.Object, mapper);

            // Act
            DataOperationResult<AuthResult> result = await authRepository.AuthenticateAsync(login, password);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.IsSuccess == shouldAuthenticate);
        }
    }
}
