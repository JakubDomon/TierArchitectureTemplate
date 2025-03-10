using AutoMapper;
using DataAccess.DTO.Common.CommunicationObjects.Enums;
using DataAccess.DTO.CommunicationObjects;
using DataAccess.DTO.Membership;
using DataAccess.Logic.Entities.Membership;
using DataAccess.Logic.Repositories.Helpers;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.Logic.Repositories.Membership
{
    public class UserRepository : IUserRepository
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        internal UserRepository(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<DataOperationResult<IEnumerable<UserDto>>> FindManyByRoleAsync(string roleName, CancellationToken ct)
        {
            IEnumerable<User> users = await _userManager.GetUsersInRoleAsync(roleName);

            return users is not null
                ? DataOperationResponseHelper.CreateResponse(_mapper.Map<IEnumerable<UserDto>>(users), OperationDetail.Ok)
                : DataOperationResponseHelper.CreateResponse<IEnumerable<UserDto>>(operationResult: OperationDetail.NoContent);
        }

        public async Task<DataOperationResult<UserDto>> FindByIdAsync(Guid id, CancellationToken ct)
        {
            User? user = await _userManager.FindByIdAsync(id.ToString());

            return user is not null
                ? DataOperationResponseHelper.CreateResponse(_mapper.Map<UserDto>(user), OperationDetail.Ok)
                : DataOperationResponseHelper.CreateResponse<UserDto>(operationResult: OperationDetail.NotFound);
        }

        public async Task<DataOperationResult<UserDto>> CreateAsync(UserDto userDTO, CancellationToken ct)
        {
            User user = _mapper.Map<User>(userDTO);
            IdentityResult result = await _userManager.CreateAsync(user, userDTO.Password ?? string.Empty);

            return result.Succeeded
                ? DataOperationResponseHelper.CreateResponse(_mapper.Map<UserDto>(user), OperationDetail.Created)
                : DataOperationResponseHelper.CreateResponse<UserDto>(operationResult: OperationDetail.Error);
        }

        public async Task<DataOperationResult<bool>> DeleteAsync(Guid id)
        {
            User? user = await _userManager.FindByIdAsync(id.ToString());

            if (user is not null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
                return DataOperationResponseHelper.CreateResponse(true, operationResult: OperationDetail.NoContent);
            }

            return DataOperationResponseHelper.CreateResponse(false, operationResult: OperationDetail.NotFound);
        }

        public async Task<DataOperationResult<bool>> UpdateAsync(Guid id, UserDto userDTO, CancellationToken ct)
        {
            User? user = await _userManager.FindByIdAsync(id.ToString());

            if (user is null)
                return DataOperationResponseHelper.CreateResponse(false, OperationDetail.NotFound);

            User userNewData = _mapper.Map<User>(userDTO);

            UpdateUserEntity(user, userNewData);

            IdentityResult result = await _userManager.UpdateAsync(user);

            return result.Succeeded
                ? DataOperationResponseHelper.CreateResponse(true, OperationDetail.NoContent)
                : DataOperationResponseHelper.CreateResponse(false, OperationDetail.Error);
        }

        public async Task<DataOperationResult<bool>> UserExists(string login)
        {
            var userExists = await _userManager.FindByNameAsync(login) != null;

            return userExists
                ? DataOperationResponseHelper.CreateResponse(true, OperationDetail.NoContent)
                : DataOperationResponseHelper.CreateResponse(false, OperationDetail.NotFound);
        }

        private void UpdateUserEntity(User user, User userNewData)
        {
            if (user is null)
                return;

            user.FirstName = userNewData.FirstName;
            user.LastName = userNewData.LastName;
            user.Email = userNewData.Email;
            user.PhoneNumber = userNewData.PhoneNumber;
            user.UserName = userNewData.UserName;
        }
    }
}
