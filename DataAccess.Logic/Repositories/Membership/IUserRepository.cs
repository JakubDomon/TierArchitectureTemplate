using DataAccess.DTO.CommunicationObjects;
using DataAccess.DTO.Membership;

namespace DataAccess.Logic.Repositories.Membership
{
    public interface IUserRepository
    {
        public Task<DataOperationResult<IEnumerable<UserDto>>> FindManyByRoleAsync(string roleName, CancellationToken ct);
        public Task<DataOperationResult<UserDto>> FindByIdAsync(Guid id, CancellationToken ct);
        public Task<DataOperationResult<bool>> UpdateAsync(Guid id, UserDto userDTO, CancellationToken ct);
        public Task<DataOperationResult<UserDto>> CreateAsync(UserDto userDTO, CancellationToken ct);
        public Task<DataOperationResult<bool>> UserExists(string login);
        public Task<DataOperationResult<bool>> DeleteAsync(Guid id);
    }
}
