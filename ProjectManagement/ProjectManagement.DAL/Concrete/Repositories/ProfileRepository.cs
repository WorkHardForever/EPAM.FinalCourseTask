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
    public class ProfileRepository : IProfileRepository
    {
        private readonly DbContext _context;

        public ProfileRepository(DbContext context)
        {
            _context = context;
        }

        public void Create(DalProfile item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            _context.Set<Profile>().Add(item.ToDbProfile());
        }

        public void Update(DalProfile item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            _context.Set<Profile>().AddOrUpdate(item.ToDbProfile());
        }

        public void Delete(DalProfile item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            var task = _context.Set<Profile>().SingleOrDefault(u => u.Id == item.Id);
            if (task == null)
                throw new ArgumentException("Such id not found");

            _context.Set<Profile>().Remove(task);
        }

        public DalProfile GetById(int uniqueId)
        {
            var task = _context.Set<Profile>().SingleOrDefault(u => u.Id == uniqueId);
            if (task == null)
                throw new ArgumentNullException(nameof(uniqueId));

            return task.ToDalProfile();
        }

        public IEnumerable<DalProfile> GetAll()
        {
            return _context.Set<Profile>().Select(task => task.ToDalProfile());
        }

        public DalProfile GetByPredicate(Expression<Func<DalProfile, bool>> match)
        {
            throw new NotImplementedException();
        }

        //public DalProfile GetGivenTasks(int managerId)
        //{
        //    var manager = _context.Set<Profile>().SingleOrDefault(u => u.Id == managerId);
        //    if (manager == null)
        //        throw new ArgumentNullException(nameof(managerId));

        //    _context.Entry(manager).Collection(x => x.GivenTasks).Load();
        //    return manager.ToDalProfile();
        //}
    }
}
