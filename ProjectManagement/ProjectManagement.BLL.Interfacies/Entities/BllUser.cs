using Microsoft.AspNet.Identity.EntityFramework;

namespace ProjectManagement.BLL.Interface.Entities
{
    public class BllUser : IdentityUser
    {
        public BllProfile Profile { get; set; }
    }
}
