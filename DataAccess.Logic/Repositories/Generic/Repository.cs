using AutoMapper;
using DataAccess.DTO;
using DataAccess.DTO.CommunicationObjects;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Logic.Repositories.Generic
{
    public abstract class Repository<TEntity, TDto> : RepositoryBase, IRepository<TEntity, TDto>
        where TEntity : class
        where TDto : BaseDTO
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;
        private readonly IMapper _mapper;

        internal Repository(DbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dbSet = dbContext.Set<TEntity>();
            _mapper = mapper;
        }

        public async Task<DataOperationResult<TDto>> AddAsync(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            await _dbSet.AddAsync(entity);

            return await _dbContext.SaveChangesAsync() > 0
                ? CreateSuccessResponse(_mapper.Map<TDto>(entity))
                : CreateErrorResponse<TDto>();
        }

        public async Task<bool> AnyAsync()
        {
            return await _dbSet.AnyAsync();
        }

        public async Task<int> CountAsync()
        {
            return await _dbSet.CountAsync();
        }

        public bool Delete(Guid id)
        {
            var entity = _dbSet.Find(id);

            if (entity == null)
                return false;

            _dbSet.Remove(entity);

            return _dbContext.SaveChanges() > 0;
        }

        public bool DeleteMany(Expression<Func<TDto, bool>> predicate)
        {
            var entityPredicate = _mapper.Map<Expression<Func<TEntity, bool>>>(predicate);
            var entities = _dbSet.Where(entityPredicate);

            if (!entities.Any())
                return false;

            _dbSet.RemoveRange(entities.ToList());

            return _dbContext.SaveChanges() > 0;
        }

        public async Task<DataOperationResult<IEnumerable<TDto>>> FindAsync(Expression<Func<TDto, bool>> predicate, FindOptions? findOptions = null)
        {
            var entityPredicate = _mapper.Map<Expression<Func<TEntity, bool>>>(predicate);
            var entities = await _dbSet.Where(entityPredicate).ToListAsync();

            if (!entities.Any())
                return CreateErrorResponse<IEnumerable<TDto>>();

            return CreateSuccessResponse(_mapper.Map<IEnumerable<TDto>>(entities));
        }

        public async Task<DataOperationResult<TDto>> FindOneAsync(Expression<Func<TDto, bool>> predicate, FindOptions? findOptions = null)
        {
            throw new NotImplementedException();
        }

        public Task<DataOperationResult<IEnumerable<TDto>>> GetAllAsync(FindOptions? findOptions = null)
        {
            throw new NotImplementedException();
        }

        public Task<DataOperationResult<TDto>> UpdateAsync(TDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
