using DataAccessLayer.DTO.CommunicationObjects;
using DataAccessLayer.DTO.Membership;

namespace DataAccessLayer.Repositories.Membership
{
    public interface IUserRepository
    {
        public Task<DataOperationResult<UserDTO>> GetByIdAsync(Guid id);
        public Task<DataOperationResult<UserDTO>> CreateAsync(UserDTO userDTO);
        public Task<DataOperationResult<UserDTO>> UpdateAsync(Guid id, UserDTO userDTO);
        public Task<bool> DeleteAsync(Guid id);
    }
}
