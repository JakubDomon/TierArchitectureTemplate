using BusinessLayer.Logic.Common.Communication.Concrete.Membership;
using BusinessLayer.Logic.Common.Handlers;

namespace BusinessLayer.Logic.Modules.Handlers.Membership
{
    internal class RegisterUserHandler() : IHandler<RegisterUserRequest, RegisterUserResponse>
    {
        public Task<RegisterUserResponse?> HandleAsync(RegisterUserRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
