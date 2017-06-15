using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProjectManagement.ORM.Entities;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectManagement.DAL.Interfacies.DTO
{
    public class DalUser : IdentityUser
    {
        public DalPerson WorkAccount { get; set; }
    }
}
