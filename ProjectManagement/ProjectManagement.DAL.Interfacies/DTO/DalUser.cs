using Microsoft.AspNet.Identity.EntityFramework;

namespace ProjectManagement.DAL.Interfacies.DTO
{
    public class DalUser : IdentityUser
    {
        public DalPerson WorkAccount { get; set; }
    }
}
