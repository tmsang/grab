using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace tmsang.domain
{
    public interface IRepository<TEntity> where TEntity: IAggregateRoot
    {
        TEntity FindById(Guid id);      // only AggregateRoot able to Use (for Branch should use Root)               
        TEntity FindOne(ISpecification<TEntity> spec);
        IEnumerable<TEntity> Find(ISpecification<TEntity> spec);
        IEnumerable<TEntity> Find(ISpecification<TEntity> spec, string navigationProperty);

        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);                
    }
}
