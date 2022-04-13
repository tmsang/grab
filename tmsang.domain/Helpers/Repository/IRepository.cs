using System;
using System.Collections.Generic;
using System.Linq;

namespace tmsang.domain
{
    public interface IRepository<TEntity> where TEntity: IAggregateRoot
    {
        IQueryable<TEntity> All();
        IQueryable<TEntity> All(string navigationProperty);

        TEntity FindById(Guid id);      // only AggregateRoot able to Use (for Branch should use Root)               
        TEntity FindById(Guid id, string navigationProperty);

        TEntity FindOne(ISpecification<TEntity> spec);
        TEntity FindOne(ISpecification<TEntity> spec, string navigationProperty);

        IEnumerable<TEntity> Find(ISpecification<TEntity> spec);
        IEnumerable<TEntity> Find(ISpecification<TEntity> spec, string navigationProperty);

        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);        
    }
}
