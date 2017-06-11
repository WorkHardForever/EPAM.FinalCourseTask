using ProjectManagement.DAL.Interfacies.DTO;
using ProjectManagement.DAL.Interfacies.Interfacies.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ProjectManagement.DAL.Concrete.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        public void Create(DalTask item)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalTask item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalTask> GetAll()
        {
            throw new NotImplementedException();
        }

        public DalTask GetById(int uniqueId)
        {
            throw new NotImplementedException();
        }

        public DalTask GetByPredicate(Expression<Func<DalTask, bool>> match)
        {
            throw new NotImplementedException();
        }

        public void Update(DalTask item)
        {
            throw new NotImplementedException();
        }
    }
}
