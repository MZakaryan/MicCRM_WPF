using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MicCRM.Domain.Entities
{
    public class Teacher : Entity
    {
        public Teacher()
        {
            Lessons = new List<Lesson>();
        }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }

        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}
