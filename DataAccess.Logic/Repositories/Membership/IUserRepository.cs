using DataAccess.DTO.CommunicationObjects;
using DataAccess.DTO.Membership;

namespace DataAccess.Logic.Repositories.Membership
{
    public interface IUserRepository
    {
        public Task<DataOperationResult<IEnumerable<UserDto>>> FindManyByRoleAsync(string roleName, CancellationToken ct);
        public Task<DataOperationResult<UserDto>> FindByIdAsync(Guid id, CancellationToken ct);
        public Task<DataOperationResult<UserDto>> UpdateAsync(Guid id, UserDto userDTO, CancellationToken ct);
        public Task<DataOperationResult<UserDto>> RegisterAsync(UserDto userDTO, CancellationToken ct);
        public Task<bool> UserExists(string login);
        public Task<bool> DeleteAsync(Guid id);
    }
}
