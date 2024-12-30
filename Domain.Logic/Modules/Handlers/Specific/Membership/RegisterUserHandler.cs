using DataAccess.Logic.Repositories.Membership;
using Domain.DTO.Requests.Specific.Membership;
using Domain.DTO.Responses.Specific.Membership;
using Domain.Logic.Common.Handlers;
using Domain.Logic.Modules.Handlers.Helpers;
using Domain.Models.Handlers.Specific;

namespace Domain.Logic.Modules.Handlers.Specific.Membership
{
    internal class RegisterUserHandler(IUserRepository userRepository) : IHandler<RegisterUserRequest, RegisterUserResponse>
    {
        private IUserRepository _userRepository { get; set; } = userRepository;

        public async Task<HandlerResult<RegisterUserResponse>> HandleAsync(RegisterUserRequest request)
        {
            return await Task.Run(() => HandlerResultHelper.CreateHandlerResult(new RegisterUserResponse() { UserId = Guid.NewGuid() }));
        }
    }
}
