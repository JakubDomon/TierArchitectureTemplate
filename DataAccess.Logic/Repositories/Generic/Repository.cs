using AutoMapper;
using DataAccess.DTO;
using DataAccess.DTO.CommunicationObjects;
using DataAccess.Logic.Repositories.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Logic.Repositories.Generic
{
    public abstract class Repository<TEntity, TDto> : IRepository<TDto>
        where TEntity : class
        where TDto : BaseDto
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
                ? DataOperationResponseHelper.CreateResponse(_mapper.Map<TDto>(entity))
                : DataOperationResponseHelper.CreateResponse<TDto>();
        }

        public async Task<bool> AnyAsync()
        {
            return await _dbSet.AnyAsync();
        }

        public async Task<int> CountAsync()
        {
            return await _dbSet.CountAsync();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = _dbSet.Find(id);

            if (entity is null)
                return false;

            _dbSet.Remove(entity);

            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteManyAsync(Expression<Func<TDto, bool>> predicate)
        {
            var entityPredicate = _mapper.Map<Expression<Func<TEntity, bool>>>(predicate);
            IQueryable<TEntity> entities = _dbSet.Where(entityPredicate);

            if (!entities.Any())
                return false;

            _dbSet.RemoveRange(entities);

            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<DataOperationResult<IEnumerable<TDto>>> FindAsync(Expression<Func<TDto, bool>> predicate) 
        {
            var entityPredicate = _mapper.Map<Expression<Func<TEntity, bool>>>(predicate);
            IEnumerable<TEntity> entities = await _dbSet.Where(entityPredicate).ToListAsync();

            return DataOperationResponseHelper.CreateResponse(_mapper.Map<IEnumerable<TDto>>(entities));
        }

        public async Task<DataOperationResult<IEnumerable<TDto>>> GetAllAsync() 
            => DataOperationResponseHelper.CreateResponse(_mapper.Map<IEnumerable<TDto>>(await _dbSet.ToListAsync()));

        public abstract Task<DataOperationResult<TDto>> FindByIdAsync(Guid id);

        public abstract Task<DataOperationResult<TDto>> UpdateAsync(Guid id, TDto entity);
    }
}
