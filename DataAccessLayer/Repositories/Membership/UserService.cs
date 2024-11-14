using AutoMapper;
using DataAccessLayer.DTO.CommunicationObjects;
using DataAccessLayer.DTO.Membership;
using DataAccessLayer.Entities.Membership;
using DataAccessLayer.Utils.UpdateHelper;
using Microsoft.AspNetCore.Identity;

namespace DataAccessLayer.Repositories.Membership
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        internal UserRepository(IMapper mapper, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<DataOperationResult<UserDTO>> GetByIdAsync(Guid id)
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

            user.Update(userNewData)
                .UpdateProperty(u => u.FirstName)
                .UpdateProperty(u => u.LastName)
                .UpdateProperty(u => u.Email)
                .UpdateProperty(u => u.PhoneNumber)
                .UpdateProperty(u => u.UserName)
                .UpdateProperty(u => u.PasswordHash)
                .ApplyUpdate();

            IdentityResult result = await _userManager.UpdateAsync(user);

            return result.Succeeded
                ? CreateSuccessResponse(_mapper.Map<UserDTO>(user))
                : CreateErrorResponse<UserDTO>();
        }
    }
}
