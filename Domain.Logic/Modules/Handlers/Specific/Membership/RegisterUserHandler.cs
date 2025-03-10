using AutoMapper;
using DataAccess.DTO.CommunicationObjects;
using dataUserDto = DataAccess.DTO.Membership;
using DataAccess.Logic.Repositories.Membership;
using Domain.Logic.Common.Handlers;
using Domain.Models.BusinessModels.Membership;
using Domain.Models.Handlers.Specific;
using Domain.Logic.Modules.Handlers.Helpers;
using Domain.DTO.Commands.Specific.Membership;
using Domain.DTO.Models.Membership;
using Domain.DTO.Common.Enums;

namespace Domain.Logic.Modules.Handlers.Specific.Membership
{
    internal class RegisterUserHandler : IHandler<RegisterUserCommand, RegisterUserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        internal RegisterUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<HandlerResult<RegisterUserDto>> HandleAsync(RegisterUserCommand request, CancellationToken ct)
        {
            User user = _mapper.Map<User>(request);

            DataOperationResult<dataUserDto.UserDto> dbResult = await _userRepository.CreateAsync(_mapper.Map<dataUserDto.UserDto>(user), ct);

            return dbResult.IsSuccess
                ? HandlerResultHelper.CreateHandlerResult(new RegisterUserDto(dbResult?.Data?.Id ?? Guid.Empty), operationDetail: _mapper.Map<OperationDetail>(dbResult?.OperationDetail))
                : HandlerResultHelper.CreateHandlerResult<RegisterUserDto>(operationDetail: _mapper.Map<OperationDetail>(dbResult?.OperationDetail));
        }
    }
}
