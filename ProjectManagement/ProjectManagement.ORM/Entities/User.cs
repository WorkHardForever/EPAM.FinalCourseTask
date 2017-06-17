using Microsoft.AspNet.Identity.EntityFramework;

namespace ProjectManagement.ORM.Entities
{
    public class User : IdentityUser
    {
        public Person WorkAccount { get; set; }
    }
}
