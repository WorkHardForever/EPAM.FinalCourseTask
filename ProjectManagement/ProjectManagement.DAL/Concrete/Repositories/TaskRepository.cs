using ProjectManagement.DAL.Interface.DTO;
using ProjectManagement.DAL.Interface.Interfacies.IRepositories;
using ProjectManagement.DAL.Mappers;
using ProjectManagement.ORM.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace ProjectManagement.DAL.Concrete.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DbContext _context;

        public TaskRepository(DbContext context)
        {
            _context = context;
        }

        public void Create(DalTask item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            var task = new Task() { Title = item.Title, Description = item.Description, State = (TaskState)item.State, DeadLine = item.DeadLine, StartTime = item.StartTime };
            var manager = _context.Set<Profile>().FirstOrDefault(x => x.Email == item.Manager.Email);
            var employee = _context.Set<Profile>().FirstOrDefault(x => x.Email == item.Employee.Email);

            manager.GivenTasks.Add(task);
            employee.ReceivedTasks.Add(task);
        }

        public void Update(DalTask item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            _context.Set<Task>().AddOrUpdate(item.ToDbTask());
        }

        public void Delete(DalTask item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            var task = _context.Set<Task>().SingleOrDefault(u => u.Id == item.Id);
            if (task == null)
                throw new ArgumentException("Such id not found");

            _context.Set<Task>().Remove(task);
        }

        public DalTask GetById(int uniqueId)
        {
            var task = _context.Set<Task>().SingleOrDefault(u => u.Id == uniqueId);
            if (task == null)
                throw new ArgumentNullException(nameof(uniqueId));

            return task.ToDalTask();
        }

        public IEnumerable<DalTask> GetAll()
        {
            return _context.Set<Task>().Select(task => task.ToDalTask());
        }

        public DalTask GetByPredicate(Expression<Func<DalTask, bool>> match)
        {
            throw new NotImplementedException();
        }
    }
}
