using ProjectManagement.BLL.Interface.Entities;
using ProjectManagement.DAL.Interface.DTO;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManagement.BLL.Interface.Mappers
{
    public static class ProfileMapper
    {
        public static BllProfile ToBllProfile(this DalProfile dalRole)
        {
            return new BllProfile()
            {
                Id = dalRole.Id,
                Name = dalRole.Name,
                Surname = dalRole.Surname,
                Email = dalRole.Email,
                GivenTasks = dalRole.GivenTasks?.ToBllTaskEnumerable(),
                ReceivedTasks = dalRole.ReceivedTasks?.ToBllTaskEnumerable()
            };
        }

        public static DalProfile ToDalProfile(this BllProfile bllRole)
        {
            return new DalProfile()
            {
                Id = bllRole.Id,
                Name = bllRole.Name,
                Surname = bllRole.Surname,
                Email = bllRole.Email,
                GivenTasks = bllRole.GivenTasks?.ToDalTaskEnumerable(),
                ReceivedTasks = bllRole.ReceivedTasks?.ToDalTaskEnumerable()
            };
        }

        public static IEnumerable<BllProfile> ToBllProfileEnumerable(this IEnumerable<DalProfile> dalProfiles)
        {
            return dalProfiles?.Select(x => x.ToBllProfile());
        }

        public static IEnumerable<DalProfile> ToDalProfileEnumerable(this IEnumerable<BllProfile> bllProfiles)
        {
            return bllProfiles?.Select(x => x.ToDalProfile());
        }
    }
}
