using AutoMapper;
using DataAccess.DTO.CommunicationObjects;
using DataAccess.DTO.Membership;
using DataAccess.Logic.Entities.Membership;
using DataAccess.Logic.Mapping.Membership;
using DataAccess.Logic.Repositories.Membership;
using DataAccess.Tests.DataHelpers;
using DataAccess.Tests.FakeObjects;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace DataAccess.Tests.Repositories
{
    public class UserRepositoryTests
    {
        private readonly IUserRepository _userRepository;
        private readonly Mock<FakeUserManager> _fakeUserManagerMock;
        private readonly Mock<FakeSignInManager> _fakeSignInManagerMock;
        private readonly IMapper _mapper;

        public UserRepositoryTests()
        {
            _fakeUserManagerMock = new Mock<FakeUserManager>();
            _fakeSignInManagerMock = new Mock<FakeSignInManager>();
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UserProfile>();
            }).CreateMapper();

            _userRepository = new UserRepository(_mapper, _fakeUserManagerMock.Object, _fakeSignInManagerMock.Object);
        }

        [Theory]
        [InlineData("19feb8a7-3e1d-4970-a95e-f9e88c5e1559", true)]
        [InlineData("e5a429f7-42f4-4971-8ade-896e1d91cd0e", false)]
        public async void FindById_ShouldReturnDataOperationResult(string id, bool shouldSucceed)
        {
            CancellationToken cancellationToken = new CancellationToken();

            // Arrange
            User? user = MembershipContextDataHelper.GetFakeUsersSet().FirstOrDefault(x => x.Id.Equals(new Guid(id)));

            _fakeUserManagerMock
                .Setup(m => m.FindByIdAsync(id))
                .ReturnsAsync(user);
            
            // Act
            DataOperationResult<UserDto> result = await _userRepository.FindByIdAsync(new Guid(id), cancellationToken);

            // Assert
            if (shouldSucceed)
            {
                Assert.NotNull(result);
                Assert.NotNull(result.Data);
                Assert.Equal(result.Data.Id.ToString(), id);
                Assert.True(result.IsSuccess);
            }
            else
            {
                Assert.NotNull(result);
                Assert.Null(result.Data);
                Assert.False(result.IsSuccess);
            }
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async void RegisterAsync_ShouldReturnDataOperationResult(bool shouldUserCreationSucceed)
        {
            CancellationToken cancellationToken = new CancellationToken();

            // Arrange
            UserDto userDto = new()
            {
                UserName = "TestUser",
                Password = "password",
                Email = "email@email.pl",
                FirstName = "testFirstName",
                LastName = "testLastName"
            };

            User user = MembershipContextDataHelper.GetFakeUsersSet().First();

            _fakeUserManagerMock
                .Setup(m => m.CreateAsync(It.IsAny<User>(), It.IsAny<string>()))
                .ReturnsAsync(shouldUserCreationSucceed 
                    ? IdentityResult.Success 
                    : IdentityResult.Failed(new IdentityError() 
                        { 
                            Code = "someCode" 
                        }));

            // Act
            DataOperationResult<UserDto> result = await _userRepository.RegisterAsync(userDto, cancellationToken);

            // Assert
            if (shouldUserCreationSucceed)
            {
                Assert.NotNull(result);
                Assert.NotNull(result.Data);
                Assert.True(result.IsSuccess);
            }
            else
            {
                Assert.NotNull(result);
                Assert.Null(result.Data);
                Assert.False(result.IsSuccess);
            }
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, false)]
        [InlineData(false, true)]
        public async void DeleteAsync_ShouldReturnBool(bool shouldUserBeFound, bool shouldUserDeleteSucceed)
        {
            // Arrange
            User user = MembershipContextDataHelper.GetFakeUsersSet().First();

            _fakeUserManagerMock
                .Setup(m => m.FindByIdAsync(It.IsAny<string>()))
                .ReturnsAsync(shouldUserBeFound
                    ? user
                    : null);
            _fakeUserManagerMock
                .Setup(m => m.DeleteAsync(It.IsAny<User>()))
                .ReturnsAsync(shouldUserDeleteSucceed
                    ? IdentityResult.Success
                    : IdentityResult.Failed(new IdentityError()
                        {
                            Code = "someCode"
                        }));

            // Act
            bool result = await _userRepository.DeleteAsync(new Guid());

            // Assert
            if (shouldUserBeFound)
            {
                if (shouldUserDeleteSucceed)
                {
                    Assert.True(result);
                }
                else
                {
                    Assert.False(result);
                }
            }
            else
            {
                Assert.False(result);
            }
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async void UpdateUser_ShouldReturnDataOperationResult(bool shouldUserBeFound)
        {
            CancellationToken cancellationToken = new CancellationToken();

            // Arrange
            User oldUserData = new()
            {
                FirstName = "oldFirstName",
                LastName = "oldLastName",
                Email = "oldEmail",
                PhoneNumber = "oldPhNb",
                UserName = "oldUserName",
            };

            UserDto newUserData = new()
            {
                FirstName = "newFirstName",
                LastName = "newLastName",
                Email = "newEmail",
                PhoneNumber = "newPhNb",
                UserName = "newUserName",
            };

            _fakeUserManagerMock
                .Setup(m => m.FindByIdAsync(It.IsAny<string>()))
                .ReturnsAsync(shouldUserBeFound
                    ? oldUserData 
                    : null);
            _fakeUserManagerMock
                .Setup(m => m.UpdateAsync(It.IsAny<User>()))
                .ReturnsAsync(IdentityResult.Success);

            // Act
            DataOperationResult<UserDto> result = await _userRepository.UpdateAsync(new Guid(), newUserData, cancellationToken);

            // Assert
            if (shouldUserBeFound)
            {
                Assert.NotNull(result);
                Assert.NotNull(result.Data);
                Assert.True(result.IsSuccess);

                Assert.Equal(result.Data.FirstName, newUserData.FirstName);
                Assert.Equal(result.Data.LastName, newUserData.LastName);
                Assert.Equal(result.Data.Email, newUserData.Email);
                Assert.Equal(result.Data.PhoneNumber, newUserData.PhoneNumber);
                Assert.Equal(result.Data.UserName, newUserData.UserName);
            }
            else
            {
                Assert.NotNull(result);
                Assert.Null(result.Data);
                Assert.False(result.IsSuccess);
            }
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async void UserExists_ShouldReturnBool(bool shouldFindUser)
        {
            // Arrange
            User foundUser = new User()
            {
                FirstName = "test"
            };

            _fakeUserManagerMock
                .Setup(m => m.FindByNameAsync(It.IsAny<string>()))
                .ReturnsAsync(shouldFindUser ? foundUser : null);

            // Act
            bool result = await _userRepository.UserExists("someUser");

            // Assert
            if (shouldFindUser)
            {
                Assert.True(result);
            }
            else
            {
                Assert.False(result);
            }
        }
    }
}
