﻿using System.Collections.Generic;

namespace ProjectManagement.ORM.Entities
{
    public class Role
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<User> RoleUsers { get; set; }
    }
}
