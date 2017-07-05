using System.Collections.Generic;

namespace ProjectManagement.BLL.Interface.Entities
{
    public class BllUser
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string PasswordHash { get; set; }

        public BllProfile Profile { get; set; }

        public IEnumerable<BllRole> Roles { get; set; }
    }
}
