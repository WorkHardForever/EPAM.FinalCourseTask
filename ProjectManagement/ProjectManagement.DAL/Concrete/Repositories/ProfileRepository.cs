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

            var profile = _context.Set<Profile>().SingleOrDefault(u => u.Id == item.Id);
            if (profile == null)
                throw new ArgumentException("Such id not found");

            _context.Set<Profile>().Remove(profile);
        }

        public DalProfile GetById(int uniqueId)
        {
            var profile = _context.Set<Profile>().SingleOrDefault(u => u.Id == uniqueId);
            if (profile == null)
                throw new ArgumentNullException(nameof(uniqueId));

            return profile.ToDalProfile();
        }

        public IEnumerable<DalProfile> GetAll()
        {
            return _context.Set<Profile>().Select(profile => profile.ToDalProfile());
        }

        public DalProfile GetByPredicate(Expression<Func<DalProfile, bool>> match)
        {
            throw new NotImplementedException();
        }

        public DalProfile GetByEmail(string email)
        {
            var profile = _context.Set<Profile>().SingleOrDefault(u => u.Email == email);
            if (profile == null)
                throw new ArgumentNullException(nameof(email));

            return profile.ToDalProfile();
        }
    }
}
