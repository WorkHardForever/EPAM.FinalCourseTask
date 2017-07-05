using ProjectManagement.DAL.Interface.DTO;
using ProjectManagement.DAL.Interface.Interfacies.IRepositories;
using ProjectManagement.DAL.Mappers;
using ProjectManagement.ORM.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

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

            var task = new Task()
            {
                Title = item.Title,
                Description = item.Description,
                State = (TaskState) item.State,
                DeadLine = item.DeadLine,
                StartTime = item.StartTime
            };
            var manager = _context.Set<Profile>().FirstOrDefault(x => x.Email == item.Manager.Email);
            var employee = _context.Set<Profile>().FirstOrDefault(x => x.Email == item.Employee.Email);

            manager.GivenTasks.Add(task);
            employee.ReceivedTasks.Add(task);
        }

        public void Update(DalTask item)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalTask item)
        {
            var task = _context.Set<Task>().SingleOrDefault(u => u.Id == item.Id);
            if (task == null)
                throw new ArgumentException("Such id was not found");

            _context.Set<Task>().Remove(task);
        }

        public DalTask GetById(int uniqueId)
        {
            var task = _context.Set<Task>().SingleOrDefault(u => u.Id == uniqueId);
            if (task == null)
                return null;

            return task.ToDalTask();
        }

        public IEnumerable<DalTask> GetAll()
        {
            throw new NotImplementedException();
        }

        public void ChangeStatus(int taskId)
        {
            var task = _context.Set<Task>().SingleOrDefault(u => u.Id == taskId);
            if (task == null)
                throw new ArgumentException($"Task with id: {taskId} can't be found.");

            if (task.State == TaskState.Done)
                throw new ArgumentException($"Task already have State = 'Done' and you can't improve it more.");

            task.State++;
            _context.Set<Task>().AddOrUpdate(task);
        }
    }
}
