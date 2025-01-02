using AutoMapper;
using DataAccess.DTO.CommunicationObjects;
using DataAccess.DTO.Membership;
using DataAccess.Logic.Entities.Membership;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

namespace DataAccess.Logic.Repositories.Membership
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        internal UserRepository(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<DataOperationResult<IEnumerable<UserDTO>>> FindManyByRoleAsync(string roleName, FindOptions? findOptions = null)
        {
            IEnumerable<User> users = await _userManager.GetUsersInRoleAsync(roleName);

            return users != null
                ? CreateSuccessResponse(_mapper.Map<IEnumerable<UserDTO>>(users))
                : CreateErrorResponse<IEnumerable<UserDTO>>();
        }

        public async Task<DataOperationResult<UserDTO>> FindByIdAsync(Guid id, FindOptions? findOptions = null)
        {
            User? user = await _userManager.FindByIdAsync(id.ToString());

            return user != null
                ? CreateSuccessResponse(_mapper.Map<UserDTO>(user))
                : CreateErrorResponse<UserDTO>();
        }

        public async Task<DataOperationResult<UserDTO>> CreateAsync(UserDTO userDTO)
        {
            User user = _mapper.Map<User>(userDTO);
            IdentityResult result = await _userManager.CreateAsync(user, userDTO.Password ?? string.Empty);

            if (result.Succeeded)
            {
                return CreateSuccessResponse(_mapper.Map<UserDTO>(user));
            }

            return CreateErrorResponse<UserDTO>();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            User? user = await _userManager.FindByIdAsync(id.ToString());

            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
                return result.Succeeded;
            }

            return false;
        }

        public async Task<DataOperationResult<UserDTO>> UpdateAsync(Guid id, UserDTO userDTO)
        {
            User? user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
                return CreateErrorResponse<UserDTO>();

            User userNewData = _mapper.Map<User>(userDTO);

            UpdateUserEntity(user, userNewData);

            IdentityResult result = await _userManager.UpdateAsync(user);

            return result.Succeeded
                ? CreateSuccessResponse(_mapper.Map<UserDTO>(user))
                : CreateErrorResponse<UserDTO>();
        }

        public async Task<bool> UserExists(string login) => await _userManager.FindByNameAsync(login) != null;

        private void UpdateUserEntity(User user, User userNewData)
        {
            if (user == null)
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
