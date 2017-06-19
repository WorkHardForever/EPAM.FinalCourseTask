using System;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace ProjectManagement.DAL.Interfacies.Interfacies
{
    public interface IRepository<T>
        where T : IEntity
    {
        IEnumerable<T> GetAll();
        T GetById(string uniqueId);
        T GetByPredicate(Expression<Func<T, bool>> match);
        void Create(T item);
        void Delete(T item);
        void Update(T item);
    }
}
