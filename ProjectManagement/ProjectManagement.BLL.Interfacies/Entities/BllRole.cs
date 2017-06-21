using System.Collections.Generic;

namespace ProjectManagement.BLL.Interface.Entities
{
    public class BllRole
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<BllUser> RoleUsers { get; set; }
    }
}
