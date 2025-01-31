using DataAccess.DTO;
using DataAccess.DTO.CommunicationObjects;
using System.Linq.Expressions;

namespace DataAccess.Logic.Repositories.Generic
{
    public interface IRepository<TDto>
        where TDto : BaseDto
    {
        public Task<DataOperationResult<IEnumerable<TDto>>> GetAllAsync();
        public Task<DataOperationResult<TDto>> FindByIdAsync(Guid id);
        public Task<DataOperationResult<IEnumerable<TDto>>> FindAsync(Expression<Func<TDto, bool>> predicate);
        public Task<DataOperationResult<TDto>> AddAsync(TDto dto);
        public Task<DataOperationResult<TDto>> UpdateAsync(Guid id, TDto dto);
        public Task<bool> DeleteAsync(Guid id);
        public Task<bool> DeleteManyAsync(Expression<Func<TDto, bool>> predicate);
        public Task<bool> AnyAsync();
        public Task<int> CountAsync();
    }
}
