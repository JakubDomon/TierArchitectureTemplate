using BusinessLayer.Logic.Common.Handlers;
using BusinessLayer.Models.Communication.Messages.Requests.Specific.Membership;
using BusinessLayer.Models.Communication.Messages.Responses.Specific.Membership;
using DataAccessLayer.Repositories.Membership;

namespace BusinessLayer.Logic.Modules.Handlers.Membership
{
    internal class RegisterUserHandler(IUserRepository userRepository) : IHandler<RegisterUserRequest, RegisterUserResponse>
    {
        public Task<RegisterUserResponse?> HandleAsync(RegisterUserRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
