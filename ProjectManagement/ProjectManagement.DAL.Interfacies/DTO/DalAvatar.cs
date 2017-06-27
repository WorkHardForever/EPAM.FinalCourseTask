using ProjectManagement.DAL.Interface.Interfacies;

namespace ProjectManagement.DAL.Interface.DTO
{
    public class DalAvatar : IEntity
    {
        public int Id { get; set; }

        public byte[] Image { get; set; }
    }
}