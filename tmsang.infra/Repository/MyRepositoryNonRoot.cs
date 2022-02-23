using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using tmsang.domain;

namespace tmsang.infra
{
    public class MyRepositoryNonRoot<T> : IRepositoryNonRoot<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private DbSet<T> table = null;

        public MyRepositoryNonRoot()
        {

        }
        public MyRepositoryNonRoot(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            table = _unitOfWork.Set<T>();
        }

        public void Include(string property)
        {
            table.Include(property);
        }

        public IEnumerable<T> Find(ISpecification<T> spec)
        {
            return table.Where(spec.SpecExpression);
        }

        public T FindById(Guid id)
        {
            return table.Find(id);
        }

        public T FindById(int id)
        {
            return table.Find(id);
        }

        public T FindOne(ISpecification<T> spec)
        {
            return table.Where(spec.SpecExpression).FirstOrDefault();
        }
    }
}
