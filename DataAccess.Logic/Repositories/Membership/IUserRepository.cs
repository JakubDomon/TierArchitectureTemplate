using DataAccess.DTO.CommunicationObjects;
using DataAccess.DTO.Membership;
using System.Linq.Expressions;

namespace DataAccess.Logic.Repositories.Membership
{
    public interface IUserRepository
    {
        public Task<DataOperationResult<IEnumerable<UserDTO>>> FindManyByRoleAsync(string roleName, FindOptions? findOptions = null);
        public Task<DataOperationResult<UserDTO>> FindByIdAsync(Guid id, FindOptions? findOptions = null);
        public Task<DataOperationResult<UserDTO>> UpdateAsync(Guid id, UserDTO userDTO);
        public Task<DataOperationResult<UserDTO>> CreateAsync(UserDTO userDTO);
        public Task<bool> UserExists(string login);
        public Task<bool> DeleteAsync(Guid id);
    }
}
