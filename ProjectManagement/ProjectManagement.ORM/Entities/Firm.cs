using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.ORM.Entities
{
    public class Firm
    {
        public string Id { get; set; }

        [Required]
        [MaxLength(length: 20, ErrorMessage = "Name length more then 20 symbols")]
        public string Name { get; set; }
        
        public virtual ICollection<Profile> People { get; set; }
    }
}
