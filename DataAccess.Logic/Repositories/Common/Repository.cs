using AutoMapper;
using DataAccess.DTO;
using DataAccess.DTO.CommunicationObjects;
using DataAccess.Logic.Repositories.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Logic.Repositories.Common
{
    public abstract class Repository<TEntity, TDto> : IRepository<TDto>
        where TEntity : class
        where TDto : EntityDto
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

        public async Task<DataOperationResult<TDto>> AddAsync(TDto dto, CancellationToken ct)
        {
            var entity = _mapper.Map<TEntity>(dto);
            await _dbSet.AddAsync(entity, ct);

            return await _dbContext.SaveChangesAsync(ct) > 0
                ? DataOperationResponseHelper.CreateResponse(_mapper.Map<TDto>(entity))
                : DataOperationResponseHelper.CreateResponse<TDto>();
        }

        public async Task<bool> AnyAsync(CancellationToken ct)
        {
            return await _dbSet.AnyAsync(ct);
        }

        public async Task<int> CountAsync(CancellationToken ct)
        {
            return await _dbSet.CountAsync(ct);
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken ct)
        {
            var entity = await _dbSet.FindAsync(id, ct);

            if (entity is null)
                return false;

            _dbSet.Remove(entity);

            return await _dbContext.SaveChangesAsync(ct) > 0;
        }

        public async Task<bool> DeleteManyAsync(Expression<Func<TDto, bool>> predicate, CancellationToken ct)
        {
            var entityPredicate = _mapper.Map<Expression<Func<TEntity, bool>>>(predicate);
            IQueryable<TEntity> entities = _dbSet.Where(entityPredicate);

            if (!(await entities.AnyAsync(ct)))
                return false;

            _dbSet.RemoveRange(entities);

            return await _dbContext.SaveChangesAsync(ct) > 0;
        }

        public async Task<DataOperationResult<IEnumerable<TDto>>> FindAsync(Expression<Func<TDto, bool>> predicate, CancellationToken ct) 
        {
            var entityPredicate = _mapper.Map<Expression<Func<TEntity, bool>>>(predicate);
            IEnumerable<TEntity> entities = await _dbSet.Where(entityPredicate).ToListAsync(ct);

            return DataOperationResponseHelper.CreateResponse(_mapper.Map<IEnumerable<TDto>>(entities));
        }

        public async Task<DataOperationResult<IEnumerable<TDto>>> GetAllAsync(CancellationToken ct) 
            => DataOperationResponseHelper.CreateResponse(_mapper.Map<IEnumerable<TDto>>(await _dbSet.ToListAsync(ct)));

        public abstract Task<DataOperationResult<TDto>> FindByIdAsync(Guid id, CancellationToken ct);

        public abstract Task<DataOperationResult<bool>> UpdateAsync(Guid id, TDto entity, CancellationToken ct);
    }
}
