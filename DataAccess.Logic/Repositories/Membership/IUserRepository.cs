using DataAccess.DTO.CommunicationObjects;
using DataAccess.DTO.Membership;

namespace DataAccess.Logic.Repositories.Membership
{
    public interface IUserRepository
    {
        public Task<DataOperationResult<IEnumerable<UserDto>>> FindManyByRoleAsync(string roleName, FindOptions? findOptions = null);
        public Task<DataOperationResult<UserDto>> FindByIdAsync(Guid id, FindOptions? findOptions = null);
        public Task<DataOperationResult<UserDto>> UpdateAsync(Guid id, UserDto userDTO);
        public Task<DataOperationResult<UserDto>> RegisterAsync(UserDto userDTO);
        public Task<bool> UserExists(string login);
        public Task<bool> DeleteAsync(Guid id);
    }
}
