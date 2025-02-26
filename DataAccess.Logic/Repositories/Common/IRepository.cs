using DataAccess.DTO;
using DataAccess.DTO.CommunicationObjects;
using System.Linq.Expressions;

namespace DataAccess.Logic.Repositories.Common
{
    public interface IRepository<TDto>
        where TDto : EntityDto
    {
        public Task<DataOperationResult<IEnumerable<TDto>>> GetAllAsync(CancellationToken ct);
        public Task<DataOperationResult<TDto>> FindByIdAsync(Guid id, CancellationToken ct);
        public Task<DataOperationResult<IEnumerable<TDto>>> FindAsync(Expression<Func<TDto, bool>> predicate, CancellationToken ct);
        public Task<DataOperationResult<TDto>> AddAsync(TDto dto, CancellationToken ct);
        public Task<DataOperationResult<TDto>> UpdateAsync(Guid id, TDto dto, CancellationToken ct);
        public Task<bool> DeleteAsync(Guid id, CancellationToken ct);
        public Task<bool> DeleteManyAsync(Expression<Func<TDto, bool>> predicate, CancellationToken ct);
        public Task<bool> AnyAsync(CancellationToken ct);
        public Task<int> CountAsync(CancellationToken ct);
    }
}
