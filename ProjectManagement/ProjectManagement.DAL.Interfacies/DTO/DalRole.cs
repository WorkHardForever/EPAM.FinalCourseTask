using ProjectManagement.DAL.Interface.Interfacies;
using System.Collections.Generic;

namespace ProjectManagement.DAL.Interface.DTO
{
    public class DalRole : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<DalUser> RoleUsers { get; set; }
    }
}
