using AutoMapper;
using DataAccess.DTO.CommunicationObjects;
using dataUserDto = DataAccess.DTO.Membership;
using DataAccess.Logic.Repositories.Membership;
using Domain.DTO.Requests.Specific.Membership;
using Domain.DTO.Responses.Specific.Membership;
using Domain.Logic.Common.Handlers;
using Domain.Models.BusinessModels.Membership;
using Domain.Models.Handlers.Specific;
using Domain.Logic.Modules.Handlers.Helpers;

namespace Domain.Logic.Modules.Handlers.Specific.Membership
{
    internal class RegisterUserHandler : IHandler<RegisterUserRequest, RegisterUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        internal RegisterUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<HandlerResult<RegisterUserResponse>> HandleAsync(RegisterUserRequest request, CancellationToken ct)
        {
            User user = _mapper.Map<User>(request.UserData);

            DataOperationResult<dataUserDto.UserDto> result = await _userRepository.RegisterAsync(_mapper.Map<dataUserDto.UserDto>(user), ct);

            return result.IsSuccess
                ? HandlerResultHelper.CreateHandlerResult(new RegisterUserResponse() 
                    { 
                        UserId = result.Data.Id
                    })
                : HandlerResultHelper.CreateHandlerResult<RegisterUserResponse>();
        }
    }
}
