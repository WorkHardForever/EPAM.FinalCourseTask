using System.Collections.Generic;

namespace ProjectManagement.ORM.Entities
{
    public class Firm
    {
        public Firm()
        {
            People = new HashSet<Profile>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Profile> People { get; set; }
    }
}
