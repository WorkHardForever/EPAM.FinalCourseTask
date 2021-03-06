﻿using ProjectManagement.DAL.Interface.DTO;
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
    public class ProfileRepository : IProfileRepository
    {
        private readonly DbContext _context;

        public ProfileRepository(DbContext context)
        {
            _context = context;
        }

        public void Create(DalProfile item)
        {
            _context.Set<Profile>().Add(item.ToDbProfile());
        }

        public void Update(DalProfile item)
        {
            _context.Set<Profile>().AddOrUpdate(item.ToDbProfile());
        }

        public void Delete(DalProfile item)
        {
            var profile = _context.Set<Profile>().SingleOrDefault(u => u.Id == item.Id);
            if (profile == null)
                throw new ArgumentException("Such profile id was not found");

            _context.Set<Profile>().Remove(profile);
        }

        public DalProfile GetById(int uniqueId)
        {
            var profile = _context.Set<Profile>().SingleOrDefault(u => u.Id == uniqueId);
            if (profile == null)
                return null;

            return profile.ToDalProfile();
        }

        public IEnumerable<DalProfile> GetAll()
        {
            throw new NotImplementedException();
        }

        public DalProfile GetByEmail(string email)
        {
            var profile = _context.Set<Profile>().SingleOrDefault(u => u.Email == email);
            if (profile == null)
                return null;

            return profile.ToDalProfile();
        }

        public IEnumerable<DalTask> GetAllGivenTasks(DalProfile dalProfile)
        {
            return _context.Set<Profile>().SingleOrDefault(x => x.Email == dalProfile.Email)
                .GivenTasks.ToDalTaskEnumerable();
        }

        public IEnumerable<DalTask> GetAllReceivedTasks(DalProfile dalProfile)
        {
            return _context.Set<Profile>().SingleOrDefault(x => x.Email == dalProfile.Email)
                .ReceivedTasks.ToDalTaskEnumerable();
        }
    }
}