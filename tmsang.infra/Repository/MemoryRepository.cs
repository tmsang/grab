using System;
using System.Collections.Generic;
using System.Linq;
using tmsang.domain;

namespace tmsang.infra
{
    public class MemoryRepository<T> : IRepository<T> where T : class, IAggregateRoot
    {
        private readonly IUnitOfWork _unitOfWork;
        protected static List<T> entities = new List<T>();

        public MemoryRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Include(string property) { 
            // TODO: no implement
        }

        public void Add(T entity)
        {
            entities.Add(entity);
            _unitOfWork.SaveChanges();
        }

        public IQueryable<T> All()
        {
            throw new Exception("Have not implemented");
        }
        public IQueryable<T> All(string navigationProperty)
        {
            throw new Exception("Have not implemented");
        }

        public IEnumerable<T> Find(ISpecification<T> spec)
        {
            return entities.Where(spec.IsSatisfiedBy);
        }
        public IEnumerable<T> Find(ISpecification<T> spec, string navigationProperty)
        {
            // TODO: navigationProperty...
            return entities.Where(spec.IsSatisfiedBy);
        }

        public T FindById(Guid id)
        {
            return entities.Where(p => (Guid)p.Id == id).FirstOrDefault();
        }
        public T FindById(Guid id, string navigationProperty)
        {
            return entities.Where(p => (Guid)p.Id == id).FirstOrDefault();
        }

        public T FindOne(ISpecification<T> spec)
        {
            return entities.Where(spec.IsSatisfiedBy).FirstOrDefault();
        }
        public T FindOne(ISpecification<T> spec, string navigationProperty)
        {
            return entities.Where(spec.IsSatisfiedBy).FirstOrDefault();
        }

        public void Remove(T entity)
        {
            entities.Remove(entity);
            _unitOfWork.SaveChanges();
        }

        public void Update(T entity)
        {
            // TODO ....
        }
    }
}
