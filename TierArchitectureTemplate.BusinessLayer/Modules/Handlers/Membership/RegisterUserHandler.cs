using BusinessLayer.Logic.Common.Communication.Concrete.Membership;
using BusinessLayer.Logic.Common.Handlers;
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
