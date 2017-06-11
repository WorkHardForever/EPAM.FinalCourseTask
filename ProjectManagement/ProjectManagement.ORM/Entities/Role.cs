using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.ORM.Entities
{
    public partial class Role
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
