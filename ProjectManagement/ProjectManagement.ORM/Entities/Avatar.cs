using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagement.ORM.Entities
{
    public class Avatar
    {
        [Key]
        [ForeignKey("Profile")]
        public int Id { get; set; }

        public byte[] Image { get; set; }
    }
}