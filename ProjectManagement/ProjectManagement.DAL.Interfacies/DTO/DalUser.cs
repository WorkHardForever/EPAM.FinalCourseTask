using ProjectManagement.DAL.Interfacies.Interfacies;

namespace ProjectManagement.DAL.Interfacies.DTO
{
    public class DalUser : IEntity
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }
    }
}
