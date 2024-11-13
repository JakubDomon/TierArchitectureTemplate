using AutoMapper;
using DataAccessLayer.DTO.Membership;
using DataAccessLayer.Entities.Membership;
using DataAccessLayer.Utils.UpdateHelper;
using Microsoft.AspNetCore.Identity;

namespace DataAccessLayer.Services.Membership
{
    public class UserService : IUserRepository
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        internal UserService(IMapper mapper, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<UserDTO?> CreateAsync(UserDTO userDTO)
        {
            User user = _mapper.Map<User>(userDTO);
            IdentityResult result = await _userManager.CreateAsync(user, userDTO.Password ?? string.Empty);

            if (result.Succeeded)
            {
                return userDTO;
            }

            return default;
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

        public async Task<UserDTO?> GetByIdAsync(Guid id)
        {
            User? user = await _userManager.FindByIdAsync(id.ToString());

            return user != null
                ? _mapper.Map<UserDTO>(user)
                : default;
        }

        public async Task<UserDTO?> UpdateAsync(Guid id, UserDTO userDTO)
        {
            User? user = await _userManager.FindByIdAsync(id.ToString());

            if(user == null) 
                return default;

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
                ? _mapper.Map<UserDTO>(user)
                : default;
        }

        private void UpdateUserFields(User dbUser, User newUserData)
        {

        }
    }
}
