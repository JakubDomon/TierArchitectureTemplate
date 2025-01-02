using DataAccess.DTO;
using DataAccess.DTO.CommunicationObjects;
using System.Linq.Expressions;

namespace DataAccess.Logic.Repositories.Generic
{
    public interface IRepository<TEntity, TDto>
        where TEntity : class
        where TDto : BaseDTO
    {
        public Task<DataOperationResult<IEnumerable<TDto>>> GetAllAsync(FindOptions? findOptions = null);
        public Task<DataOperationResult<TDto>> FindByIdAsync(Guid id, FindOptions? findOptions = null);
        public Task<DataOperationResult<IEnumerable<TDto>>> FindAsync(Expression<Func<TDto, bool>> predicate, FindOptions? findOptions = null);
        public Task<DataOperationResult<TDto>> AddAsync(TDto dto);
        public Task<DataOperationResult<TDto>> UpdateAsync(Guid id, TDto dto);
        public Task<bool> DeleteAsync(Guid id);
        public Task<bool> DeleteManyAsync(Expression<Func<TDto, bool>> predicate);
        public Task<bool> AnyAsync();
        public Task<int> CountAsync();
    }
}
