using System.Collections.Generic;

namespace ProjectManagement.DAL.Interface.Interfacies
{
    public interface IRepository<T>
        where T : IEntity
    {
        IEnumerable<T> GetAll();

        T GetById(int uniqueId);

        void Create(T item);

        void Delete(T item);

        void Update(T item);
    }
}
