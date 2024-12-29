using DataAccess.Repositories.Membership;
using Domain.DTO.Requests.Specific.Membership;
using Domain.DTO.Responses.Specific.Membership;
using Domain.Logic.Common.Handlers;
using Domain.Models.BusinessModels.Membership;
using Domain.Models.Handlers.Specific;

namespace Domain.Logic.Modules.Handlers.Specific.Membership
{
    internal class RegisterUserHandler(IUserRepository userRepository) : IHandler<RegisterUserRequest, RegisterUserResponse>
    {
        private IUserRepository _userRepository { get; set; } = userRepository;

        public override async Task<HandlerResult<RegisterUserResponse>> HandleAsync(RegisterUserRequest request)
        {
            User user =
            _userRepository.CreateAsync()
        }
    }
}
