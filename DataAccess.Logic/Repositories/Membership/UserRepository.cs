using AutoMapper;
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

        public async Task<DataOperationResult<IEnumerable<UserDto>>> FindManyByRoleAsync(string roleName, FindOptions? findOptions = null)
        {
            IEnumerable<User> users = await _userManager.GetUsersInRoleAsync(roleName);

            return users is not null
                ? DataOperationResponseHelper.CreateResponse(_mapper.Map<IEnumerable<UserDto>>(users))
                : DataOperationResponseHelper.CreateResponse<IEnumerable<UserDto>>();
        }

        public async Task<DataOperationResult<UserDto>> FindByIdAsync(Guid id, FindOptions? findOptions = null)
        {
            User? user = await _userManager.FindByIdAsync(id.ToString());

            return user is not null
                ? DataOperationResponseHelper.CreateResponse(_mapper.Map<UserDto>(user))
                : DataOperationResponseHelper.CreateResponse<UserDto>();
        }

        public async Task<DataOperationResult<UserDto>> RegisterAsync(UserDto userDTO)
        {
            User user = _mapper.Map<User>(userDTO);
            IdentityResult result = await _userManager.CreateAsync(user, userDTO.Password ?? string.Empty);

            return result.Succeeded
                ? DataOperationResponseHelper.CreateResponse(_mapper.Map<UserDto>(user))
                : DataOperationResponseHelper.CreateResponse<UserDto>();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            User? user = await _userManager.FindByIdAsync(id.ToString());

            if (user is not null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
                return result.Succeeded;
            }

            return false;
        }

        public async Task<DataOperationResult<UserDto>> UpdateAsync(Guid id, UserDto userDTO)
        {
            User? user = await _userManager.FindByIdAsync(id.ToString());

            if (user is null)
                return DataOperationResponseHelper.CreateResponse<UserDto>();

            User userNewData = _mapper.Map<User>(userDTO);

            UpdateUserEntity(user, userNewData);

            IdentityResult result = await _userManager.UpdateAsync(user);

            return result.Succeeded
                ? DataOperationResponseHelper.CreateResponse(_mapper.Map<UserDto>(user))
                : DataOperationResponseHelper.CreateResponse<UserDto>();
        }

        public async Task<bool> UserExists(string login) => await _userManager.FindByNameAsync(login) != null;

        private void UpdateUserEntity(User user, User userNewData)
        {
            if (user is null)
                return;

            user.FirstName = userNewData.FirstName;
            user.LastName = userNewData.LastName;
            user.Email = userNewData.Email;
            user.PhoneNumber = userNewData.PhoneNumber;
            user.UserName = userNewData.UserName;
            user.PasswordHash = userNewData.PasswordHash;
        }
    }
}
