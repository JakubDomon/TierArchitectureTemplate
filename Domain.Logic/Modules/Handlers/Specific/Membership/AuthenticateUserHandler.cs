using AutoMapper;
using DataAccess.DTO.Authentication;
using DataAccess.DTO.CommunicationObjects;
using DataAccess.Logic.Repositories.Authentication;
using Domain.DTO.Commands.Specific.Membership;
using Domain.DTO.Common.Enums;
using Domain.DTO.Models.Membership;
using Domain.Logic.Common.Handlers;
using Domain.Logic.Modules.Handlers.Helpers;
using Domain.Logic.Modules.Handlers.Specific.Membership.Helpers;
using Domain.Models.BusinessModels.Membership;
using Domain.Models.Handlers.Specific;
using Microsoft.Extensions.Configuration;

namespace Domain.Logic.Modules.Handlers.Specific.Membership
{
    internal class AuthenticateUserHandler : IHandler<AuthenticateUserCommand, AuthenticateUserDto>
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

        public async Task<HandlerResult<AuthenticateUserDto>> HandleAsync(AuthenticateUserCommand request, CancellationToken ct)
        {
            DataOperationResult<AuthResult> dbResult = await _authRepository.AuthenticateAsync(request.Login, request.Password, ct);

            if (!dbResult.IsSuccess)
                return HandlerResultHelper.CreateHandlerResult<AuthenticateUserDto>(operationDetail: _mapper.Map<OperationDetail>(dbResult.OperationDetail));

            User user = _mapper.Map<User>(dbResult.Data?.UserData);

            return HandlerResultHelper.CreateHandlerResult(new AuthenticateUserDto(JwtHelper.GenerateJwt(user, _config)), operationDetail: OperationDetail.Ok);
        }
    }
}
