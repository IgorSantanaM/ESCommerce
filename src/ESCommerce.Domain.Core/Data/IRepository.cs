using ESCommerce.Domain.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESCommerce.Domain.Core.Data
{
    public interface IRepository<TEntity, TId> where TEntity : IAggregateRoot
    {
        public Task CreateAsync(TEntity entity);

        public Task UpdateAsync(TEntity entity);

        public Task DeleteAsync(TEntity entity);

        public Task<TEntity> GetByIdAsync(TId id);
        public Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
