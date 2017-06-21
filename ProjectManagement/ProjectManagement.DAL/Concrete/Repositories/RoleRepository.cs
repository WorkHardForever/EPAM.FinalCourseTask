using ProjectManagement.DAL.Interface.DTO;
using ProjectManagement.DAL.Interface.Interfacies.IRepositories;
using ProjectManagement.DAL.Interface.Mappers;
using ProjectManagement.ORM.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace ProjectManagement.DAL.Concrete.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DbContext _context;

        public RoleRepository(DbContext context)
        {
            _context = context;
        }

        public void Create(DalRole item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            _context.Set<Role>().Add(item.ToDbRole());
        }

        public void Update(DalRole item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            _context.Set<Role>().AddOrUpdate(item.ToDbRole());
        }

        public void Delete(DalRole item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            var task = _context.Set<Role>().SingleOrDefault(u => u.Id == item.Id);
            if (task == null)
                throw new ArgumentException("Such id not found");

            _context.Set<Role>().Remove(task);
        }

        public DalRole GetById(int uniqueId)
        {
            var task = _context.Set<Role>().SingleOrDefault(u => u.Id == uniqueId);
            if (task == null)
                throw new ArgumentNullException(nameof(uniqueId));

            return task.ToDalRole();
        }

        public IEnumerable<DalRole> GetAll()
        {
            return _context.Set<Role>().Select(task => task.ToDalRole());
        }

        public DalRole GetByPredicate(Expression<Func<DalRole, bool>> match)
        {
            throw new NotImplementedException();
        }
    }
}
