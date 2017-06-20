using Microsoft.AspNet.Identity.EntityFramework;
using ProjectManagement.DAL.Interface.Interfacies;

namespace ProjectManagement.DAL.Interface.DTO
{
    public class DalUser : IdentityUser, IEntity
    {
        public DalProfile Profile { get; set; }
    }
}
