using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MicCRM.Domain.Entities
{
    public class Entity
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool Deleted { get; set; }
    }
}
