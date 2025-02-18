using AutoMapper;
using DataAccess.DTO.Authentication;
using DataAccess.DTO.CommunicationObjects;
using DataAccess.Logic.Repositories.Authentication;
using Domain.DTO.Models.Membership;
using Domain.DTO.Requests.Specific.Membership;
using Domain.DTO.Responses.Specific.Membership;
using Domain.Logic.Common.Handlers;
using Domain.Logic.Modules.Handlers.Helpers;
using Domain.Logic.Modules.Handlers.Specific.Membership.Helpers;
using Domain.Models.BusinessModels.Membership;
using Domain.Models.Handlers.Specific;
using Microsoft.Extensions.Configuration;

namespace Domain.Logic.Modules.Handlers.Specific.Membership
{
    internal class AuthenticateUserHandler : IHandler<AuthenticateUserRequest, AuthenticateUserResponse>
    {
        private readonly IAuthRepository _authRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        internal AuthenticateUserHandler(IAuthRepository authRepository, IMapper mapper, IConfiguration config)
        {
            _authRepository = authRepository;
            _mapper = mapper;
            _config = config;
        }

        public async Task<HandlerResult<AuthenticateUserResponse>> HandleAsync(AuthenticateUserRequest request)
        {
            DataOperationResult<AuthResult> result = await _authRepository.AuthenticateAsync(request.AuthenticationData.Login, request.AuthenticationData.Password);

            if (!result.IsSuccess)
                return HandlerResultHelper.CreateHandlerResult<AuthenticateUserResponse>();

            User user = _mapper.Map<User>(result.Data?.UserData);

            return HandlerResultHelper.CreateHandlerResult(new AuthenticateUserResponse(
                JwtHelper.GenerateJwt(user, _config)));
        }
    }
}
