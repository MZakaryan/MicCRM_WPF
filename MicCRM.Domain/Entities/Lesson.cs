using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicCRM.Domain.Entities
{
    public class Lesson : Entity
    {
        public Lesson()
        {
            Teachers = new List<Teacher>();
            Students = new List<Student>();
        } 
        [Required]
        public DateTime StartingDate { get; set; }
        [Required]
        public DateTime EndingDate { get; set; } 
        public virtual ICollection<Teacher> Teachers { get; set; } 
        public virtual ICollection<Student> Students { get; set; }
    }
}
