using AutoMapper;
using DataAccessLayer.DTO.Membership;
using DataAccessLayer.Entities.Membership;
using Microsoft.AspNetCore.Identity;

namespace DataAccessLayer.Services.Membership
{
    public class UserService : IUserService
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

        public Task<UserDTO?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO?> UpdateAsync(Guid id, UserDTO userDTO)
        {
            throw new NotImplementedException();
        }
    }
}
