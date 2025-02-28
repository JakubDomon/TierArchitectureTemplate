using DataAccess.Logic.Repositories.Membership;
using Domain.DTO.Commands.Specific.Membership;
using Domain.Logic.Modules.Validators.Membership;
using Domain.Tests.TestDataGenerators.Membership;
using Moq;

namespace Domain.Tests.Validators.Membership
{
    public class MembershipValidatorTests
    {
        [Theory]
        [MemberData(nameof(RegisterUserRequestGenerator.GetUserRequestTestDataSet), MemberType = typeof(RegisterUserRequestGenerator))]
        public async void TestRegisterUserValidator(RegisterUserCommand request, bool shouldSuccess)
        {
            // Arrange
            Mock<IUserRepository> userRepositoryMock = new();
            var validator = new RegisterUserValidator(userRepositoryMock.Object);

            string[] existingUserLogins = ["validUser1", "validUser2"];

            userRepositoryMock.Setup(x => x.UserExists(It.IsAny<string>()))
                .ReturnsAsync(existingUserLogins.Contains(request.UserName));

            // Act
            var result = await validator.ValidateAsync(request);

            // Assert
            Assert.Equal(shouldSuccess, result.IsSucceeded);
        }
    }
}
