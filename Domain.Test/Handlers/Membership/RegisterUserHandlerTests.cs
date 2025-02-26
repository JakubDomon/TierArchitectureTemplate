using AutoMapper;
using DataAccess.DTO.CommunicationObjects;
using DataAccess.DTO.Membership;
using DataAccess.Logic.Repositories.Membership;
using Domain.DTO.Models.Membership;
using Domain.DTO.Requests.Specific.Membership;
using Domain.Logic.Modules.Handlers.Specific.Membership;
using Domain.Models.BusinessModels.Membership;
using Moq;

namespace Domain.Tests.Handlers.Membership
{
    public class RegisterUserHandlerTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly IMapper _mapper;
        private readonly RegisterUserHandler _handler;

        public RegisterUserHandlerTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDto, User>().ReverseMap();
                cfg.CreateMap<RegisterUserDto, User>().ReverseMap();
            });
            _mapper = new Mapper(mapperConfig);

            _handler = new RegisterUserHandler(_userRepositoryMock.Object, _mapper);
        }

        [Fact]
        public async Task HandleAsync_SuccessfulRegistration_ReturnsHandlerResultWithUserId()
        {
            // Arrange
            var request = new RegisterUserRequest(new RegisterUserDto()
            {
                UserName = "TestUserName",
                Password = "TestPassword",
                Email = "TestEmail@email.com",
                FirstName = "FirstName",
                LastName = "LastName",
                PhoneNumber = "123123123"
            });
            var dataOperationResult = new DataOperationResult<UserDto>() { Data =  new UserDto() { Id = Guid.NewGuid() } };

            _userRepositoryMock.Setup(repo => repo.RegisterAsync(It.IsAny<UserDto>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(dataOperationResult);
            

            // Act
            var result = await _handler.HandleAsync(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.IsSuccess);
            Assert.Equal(dataOperationResult.Data.Id, result?.Data?.UserId);
        }

        [Fact]
        public async Task HandleAsync_FailedRegistration_ReturnsHandlerResultWithoutUserId()
        {
            // Arrange
            var request = new RegisterUserRequest(new RegisterUserDto()
            {
                UserName = "TestUserName",
                Password = "TestPassword",
                Email = "TestEmail@email.com",
                FirstName = "FirstName",
                LastName = "LastName",
                PhoneNumber = "123123123"
            });
            var dataOperationResult = new DataOperationResult<UserDto>();

            _userRepositoryMock.Setup(repo => repo.RegisterAsync(It.IsAny<UserDto>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(dataOperationResult);


            // Act
            var result = await _handler.HandleAsync(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.IsSuccess);
            Assert.Null(result?.Data?.UserId);
        }
    }
}
