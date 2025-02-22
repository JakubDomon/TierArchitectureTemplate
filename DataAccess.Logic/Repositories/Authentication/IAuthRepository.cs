using DataAccess.DTO.Authentication;
using DataAccess.DTO.CommunicationObjects;

namespace DataAccess.Logic.Repositories.Authentication
{
    public interface IAuthRepository
    {
        public Task<DataOperationResult<AuthResult>> AuthenticateAsync(string login, string password, CancellationToken ct);
    }
}
