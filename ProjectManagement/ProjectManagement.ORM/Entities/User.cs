using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.ORM.Entities
{
    public class User : IdentityUser
    {
        public Profile Profile { get; set; }
    }
}
