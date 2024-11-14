using DataAccessLayer.DTO.Common.GenericRepositories;
using DataAccessLayer.DTO.CommunicationObjects;
using DataAccessLayer.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories
{
    public class Repository<TEntity> : RepositoryBase, IRepository<TEntity>
        where TEntity : IGenericRepositoryModel
    {
        private readonly DbContext _dbContext;

        internal Repository() { }

        public Task<DataOperationResult<TEntity>> Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Any()
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public Task<DataOperationResult<TEntity?>> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<DataOperationResult<TEntity?>> DeleteMany(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<DataOperationResult<IQueryable<TEntity>>> Find(Expression<Func<TEntity, bool>> predicate, FindOptions? findOptions = null)
        {
            throw new NotImplementedException();
        }

        public Task<DataOperationResult<TEntity>> FindOne(Expression<Func<TEntity, bool>> predicate, FindOptions? findOptions = null)
        {
            throw new NotImplementedException();
        }

        public Task<DataOperationResult<IQueryable<TEntity>>> GetAll(FindOptions? findOptions = null)
        {
            throw new NotImplementedException();
        }

        public Task<DataOperationResult<TEntity>> Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
