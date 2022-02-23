using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace tmsang.domain
{
    public interface IRepositoryNonRoot<T> where T: class
    {
        T FindById(Guid id);      // non-root is hust readonly

        T FindOne(ISpecification<T> spec);
        IEnumerable<T> Find(ISpecification<T> spec);
        void Include(string property);
    }
}
