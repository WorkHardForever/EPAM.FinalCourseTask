using Microsoft.AspNet.Identity.EntityFramework;
using ProjectManagement.DAL.Interface.DTO;
using ProjectManagement.DAL.Interface.Interfacies.IRepositories;
using ProjectManagement.DAL.Interface.Mappers;
using ProjectManagement.ORM.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace ProjectManagement.DAL.Concrete.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly IdentityDbContext<User> _context;

        public ProfileRepository(IdentityDbContext<User> context)
        {
            _context = context;
        }

        public void Create(DalProfile item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            _context.Set<Profile>().Add(item.ToDbProfile());
        }

        public void Delete(DalProfile item)
        {
            var profile = _context.Set<Profile>().FirstOrDefault(u => u.Id == item.Id);
            if (profile == null)
                throw new ArgumentException("Such id not found");

            _context.Set<Profile>().Remove(profile);
        }

        public IEnumerable<DalProfile> GetAll()
        {
            return _context.Set<Profile>().Select(profile => profile.ToDalProfile());
        }

        public DalProfile GetById(string uniqueId)
        {
            var profile = _context.Set<Profile>().FirstOrDefault(u => u.Id == uniqueId);
            if (profile == null)
                throw new ArgumentNullException(nameof(uniqueId));

            return profile.ToDalProfile();
        }

        public DalProfile GetByPredicate(Expression<Func<DalProfile, bool>> match)
        {
            throw new NotImplementedException();
        }

        public void Update(DalProfile item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            Update(item.ToDbProfile());
        }

        //public DalTaskPercentState GetStateOfReceivedTasks(DalProfile profile)
        //{
        //    var toDo = 0;
        //    var InProcess = 0;
        //    var Done = 0;
        //    foreach (var item in profile.ReceivedTasks)
        //    {
        //        switch (item.State)
        //        {
        //            case DalTaskState.ToDo:
        //                toDo++;
        //                break;
        //            case DalTaskState.InProcess:
        //                InProcess++;
        //                break;
        //            case DalTaskState.Done:
        //                Done++;
        //                break;
        //            default:
        //                break;
        //        }
        //    }

        //    var count = profile.ReceivedTasks.Count();
        //    var taskPercentState = new DalTaskPercentState()
        //    {
        //        ToDo = GetPercent(toDo, count),
        //        InProcess = GetPercent(InProcess, count),
        //        Done = GetPercent(Done, count)
        //    };

        //    return taskPercentState;
        //}

        private int GetPercent(int part, int total)
        {
            if (part < total && total > 0)
                return part / total * 100;
            else
                throw new ArgumentException("Check arguments that part < total and total > 0");
        }

        private void Update(Profile item)
        {
            _context.Set<Profile>().AddOrUpdate(item);
        }
    }
}
