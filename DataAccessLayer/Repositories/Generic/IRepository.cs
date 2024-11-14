using DataAccessLayer.DTO.Common.GenericRepositories;
using DataAccessLayer.DTO.CommunicationObjects;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories.Common
{
    public interface IRepository<TEntity>
        where TEntity : IGenericRepositoryModel
    {
        Task<DataOperationResult<IQueryable<TEntity>>> GetAll(FindOptions? findOptions = null);
        Task<DataOperationResult<TEntity>> FindOne(Expression<Func<TEntity, bool>> predicate, FindOptions? findOptions = null);
        Task<DataOperationResult<IQueryable<TEntity>>> Find(Expression<Func<TEntity, bool>> predicate, FindOptions? findOptions = null);
        Task<DataOperationResult<TEntity>> Add(TEntity entity);
        Task<DataOperationResult<TEntity>> Update(TEntity entity);
        Task<DataOperationResult<TEntity?>> Delete(Guid id);
        Task<DataOperationResult<TEntity?>> DeleteMany(Expression<Func<TEntity, bool>> predicate);
        bool Any();
        int Count();
    }
}
