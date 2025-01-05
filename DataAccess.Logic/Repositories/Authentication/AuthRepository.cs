using AutoMapper;
using DataAccess.DTO.Authentication;
using DataAccess.DTO.CommunicationObjects;
using DataAccess.DTO.Membership;
using DataAccess.Logic.Entities.Membership;
using DataAccess.Logic.Repositories.Helpers;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.Logic.Repositories.Authentication
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;

        internal AuthRepository(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        public async Task<DataOperationResult<AuthResult>> AuthenticateAsync(string login, string password)
        {
            var user = await _userManager.FindByNameAsync(login);

            if (user is null)
                return DataOperationResponseHelper.CreateResponse<AuthResult>();

            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);

            return result.Succeeded
                ? DataOperationResponseHelper.CreateResponse(new AuthResult(_mapper.Map<UserDto>(user)))
                : DataOperationResponseHelper.CreateResponse<AuthResult>();
        }
    }
}
