﻿using DataAccessLayer.DTO;
using DataAccessLayer.DTO.CommunicationObjects;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories.Common
{
    public interface IRepository<TEntity, TDto>
        where TEntity : class
        where TDto : BaseDTO
    {
        public Task<DataOperationResult<IEnumerable<TDto>>> GetAllAsync(FindOptions? findOptions = null);
        public Task<DataOperationResult<TDto>> FindOneAsync(Expression<Func<TDto, bool>> predicate, FindOptions? findOptions = null);
        public Task<DataOperationResult<IEnumerable<TDto>>> FindAsync(Expression<Func<TDto, bool>> predicate, FindOptions? findOptions = null);
        public Task<DataOperationResult<TDto>> AddAsync(TDto dto);
        public Task<DataOperationResult<TDto>> UpdateAsync(TDto dto);
        public bool Delete(Guid id);
        public bool DeleteMany(Expression<Func<TDto, bool>> predicate);
        public Task<bool> AnyAsync();
        public Task<int> CountAsync();
    }
}