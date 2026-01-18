using ESCommerce.Domain.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESCommerce.Domain.Core.Data
{
    public interface IRepository<TEntity, TId> where TEntity : IAggregateRoot
    {
        public Task Create(TEntity entity);

        public Task Update(TEntity entity);

        public Task Delete(TEntity entity);

        public Task<TEntity> GetById(TId id);
        public Task<IEnumerable<TEntity>> GetAll();
    }
}
