using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagement.ORM.Entities
{
    public class User : IdentityUser
    {
        public Profile Profile { get; set; }

        [ForeignKey("Profile")]
        public string ProfileId { get; set; }
    }
}
