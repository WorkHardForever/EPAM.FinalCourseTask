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
    public class PersonRepository : IPersonRepository
    {
        private readonly IdentityDbContext<User> _context;

        public PersonRepository(IdentityDbContext<User> context)
        {
            _context = context;
        }

        public void Create(DalPerson item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            _context.Set<Person>().Add(item.ToDbPerson());
        }

        public void Delete(DalPerson item)
        {
            var person = _context.Set<Person>().FirstOrDefault(u => u.Id == item.Id);
            if (person == null)
                throw new ArgumentException("Such id not found");

            _context.Set<Person>().Remove(person);
        }

        public IEnumerable<DalPerson> GetAll()
        {
            return _context.Set<Person>().Select(person => person.ToDalPerson());
        }

        public DalPerson GetById(string uniqueId)
        {
            var person = _context.Set<Person>().FirstOrDefault(u => u.Id == uniqueId);
            if (person == null)
                throw new ArgumentNullException(nameof(uniqueId));

            return person.ToDalPerson();
        }

        public DalPerson GetByPredicate(Expression<Func<DalPerson, bool>> match)
        {
            throw new NotImplementedException();
        }

        public void Update(DalPerson item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            Update(item.ToDbPerson());
        }

        public DalTaskPercentState GetStateOfReceivedTasks(DalPerson person)
        {
            var toDo = 0;
            var InProcess = 0;
            var Done = 0;
            foreach (var item in person.ReceivedTasks)
            {
                switch (item.State)
                {
                    case DalTaskState.ToDo:
                        toDo++;
                        break;
                    case DalTaskState.InProcess:
                        InProcess++;
                        break;
                    case DalTaskState.Done:
                        Done++;
                        break;
                    default:
                        break;
                }
            }

            var count = person.ReceivedTasks.Count();
            var taskPercentState = new DalTaskPercentState()
            {
                ToDo = GetPercent(toDo, count),
                InProcess = GetPercent(InProcess, count),
                Done = GetPercent(Done, count)
            };

            return taskPercentState;
        }

        private int GetPercent(int part, int total)
        {
            if (part < total && total > 0)
                return part / total * 100;
            else
                throw new ArgumentException("Check arguments that part < total and total > 0");
        }

        private void Update(Person item)
        {
            _context.Set<Person>().AddOrUpdate(item);
        }
    }
}
