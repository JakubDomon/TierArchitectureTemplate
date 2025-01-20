using AutoMapper;
using DataAccess.DTO.CommunicationObjects;
using DataAccess.DTO.Membership;
using DataAccess.Logic.Entities.Membership;
using DataAccess.Logic.Mapping.Membership;
using DataAccess.Logic.Repositories.Membership;
using DataAccess.Tests.DataHelpers;
using DataAccess.Tests.FakeObjects;
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
        public async void FindByIdAndReturnDataOperationResult(string id, bool shouldSucceed)
        {
            // Arrange
            User? user = MembershipContextDataHelper.GetFakeUsersSet().FirstOrDefault(x => x.Id.Equals(new Guid(id)));

            _fakeUserManagerMock
                .Setup(m => m.FindByIdAsync(id))
                .ReturnsAsync(user);
            
            // Act
            DataOperationResult<UserDto> result = await _userRepository.FindByIdAsync(new Guid(id));

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


    }
}
