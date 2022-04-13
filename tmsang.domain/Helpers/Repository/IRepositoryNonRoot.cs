using System;
using System.Collections.Generic;

namespace tmsang.domain
{
    public interface IRepositoryNonRoot<T> where T: class
    {
        T FindById(Guid id);      // non-root is hust readonly

        T FindOne(ISpecification<T> spec);
        T FindOne(ISpecification<T> spec, string navigationProperty);

        IEnumerable<T> Find(ISpecification<T> spec);
        IEnumerable<T> Find(ISpecification<T> spec, string navigationProperty);
        
    }
}
