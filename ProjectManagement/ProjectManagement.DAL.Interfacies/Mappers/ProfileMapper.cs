using ProjectManagement.DAL.Interface.DTO;
using ProjectManagement.ORM.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManagement.DAL.Interface.Mappers
{
    public static class DbProfileMapper
    {
        public static DalProfile ToDalProfile(this Profile dbProfile)
        {
            return new DalProfile()
            {
                Id = dbProfile.Id,
                Name = dbProfile.Name,
                Surname = dbProfile.Surname,
                GivenTasks = dbProfile.GivenTasks?.ToDalTaskEnumerable(),
                ReceivedTasks = dbProfile.ReceivedTasks?.ToDalTaskEnumerable()
            };
        }

        public static Profile ToDbProfile(this DalProfile dalProfile)
        {
            return new Profile()
            {
                Id = dalProfile.Id,
                Name = dalProfile.Name,
                Surname = dalProfile.Surname,
                GivenTasks = dalProfile.GivenTasks?.ToDbTaskCollection(),
                ReceivedTasks = dalProfile.ReceivedTasks?.ToDbTaskCollection()
            };
        }

        public static IEnumerable<DalProfile> ToDalProfileEnumerable(this ICollection<Profile> dbProfiles)
        {
            return dbProfiles?.Select(x => x.ToDalProfile());
        }

        public static ICollection<Profile> ToDbProfileCollection(this IEnumerable<DalProfile> dalProfiles)
        {
            return dalProfiles?.Select(x => x.ToDbProfile()) as ICollection<Profile>;
        }
    }
}
