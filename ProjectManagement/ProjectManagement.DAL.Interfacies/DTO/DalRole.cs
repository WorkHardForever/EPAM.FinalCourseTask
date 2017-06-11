using ProjectManagement.DAL.Interfacies.Interfacies;

namespace ProjectManagement.DAL.Interfacies.DTO
{
    public class DalRole : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
