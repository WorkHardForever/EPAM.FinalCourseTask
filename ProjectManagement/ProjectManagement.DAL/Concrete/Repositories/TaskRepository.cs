using Microsoft.AspNet.Identity.EntityFramework;
using ProjectManagement.DAL.Interfacies.DTO;
using ProjectManagement.DAL.Interfacies.Interfacies.IRepositories;
using ProjectManagement.DAL.Mappers;
using ProjectManagement.ORM.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace ProjectManagement.DAL.Concrete.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IdentityDbContext<User> _context;

        public TaskRepository(IdentityDbContext<User> context)
        {
            _context = context;
        }

        public void Create(DalTask item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            _context.Set<Task>().Add(item.ToDbTask());
        }

        public void Delete(DalTask item)
        {
            var task = _context.Set<Task>().FirstOrDefault(u => u.Id == item.Id);
            if (task == null)
                throw new ArgumentException("Such id not found");

            _context.Set<Task>().Remove(task);
        }

        public IEnumerable<DalTask> GetAll()
        {
            return _context.Set<Task>().Select(task => task.ToDalTask());
        }

        public DalTask GetById(string uniqueId)
        {
            var task = _context.Set<Task>().FirstOrDefault(u => u.Id == uniqueId);
            if (task == null)
                throw new ArgumentNullException(nameof(uniqueId));

            return task.ToDalTask();
        }

        public DalTask GetByPredicate(Expression<Func<DalTask, bool>> match)
        {
            throw new NotImplementedException();
        }

        public void Update(DalTask item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            Update(item.ToDbTask());
        }

        public void AddToEmployeeTasks(DalPerson person, DalTask task)
        {
            //person.
            //Update(item.ToDbPerson());
            throw new NotImplementedException();
        }

        public void AddToManagerTasks(DalPerson person, DalTask task)
        {
            throw new NotImplementedException();
        }

        private void Update(Task item)
        {
            _context.Set<Task>().AddOrUpdate(item);
        }
    }
}
