using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectManagement.ORM.Entities
{
    public class User : IdentityUser
    {
        public Person WorkAccount { get; set; }
    }
}
