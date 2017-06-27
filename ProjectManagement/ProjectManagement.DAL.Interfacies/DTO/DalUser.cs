using ProjectManagement.DAL.Interface.Interfacies;
using System.Collections.Generic;

namespace ProjectManagement.DAL.Interface.DTO
{
    public class DalUser : IEntity
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string PasswordHash { get; set; }

        public DalProfile Profile { get; set; }

        public IEnumerable<DalRole> Roles { get; set; }
    }
}