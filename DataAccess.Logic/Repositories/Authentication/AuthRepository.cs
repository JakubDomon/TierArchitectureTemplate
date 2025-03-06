using AutoMapper;
using DataAccess.DTO.Authentication;
using DataAccess.DTO.Common.CommunicationObjects.Enums;
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

        public async Task<DataOperationResult<AuthResult>> AuthenticateAsync(string login, string password, CancellationToken ct)
        {
            var user = await _userManager.FindByNameAsync(login);

            if (user is null)
                return DataOperationResponseHelper.CreateResponse<AuthResult>(operationResult: OperationDetail.Unauthorized);

            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);

            return DataOperationResponseHelper.CreateResponse(
                new AuthResult(result.Succeeded, 
                    result.Succeeded 
                        ? _mapper.Map<UserDto>(user) 
                        : default),
                    result.Succeeded
                        ? OperationDetail.Ok
                        : OperationDetail.Unauthorized);
        }
    }
}
