using DataAccessLayer.DTO.Membership;

namespace DataAccessLayer.Services.Membership
{
    public interface IUserService
    {
        public Task<UserDTO?> GetByIdAsync(Guid id);
        public Task<UserDTO?> CreateAsync(UserDTO userDTO);
        public Task<UserDTO?> UpdateAsync(Guid id, UserDTO userDTO);
        public Task<bool> DeleteAsync(Guid id);
    }
}
